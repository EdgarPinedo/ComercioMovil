using Comercio_Movil.Models;
using Comercio_Movil.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Comercio_Movil.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command ShowCarrito { get; }
        public Command CerrarSesion { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            ShowCarrito = new Command(MostrarCarrito);

            AddItemCommand = new Command(OnAddItem);

            CerrarSesion = new Command(OnLoginClicked);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void MostrarCarrito(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            var hola = new ItemDetailViewModel();
            hola.ItemId = item.Id;
            var secondPage = new ItemDetailPage();
            secondPage.BindingContext = hola;
            await Application.Current.MainPage.Navigation.PushModalAsync(secondPage);
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        public async void OnLoginClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}