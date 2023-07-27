using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSandbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiSandbox.ViewModel
{
    [QueryProperty(nameof(Book), "Book")]
    public partial class AddCharacterViewModel : BaseViewModel
    {
        public AddCharacterViewModel()
        {
            Characters = new ObservableCollection<string>();
            myImageSource = string.Empty;
        }

        [ObservableProperty]
        ObservableCollection<string> characters;

        [ObservableProperty]
        Book book;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Image))]
        string myImageSource;

        // this value is never getting set it keeps coming up as null
        public string Image => MyImageSource;

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            Characters.Add(Text);
            // add item
            Text = string.Empty;
        }

        [RelayCommand]
        async Task<string> TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {

                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    MyImageSource = localFilePath;

                    return MyImageSource;
                }
            }
            return MyImageSource;
        }


        [RelayCommand]
        async Task<string> UploadPhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    var imageSource = photo.FullPath.ToString();

                    MyImageSource = imageSource;

                }
            }
            return MyImageSource;
        }
    }
}
