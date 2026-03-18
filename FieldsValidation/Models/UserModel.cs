using FieldsValidation.Utilities;

namespace FieldsValidation.Models
{
    internal abstract class UserModel 
    {
        protected bool hasUserNameError = true, hasPwdError = true, hasAgeError = true;
        protected string userNameErrorMessage = Strings.UserNameErr, pwdErrorMessage = Strings.PwdErr,
            loginResult = string.Empty, userName = string.Empty, password = string.Empty;
        public static string AgeErrorMessage { get => Strings.AgeErr; } //same for all users
        protected DateTime birthDate = DateTime.Now;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public abstract DateTime BirthDate {  get; set; }
        public abstract string UserName { get; set; } 
        public abstract string Password { get; set; } 
        public abstract double Age { get; }
        public abstract bool IsUserValid { get; }
        public abstract bool HasUserNameError { get; }
        public abstract bool HasPwdError { get; }
        public abstract bool HasAgeError { get; }
        public abstract string UserNameErrorMessage { get; }
        public abstract string PwdErrorMessage { get; }
        public abstract string LoginResult { get; }
        public abstract void Login();
    }
}
