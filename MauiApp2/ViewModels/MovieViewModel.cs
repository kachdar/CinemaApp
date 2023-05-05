using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie = MauiApp2.Models.Movie;

namespace MauiApp2.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial class MovieViewModel : ObservableObject
    {
        
        [ObservableProperty]
        User user;

        [ObservableProperty]
        Movie movie = new() {
            Title = "The Batman",
            ImageUrl = "image1.jpg",
            Genre = "Action",
            Description = "When the Riddler, a sadistic serial killer, begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption and question his family's involvement.",
            Certificate = "16+",
            Release = 2022,
            Runtime = "02:56",
            Director = "Matt Reeves",
            Cast = "Robert Pattinson, Zoë Kravitz, Jeffrey Wright, Colin Farrell, Paul Dano, John Turturro, \tAndy Serkis, Peter Sarsgaard"
        };

    }
}
