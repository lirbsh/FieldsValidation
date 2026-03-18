using FieldsValidation.Views;

namespace FieldsValidation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new UserPage(); //new AppShell();
        }
    }
}
