using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;

namespace helloralph.ViewModels
{
	[QueryProperty(nameof(Categories), nameof(Categories))]
    [QueryProperty(nameof(Tasks), nameof(Tasks))]
    public partial class AddNewTaskViewModel : BaseViewModel
	{
		[ObservableProperty]
		string task;

		[ObservableProperty]
		ObservableCollection<MyTask> tasks = new ObservableCollection<MyTask>();

        [ObservableProperty]
        ObservableCollection<Category> categories = new ObservableCollection<Category>();

		[RelayCommand]
		async void AddTask()
		{
			var selectedCategory = Categories.Where(x => x.IsSelected).FirstOrDefault();

			if (selectedCategory is not null)
			{
				var task = new MyTask
				{
					Name = Task,
					CategoryId = selectedCategory.Id,
				};
				Tasks.Add(task);
				await Shell.Current.GoToAsync("..", true,
					new Dictionary<string, object>
					{
						{ nameof(Categories), Categories },
                        { nameof(Tasks), Tasks }
                    });
			}
			else
			{
				await Shell.Current.DisplayAlert("Invalid Selection", "You must select a category", "OK");
			}
		}

        [RelayCommand]
        async void AddCategory()
        {
			string category = await Shell.Current.DisplayPromptAsync("New Category",
				"Write the new category name",
				maxLength: 15,
				keyboard: Keyboard.Text);

			var r = new Random();

			if (category is not null)
			{
				Categories.Add(new Category
				{
					Id = Categories.Max(x => x.Id) + 1,
					Color = Color.FromRgb(r.Next(0, 255),
                                            r.Next(0, 255),
                                            r.Next(0, 255)),
					Name = category
				});
			}
        }
    }
}

