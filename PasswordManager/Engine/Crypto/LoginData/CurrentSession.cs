
namespace PasswordManager.Engine.Crypto
{
    public static class CurrentSession
    {      
        private static LoginData loginData;            
        public static LoginData LoginData => loginData;

        public static void SetLoginData(LoginData data) 
            => loginData = data;       
    }
}
