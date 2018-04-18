using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PasswordManager.Engine.Archive;

namespace PasswordManager
{
    public partial class MainForm : Form
    {
        private List<EntryData> EntryList = new List<EntryData>();
        private bool IsSaved = true;
        private AutoCompleteStringCollection NameList = new AutoCompleteStringCollection();
        private Engine.Search.SearchManager SearchMan;

        public MainForm()
        {
            InitializeComponent();
            panel1.BackColor = Settings.ColorAccent;
            Opacity = 0;
            textBoxSearch.AutoCompleteCustomSource = NameList;
            labelSearchIcon.Text = Settings.SearchIconText;
            label1.Text += Settings.CurrentVersion;
        }

        private void AddEntry(EntryData pass)
        {
            ListViewItem item = new ListViewItem(pass.Name);
            item.SubItems.Add(pass.Username);
            item.SubItems.Add(pass.Comment);
            item.SubItems.Add(pass.Url);
            EntryList.Add(pass);
            materialListView1.Items.Add(item);
        }

        private void LoadPasswords()
        {
            var tempList = ArchiveManager.LoadEntries();
            Invoke((MethodInvoker)delegate
            {
                materialListView1.BeginUpdate();
                if (tempList != null)
                {
                    foreach (EntryData pass in tempList)
                        AddEntry(pass);
                }
                materialListView1.EndUpdate();
                UpdateNameList();
                Animation.FadeIn(this);
            });
            SearchMan = new Engine.Search.SearchManager(ref EntryList);
        }

        private void Main_Load(object sender, EventArgs e) => LoadPasswords();

        private void SaveChanges()
        {
            ArchiveManager.WriteEntries(EntryList);
            IsSaved = true;
        }

        private void UpdateItem(int index)
        {
            var pass = EntryList[index];
            ListViewItem item = new ListViewItem(pass.Name);
            item.SubItems.Add(pass.Username);
            item.SubItems.Add(pass.Comment);
            item.SubItems.Add(pass.Url);
            materialListView1.Items[index] = item;
        }

        private void UpdateNameList()
        {
            foreach (EntryData data in EntryList)
                NameList.Add(data.Name);
        }

        #region Interface

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EntryForm NewPassword = new EntryForm();
            NewPassword.ShowDialog();
            if (!NewPassword.EntryCreatedOrEdited)
                return;        
            AddEntry(NewPassword.Entry);
            IsSaved = false;
            UpdateNameList();
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            if (CMessageBox.ShowDialog(Messages.DeleteEntriesCheck))
            {
                EntryList.Clear();
                materialListView1.Items.Clear();
                UpdateNameList();
                IsSaved = false;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedIndices.Count != 0)
                new ShowPasswordForm().ShowPassword(EntryList[materialListView1.SelectedIndices[0]]);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0 || !CMessageBox.ShowDialog(Messages.DeleteEntryCheck)) return;          
            int index = materialListView1.SelectedIndices[0];
            EntryList.RemoveAt(index);
            materialListView1.Items.RemoveAt(index);
            UpdateNameList();
            IsSaved = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = materialListView1.SelectedIndices[0];
            EntryForm editEntryForm = new EntryForm();
            editEntryForm.ShowData(EntryList[index]);
            editEntryForm.ShowDialog();
            if (!editEntryForm.EntryCreatedOrEdited)
                return;
            EntryList[index] = editEntryForm.Entry;
            UpdateItem(index);
            IsSaved = false;
            UpdateNameList();
        }

        private void buttonSave_Click(object sender, EventArgs e) => SaveChanges();

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        => e.Cancel = (!IsSaved && !CMessageBox.ShowDialog(Messages.ChangesCheck));


        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonShow.Enabled = (materialListView1.SelectedItems.Count != 0);
            buttonEdit.Enabled = (materialListView1.SelectedItems.Count != 0);
            buttonDelete.Enabled = (materialListView1.SelectedItems.Count != 0);
        }

        #endregion Interface

        #region ContextMenu

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
          => buttonAdd_Click(null, null);

        private void copyPasswordToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
            => buttonShow_Click(null, null);

        private void copyUsernameToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(EntryList[materialListView1.SelectedIndices[0]].Username);
            CMessageBox.ShowDialog(Messages.CopiedToClipboard);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
            => buttonDelete_Click(null, null);

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
            => buttonEdit_Click(null, null);

        private void materialContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool enable = materialListView1.SelectedItems.Count != 0;
            deleteToolStripMenuItem.Enabled = enable;
            ShowPasswordToClipboardToolStripMenuItem.Enabled = enable;           
            editToolStripMenuItem.Enabled = enable;
        }

        #endregion ContextMenu

        #region Search

        public void ReleaseSearchBoxFocus()
        {            
            panelSearchTextbox.Height = 1;
            panelSearchTextbox.BackColor = Color.Gainsboro;
        }

        public void SetSearchBoxFocus()
        {
            textBoxSearch.Text = "";
            panelSearchTextbox.Height = 2;
            panelSearchTextbox.BackColor = Settings.SearchBoxFocusColor;
        }

        private void SelectItem(int Index)
        {
            if (Index != -1)
            {
                materialListView1.Select();
                materialListView1.Focus();
                materialListView1.Items[Index].Focused = true;
                materialListView1.Items[Index].Selected = true;
                materialListView1.Items[Index].EnsureVisible();
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || textBoxSearch.Text == "") return;
            SelectItem(SearchMan.SearchIndex(textBoxSearch.Text));
        }

        private void materialListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SearchMan.CanSearchLastString)
                SelectItem(SearchMan.SearchIndexWithLastString());
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        => SetSearchBoxFocus();

        private void textBoxSearch_Leave(object sender, EventArgs e)
        => ReleaseSearchBoxFocus();

        #endregion Search

        private void materialListView1_MouseDoubleClick(object sender, MouseEventArgs e)        
            => buttonShow_Click(sender, null);
        
    }
}