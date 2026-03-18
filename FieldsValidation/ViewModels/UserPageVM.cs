using FieldsValidation.Models;
using FieldsValidation.ModelsLogic;
using FieldsValidation.Utilities;
using System.Windows.Input;
namespace FieldsValidation.ViewModels;

internal class UserPageVM:ObservableObject
{
    private readonly UserModel user;

    public ICommand LoginCommand { get; private set; }
    public bool IsUserValid { get => user.IsUserValid; }
    public string UserNameErrorMessage { get => user.UserNameErrorMessage; }
    public bool HasUserNameError { get => user.HasUserNameError; }
    public string UserPwdErrorMessage { get => user.PwdErrorMessage; }
    public bool HasUserPwdError { get => user.HasPwdError; }
    public static string UserAgeErrorMessage { get => User.AgeErrorMessage; }
    public bool HasUserAgeError { get => user.HasAgeError; }
    public string Name {  get => user.Name; set => user.Name = value;}
    public string Email {  get => user.Email; set => user.Email = value;}
    public double Age { get => user.Age; }
    public string LoginResult { get => user.LoginResult; }
    public string UserName
    {
        get => user.UserName; 
        set 
        {
            if (user.UserName != value)
            {
                user.UserName = value;
                OnPropertyChanged(nameof(UserNameErrorMessage));
                OnPropertyChanged(nameof(HasUserNameError));
                OnPropertyChanged(nameof(IsUserValid));
                OnPropertyChanged(nameof(LoginResult));
            }
        }
    }
    public string Password
    {
        get => user.Password; 
        set 
        {
            if (user.Password != value)
            {
                user.Password = value;
                OnPropertyChanged(nameof(UserPwdErrorMessage));
                OnPropertyChanged(nameof(HasUserPwdError));
                OnPropertyChanged(nameof(IsUserValid));
                OnPropertyChanged(nameof(LoginResult));
            }
        }
    }

    public DateTime BirthDate
    {
        get { return user.BirthDate; }
        set 
        {
            if (user.BirthDate != value)
            {
                user.BirthDate = value;
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(HasUserAgeError));
                OnPropertyChanged(nameof(IsUserValid));
                OnPropertyChanged(nameof(LoginResult));
            }
        }
    }
    public UserPageVM()
    {
        user = new User();
        LoginCommand = new Command(Login);
    }
    private void Login(object obj)
    {
        if (IsUserValid)
        {

            user.Login(); 
            OnPropertyChanged(nameof(LoginResult));
        }
    }
}
