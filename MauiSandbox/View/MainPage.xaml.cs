using MauiSandbox.ViewModel;

namespace MauiSandbox;

public partial class MainPage : ContentPage
{


	public MainPage(BooksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

