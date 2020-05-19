namespace DbCard.Infrastructure.Models
{
    public class ValidationErrors
    {
        public bool Error { get; protected set; }
        public string ErrorBody { get; protected set; }
        public ValidationErrors(bool error, string errorBody = "")
        {
            Error = error;
            ErrorBody = errorBody;
        }
    }
}