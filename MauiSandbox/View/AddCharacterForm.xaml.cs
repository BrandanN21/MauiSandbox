using MauiSandbox.ViewModel;

namespace MauiSandbox.View;

public partial class AddCharacterForm : ContentPage
{
	public AddCharacterForm(AddCharacterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}