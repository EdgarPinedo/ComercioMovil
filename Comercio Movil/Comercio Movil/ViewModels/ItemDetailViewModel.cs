using Comercio_Movil.Models;
using Comercio_Movil.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Comercio_Movil.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string imagen;
        private string text;
        private string description;
        private int precio;
        public string Id { get; set; }
        public Command Inicio { get; }
        public Command Cart { get; }

        public ItemDetailViewModel()
        {
            Inicio = new Command(IrInicio);
            Cart = new Command(AddCart);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Imagen
        {
            get => imagen;
            set => SetProperty(ref imagen, value);
        }

        public int Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Imagen = item.Imagen;
                Text = item.Text;
                Description = item.Description;
                Precio = item.Precio;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void AddCart(object obj)
        {
            try
            {
                await DataStore.AddCarrito(this.itemId);
                await Application.Current.MainPage.DisplayAlert("Carrito", "Añadido al carrito","0k");
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Add Cart");
            }
        }

        public async void IrInicio(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
