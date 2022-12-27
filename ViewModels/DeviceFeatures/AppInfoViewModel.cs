using CommunityToolkit.Mvvm.ComponentModel;
using helloralph.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using helloralph.Models;
using System.Collections.ObjectModel;

namespace helloralph.ViewModels
{
    public partial class AppInfoViewModel : BaseViewModel
    {
        public AppInfoViewModel()
        {
            Title = Constants.APP_INFO;
        }

        [ObservableProperty]
        ObservableCollection<AppInfoModel> appInfos = new ObservableCollection<AppInfoModel>();

        public void LoadList()
        {
            AppInfos = new ObservableCollection<AppInfoModel>()
            {
                new AppInfoModel { Name = "Name", Value = AppInfo.Current.Name },
                new AppInfoModel { Name = "Package", Value = AppInfo.Current.PackageName },
                new AppInfoModel { Name = "Version", Value = AppInfo.Current.VersionString },
                new AppInfoModel { Name = "Build", Value = AppInfo.Current.BuildString }
            };
        }
    }
}
