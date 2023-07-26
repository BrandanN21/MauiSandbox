using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSandbox.Model;
using MauiSandbox.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSandbox.ViewModel
{
    [QueryProperty(nameof(Book), "Book")]
    public partial class BookDetailsViewModel : BaseViewModel
    {

        public BookDetailsViewModel() { }

        [ObservableProperty]
        Book book;

        [RelayCommand]
        async Task AddNewCharacterAsync(Book book)
        {
            if (book == null) return;

            await Shell.Current.GoToAsync(nameof(AddCharacterForm), true, new Dictionary<string, object>
            {
                { "Book", book }
            });
        }
    }
}
