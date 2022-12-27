using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Utilities;
using Syncfusion.Maui.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    public partial class SfAvatarViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<DefaultCharacter> defaultCharacters = new List<DefaultCharacter>();

        [ObservableProperty]
        ObservableCollection<Employee> collectionBoth = new ObservableCollection<Employee>();

        [ObservableProperty]
        ObservableCollection<Employee> collectionImages = new ObservableCollection<Employee>();

        [ObservableProperty]
        ObservableCollection<Employee> collectionInitials = new ObservableCollection<Employee>();

        public SfAvatarViewModel()
        {
            Title = Constants.AVATAR_VIEW;

            var x = Enum.GetValues(typeof(AvatarCharacter)).Cast<AvatarCharacter>().ToList();
            foreach (var c in x)
            {
                DefaultCharacters.Add(new DefaultCharacter { Name = c.ToString(), Value = c });
            }

            CollectionBoth.Add(new Employee { Name = "Mike", ImageSource = "avatar.jpg", Colors = Colors.Gray });
            CollectionBoth.Add(new Employee { Name = "Alex", ImageSource = "ralph.jpg", Colors = Colors.Bisque });
            CollectionBoth.Add(new Employee { Name = "Ellanaa", Colors = Colors.Brown });

            CollectionImages.Add(new Employee { Name = "Mike", ImageSource = "aang.jpg", Colors = Colors.Gray });
            CollectionImages.Add(new Employee { Name = "Alex", ImageSource = "ralph.jpg", Colors = Colors.Bisque });
            CollectionImages.Add(new Employee { Name = "Ellanaa", ImageSource = "avatar.jpg", Colors = Colors.Brown });

            CollectionInitials.Add(new Employee { Name = "Mike", Colors = Colors.Gray });
            CollectionInitials.Add(new Employee { Name = "Alex", Colors = Colors.Bisque });
            CollectionInitials.Add(new Employee { Name = "Ellanaa", Colors = Colors.Brown });
        }
    }
}
