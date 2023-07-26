using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSandbox.Model;
using MauiSandbox.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSandbox.ViewModel
{
    public partial class BooksViewModel : BaseViewModel
    {
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();

        IConnectivity _connectivity;
        BookService _bookService;

        public BooksViewModel(IConnectivity connectivity, BookService bookService)
        {
            Title = "Books";

            _connectivity = connectivity;
            _bookService = bookService;
        }

        [ObservableProperty]
        bool isRefreshing;


        [RelayCommand]
        async Task GetBooksAsync()
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
                var books = await _bookService.GetBooks();


                if (Books.Count != 0)
                    Books.Clear();

                foreach (var monkey in books)
                    Books.Add(monkey);
            }
            catch(Exception ex)
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

        [RelayCommand]
        async Task GoToDetails(Book book)
        {
            if (book is null) return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                { "Book", book }
            });
        }
    }
}
