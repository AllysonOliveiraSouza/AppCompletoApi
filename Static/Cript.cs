namespace AppCompletoApi.Static
{
    public static class Cript
    {
        public static string CriaHashSenha(string senha)
        {
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);           
            return senhaHash;
        }
        public static bool ValidaSenha(string senhaDigitada, string senhaBd)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, senhaBd);
        }
    }
}
