using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using MauiSandbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using MauiSandbox.View;

namespace MauiSandbox.ViewModel
{
    [QueryProperty(nameof(Book), "Book")]
    public partial class AddCharacterViewModel : BaseViewModel
    {
        public AddCharacterViewModel()
        {
            Characters = new ObservableCollection<Characters>();
            myImageSource = string.Empty;
        }

        [ObservableProperty]
        ObservableCollection<Characters> characters;

        [ObservableProperty]
        Book book;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Image))]
        string myImageSource;

        // this value is never getting set it keeps coming up as null
        public string Image => MyImageSource;

        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return;

            var newCharacter = new Characters
            {
                FirstName = Name,
                LastName = Name,
                Image = Image
            };

            Characters.Add(newCharacter);

            await Shell.Current.GoToAsync($"///{nameof(MainPage)}", true);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.LightGreen,
                //TextColor = Colors.Green,
                //ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
                //CharacterSpacing = 0.5
            };

            string text = "Character Added";
            //ToastDuration duration = ToastDuration.Short;
            TimeSpan duration = TimeSpan.FromSeconds(3);
            double fontSize = 14;
            //Action action = async () => await Shell.Current.GoToAsync(nameof(ActivityPage));

            var snackbar = Snackbar.Make(text, null, "View", duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);

            //var toast = Toast.Make(text, duration, fontSize);

            //await toast.Show(cancellationTokenSource.Token);
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
