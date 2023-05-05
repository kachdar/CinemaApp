using MauiApp2.ViewModels;

namespace MauiApp2.Views;

public partial class MoviePage : ContentPage
{
	public MoviePage(MovieViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }
}