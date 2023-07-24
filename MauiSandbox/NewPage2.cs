namespace MauiSandbox;

public class NewPage2 : ContentPage
{
	public NewPage2()
	{
		var button = new Button { Text = "Go Back Home" };
		button.Clicked += Button_Clicked;
		Content = new VerticalStackLayout
		{
			Children = {
				button,
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to New Page 2 with C#!"
				}
			}
		};
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(".."); // goes back one page
		//can use this to alter things based on platform in c#
//#if ANDROID
//		Android.Bluetooth.
//#elif IOS

//#endif
	}
}