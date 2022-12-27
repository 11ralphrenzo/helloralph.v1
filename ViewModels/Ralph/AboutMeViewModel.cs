using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;

namespace helloralph.ViewModels
{
    public partial class AboutMeViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<ExperienceGroup> expGroups = new List<ExperienceGroup>();

        public AboutMeViewModel()
        {
            expGroups.Add(new ExperienceGroup("WORK EXPERIENCE",
                    new List<ExperienceModel>
                    {
                        new ExperienceModel
                        {
                            Image = "avatar.jpg",
                            Name = "FULLSCALE",
                            Position = "Xamarin Developer",
                            NumYears = 3,
                            NumMonths = 3
                        },
                        new ExperienceModel
                        {
                            Image = "avatar.jpg",
                            Name = "APPSTONE",
                            Position = "Software Engineer",
                            NumYears = 1,
                            NumMonths = 6
                        }
                    }));
            expGroups.Add(new ExperienceGroup("TRAININGS",
                    new List<ExperienceModel>
                    {
                        new ExperienceModel
                        {
                            Image = "avatar.jpg",
                            Name = "APPSTONE ACADEMY",
                            Position = "Xamarin Developer Trainee"
                        }
                    }));
            expGroups.Add(new ExperienceGroup("EDUCATIONAL BACKGROUND",
                    new List<ExperienceModel>
                    {
                            new ExperienceModel
                            {
                                Image = "avatar.jpg",
                                Name = "UNIVERSITY OF CEBU - LM",
                                Position = "BS - Information Technology"
                            },
                            new ExperienceModel
                            {
                                Image = "avatar.jpg",
                                Name = "LA CONSOLACION COLLEGE - LILOAN",
                                Position = "Liloan, Cebu"
                            },
                            new ExperienceModel
                            {
                                Image = "avatar.jpg",
                                Name = "YATI ELEMENTARY SCHOOL",
                                Position = "Liloan, Cebu"
                            }
                    }));
        }

        [RelayCommand]
        void ShowMenu()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}

