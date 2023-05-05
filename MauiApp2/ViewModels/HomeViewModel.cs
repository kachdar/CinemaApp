using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Type;
using MauiApp2.Models;
using MauiApp2.Services;
using MauiApp2.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Movie = MauiApp2.Models.Movie;

namespace MauiApp2.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {

        public ObservableCollection<User> Users { get; } = new();
        UserService userService;
        IConnectivity connectivity;

        public HomeViewModel(UserService userService, IConnectivity connectivity)
        {
            this.userService = userService;
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GoToDetails(User user)
        {
            if (user == null)
                return;

            await Shell.Current.GoToAsync(nameof(MoviePage), true, new Dictionary<string, object>
        {
            {"User", user }
        });
        }


        [RelayCommand]
        public async Task GetUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }
                IsRefreshing = true;
                IsBusy = true;
                var users = await userService.GetUsers();

                if (Users.Count != 0)
                    Users.Clear();

                foreach (var user in users)
                    Users.Add(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>
        { 
            new Movie("The Batman", "image1.jpg", "Action"),
            new Movie("Uncharted", "image2.jpg", "Adventure"),
            new Movie("The Exorcism of God", "image3.jpg", "Horror"),
            new Movie("Turning Red", "image4.png", "Comedy"),
            new Movie("Spider-Man: No Way Home", "image5.jpg", "Action"),

        };

        

    }
}
