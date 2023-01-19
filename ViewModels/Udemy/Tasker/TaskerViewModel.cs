using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Views;

namespace helloralph.ViewModels
{
    [QueryProperty(nameof(Tasks), nameof(Tasks))]
    [QueryProperty(nameof(Categories), nameof(Categories))]
    public partial class TaskerViewModel : BaseViewModel
	{
		[ObservableProperty]
		ObservableCollection<Category> categories = new ObservableCollection<Category>();

        [ObservableProperty]
        ObservableCollection<MyTask> tasks = new ObservableCollection<MyTask>();

        public TaskerViewModel()
		{
			FillData();
            Tasks.CollectionChanged += (o, e) => UpdateData();
		}

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                        Id = 1,
                        Name = ".NET MAUI Course",
                        Color = Colors.Red,
                },
                new Category
                {
                        Id = 2,
                        Name = "Tutorials",
                        Color = Colors.Blue
                },
                new Category
                {
                        Id = 3,
                        Name = "Shopping",
                        Color = Colors.Green
                }
            };

            Tasks = new ObservableCollection<MyTask>
               {
                    new MyTask
                    {
                         Name = "Upload exercise files",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         Name = "Plan next course",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         Name = "Upload new ASP.NET video on YouTube",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         Name = "Fix Settings.cs class of the project",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         Name = "Update github repository",
                         Completed = true,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         Name = "Buy eggs",
                         Completed = false,
                         CategoryId = 3
                    },
                    new MyTask
                    {
                         Name = "Go for the pepperoni pizza",
                         Completed = false,
                         CategoryId = 3
                    },
               };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;



                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.Color = catColor;
            }
        }

        [RelayCommand]
        void AddNewTask()
        {
            Shell.Current.GoToAsync(nameof(AddNewTaskPage), true,
                new Dictionary<string, object>
                {
                    { nameof(Categories), Categories },
                    { nameof(Tasks), Tasks }
                });
        }

    }
}

