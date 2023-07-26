using MauiSandbox.ViewModel;

namespace MauiSandbox;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(BookDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}