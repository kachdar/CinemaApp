using MauiApp2.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp2.Views;

public partial class MainPage : ContentPage
{
    HomeViewModel model;
    public MainPage(HomeViewModel view)
	{
		InitializeComponent();
        model = view;
		BindingContext = model;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await model.GetUsersAsync();
    }
}

