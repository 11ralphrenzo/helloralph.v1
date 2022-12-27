using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Utilities;
using helloralph.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    public partial class MediaPickerViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<BaseInfoModel> items = new ObservableCollection<BaseInfoModel>();

        public MediaPickerViewModel()
        {
            Title = Constants.MEDIAPICKER;
        }

        public void LoadList()
        {
            Items.Add(new BaseInfoModel { Name = "Tap to Check", Value = "Pick Photo", Definition = "Opens the media browser to select a photo.", Tag = Enums.MediaPickerFeatures.PickPhoto });
            Items.Add(new BaseInfoModel { Name = "Tap to Check", Value = "Capture Photo", Definition = "Opens the camera to take a photo.", Tag = Enums.MediaPickerFeatures.CapturePhoto });
            Items.Add(new BaseInfoModel { IsEnabled = false, Name = "Tap to Check", Value = "Pick Video", Definition = "Opens the media browser to select a video.", Tag = Enums.MediaPickerFeatures.PickVideo });
            Items.Add(new BaseInfoModel { IsEnabled = false, Name = "Tap to Check", Value = "Capture Video", Definition = "Opens the camera to take a video.", Tag = Enums.MediaPickerFeatures.CaptureVideo });
        }

        [RelayCommand]
        public async void Tap(BaseInfoModel model)
        { 
            if (model == null)
                return;

            switch (model.Tag)
            { 
                case Enums.MediaPickerFeatures.PickPhoto:
                case Enums.MediaPickerFeatures.CapturePhoto:
                    await Shell.Current.GoToAsync(nameof(PickOrCapturePhotoPage), true, new Dictionary<string, object>
                        {
                            { "Feature", model.Tag }
                        });
                    break;
                case Enums.MediaPickerFeatures.PickVideo:
                    break;
                case Enums.MediaPickerFeatures.CaptureVideo:
                    break;
            }
        }
    }
}
