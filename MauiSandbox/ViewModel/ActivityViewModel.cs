using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSandbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiSandbox.ViewModel
{
    public partial class ActivityViewModel : BaseViewModel
    {
        IConnectivity _connectivity;

        public ActivityViewModel(IConnectivity connectivity)
        {
            Characters = new ObservableCollection<Characters>();
            _connectivity = connectivity;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        ObservableCollection<Characters> characters;

        List<Characters> characterList;

        [RelayCommand]
        async Task GetCharactersForDayAsync()
        {
            if (IsBusy) return;

            try
            {
                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No Connectivity",
                        "Please check your internet and try again.", "OK");
                    return;
                }

                IsBusy = true;

                using var stream = await FileSystem.OpenAppPackageFileAsync("characterdata.json");
                using var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();
                characterList = JsonSerializer.Deserialize(contents, CharactersContext.Default.ListCharacters);

                var characters = characterList;


                if (Characters.Count != 0)
                    Characters.Clear();

                foreach (var character in characters)
                    Characters.Add(character);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to fetch books: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
