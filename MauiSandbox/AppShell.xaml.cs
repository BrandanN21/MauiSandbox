﻿using MauiSandbox.View;

namespace MauiSandbox;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AddCharacterForm), typeof(AddCharacterForm));
    }
}
