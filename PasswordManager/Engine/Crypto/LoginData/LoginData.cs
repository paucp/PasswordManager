namespace PasswordManager.Engine.Crypto
{
    public class LoginData
    {
        private byte[] derivedKey;
        private byte[] masterKey;
        private byte[] masterHash;

        public byte[] DerivedMasterkey => derivedKey;
        public byte[] MasterKey => masterKey;
        public byte[] MasterHash => masterHash;
        public byte[] Salt { get; }
        public byte[] IV { get; }

        public LoginData(byte[] masterhash, byte[] saltbytes, byte[] ivbytes)
        {
            derivedKey = null;
            masterKey = null;
            masterHash = masterhash;
            Salt = saltbytes;
            IV = ivbytes;
        }
        public LoginData(byte[] masterkey, byte[] masterhash, byte[] derivedkey, byte[] saltbytes, byte[] ivbytes)
        {
            derivedKey = derivedkey;
            masterKey = masterkey;
            masterHash = masterhash;
            Salt = saltbytes;
            IV = ivbytes;
        }
        public void SetKeys(byte[] Master, byte[] Hash, byte[] Derived)
        {
            masterKey = Master;
            masterHash = Hash;
            derivedKey = Derived;           
        }     
    }
}
