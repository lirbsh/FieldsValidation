using FieldsValidation.ViewModels;

namespace FieldsValidation.Views;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
		BindingContext = new UserPageVM();
	}
}