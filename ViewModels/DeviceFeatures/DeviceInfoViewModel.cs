using CommunityToolkit.Mvvm.ComponentModel;
using helloralph.Models;
using helloralph.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    public partial class DeviceInfoViewModel : BaseViewModel
    {
        public DeviceInfoViewModel()
        {
            Title = Constants.DEVICE_INFO;
            Setup();
        }

        [ObservableProperty]
        ObservableCollection<DeviceInfoModel> deviceInfos = new ObservableCollection<DeviceInfoModel>();

        void Setup()
        {
            deviceInfos.Add(new DeviceInfoModel { Name = "Platform", Value = DeviceInfo.Current.Platform.ToString() });
            deviceInfos.Add(new DeviceInfoModel { Name = "Device Type", Value = DeviceInfo.Current.DeviceType.ToString() });
            deviceInfos.Add(new DeviceInfoModel { Name = "Model", Value = DeviceInfo.Current.Model });
            deviceInfos.Add(new DeviceInfoModel { Name = "Manufacturer", Value = DeviceInfo.Current.Manufacturer });
            deviceInfos.Add(new DeviceInfoModel { Name = "Name", Value = DeviceInfo.Current.Name });
            deviceInfos.Add(new DeviceInfoModel { Name = "OS Version", Value = DeviceInfo.Current.VersionString });
            //deviceInfos.Add(new DeviceInfoModel { Name = "Refresh Rate", Value = DeviceInfo.Current.ToString() });
            deviceInfos.Add(new DeviceInfoModel { Name = "Idiom", Value = DeviceInfo.Current.Idiom.ToString() });
        }
    }
}
