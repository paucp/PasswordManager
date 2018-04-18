
namespace PasswordManager.Engine.Crypto
{
    public static class CurrentSession
    {      
        private static LoginData SessionData;            
        public static LoginData SessionLoginData => SessionData;

        public static void SetLoginData(LoginData data) 
            => SessionData = data;       
    }
}
