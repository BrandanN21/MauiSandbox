using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSandbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            Image = new Image();
        }

        [ObservableProperty]
        ObservableCollection<string> characters;

        [ObservableProperty]
        Book book;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        Image image;

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
        async Task TakePhoto()
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

                    Image = new Image
                    {
                        Source = ImageSource.FromFile(localFilePath)
                    };

                    return;
                }
            }
            return;
        }
    }
}
