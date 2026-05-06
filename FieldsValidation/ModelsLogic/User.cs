using FieldsValidation.Models;
using FieldsValidation.Utilities;

namespace FieldsValidation.ModelsLogic
{
    internal class User:UserModel
    {
        public override double Age
        {
            get
            {
                TimeSpan ts = DateTime.Today - BirthDate;
                double age = double.Round(ts.TotalDays / 365, 2, MidpointRounding.ToPositiveInfinity);
                age = age < 0 ? 0 : age;
                return age;
            }
        }
        public override bool IsUserValid => !hasUserNameError && !hasPwdError && !hasAgeError;
        public override bool HasUserNameError => hasUserNameError;
        public override bool HasPwdError => hasPwdError;
        public override bool HasAgeError => hasAgeError;
        public override string UserNameErrorMessage => userNameErrorMessage;
        public override string PwdErrorMessage => pwdErrorMessage;
        public override string LoginResult => loginResult;

        public override string UserName 
        { 
            get => userName; 
            set
            {
                bool beginWithDigit = true, containSpace = true, empty = string.IsNullOrWhiteSpace(value);
                if (!empty)
                {
                    beginWithDigit = int.TryParse(value[..1], out _);
                    containSpace = value.Contains(' ');
                }
                hasUserNameError = beginWithDigit || containSpace || empty;
                if (empty)
                    userNameErrorMessage = Strings.UserNameErr;
                else if (beginWithDigit)
                    userNameErrorMessage = Strings.UserNameErr1;
                else
                    userNameErrorMessage = Strings.UserNameErr2;
                loginResult = string.Empty;
                userName = value;
            }
        }

        public override string Password 
        { 
            get => password; 
            set 
            {
                bool hasDigit = false, hasCapital = false, empty = string.IsNullOrWhiteSpace(value);
                if (!empty)
                {
                    hasDigit = value.Any(char.IsDigit);
                    hasCapital = value.Any(char.IsUpper);
                }

                hasPwdError = !hasDigit || !hasCapital || empty;
                if (empty)
                    pwdErrorMessage = Strings.PwdErr;
                else if (!hasCapital)
                    pwdErrorMessage = Strings.PwdErr1;
                else
                    pwdErrorMessage = Strings.PwdErr2;
                loginResult = string.Empty;
                password = value;
            } 
        }
        public override DateTime BirthDate 
        { 
            get => birthDate; 
            set
            {
                birthDate = value;
                hasAgeError = Age < 18;
                loginResult = string.Empty;
            } 
        }

        public override void Login()
        {
            loginResult = (userName == "admin" && password == "1234") ? "Loged in" : "Faield to login";
        }
    }
}
