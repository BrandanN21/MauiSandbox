using MauiSandbox.ViewModel;

namespace MauiSandbox.View;

public partial class ActivityPage : ContentPage
{
	public ActivityPage(ActivityViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}