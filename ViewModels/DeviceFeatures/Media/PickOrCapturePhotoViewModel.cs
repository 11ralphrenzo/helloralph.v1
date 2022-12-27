using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    [QueryProperty("Feature", "Feature")]
    public partial class PickOrCapturePhotoViewModel : BaseViewModel
    {
        [ObservableProperty]
        Enums.MediaPickerFeatures feature;

        [ObservableProperty]
        string localFilePath;

        public PickOrCapturePhotoViewModel()
        {

        }

        public void HandleQueryProperty()
        {
            Do(feature);
        }

        [RelayCommand]
        void Tap(string param)
        {
            Do((Enums.MediaPickerFeatures)Enum.Parse(typeof(Enums.MediaPickerFeatures), param, true));
        }

        async void Do(Enums.MediaPickerFeatures feature)
        {
            if (!MediaPicker.Default.IsCaptureSupported)
                return;

            FileResult photo = null;

            switch (feature)
            {
                case Enums.MediaPickerFeatures.PickPhoto:
                    photo = await MediaPicker.Default.PickVideoAsync();
                    break;
                case Enums.MediaPickerFeatures.CapturePhoto:
                    photo = await MediaPicker.Default.CapturePhotoAsync();
                    break;
            }

            if (photo != null)
            {
                // save the file into local storage
                LocalFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }
}
