namespace PasswordManager.Engine.Crypto
{
    public class LoginData
    {              
        public byte[] Salt { get; }
        public byte[] IV { get; }    
        
        public LoginData(byte[] saltbytes, byte[] ivbytes)
        {          
            Salt = saltbytes;
            IV = ivbytes;
        }
       
    }
}