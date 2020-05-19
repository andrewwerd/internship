namespace DbCard.Infrastructure.Models
{
    public class LoginResult
    {
        public string EncodedToken { get; protected set; }
        public bool Succeeded { get; protected set; }
        public LoginResult(bool succeeded, string encodedToken = "")
        {
            EncodedToken = encodedToken;
            Succeeded = succeeded;
        }
    }
}