using Comercio_Movil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio_Movil.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Item> cart;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Imagen="https://p4.wallpaperbetter.com/wallpaper/540/808/949/camera-lens-sony-wallpaper-preview.jpg", Text = "Sony DSC-W830s", Description="Cámara Digital Compacta Cyber-Shot con zoom óptico 8x", Precio=3298 },
                new Item { Id = Guid.NewGuid().ToString(), Imagen="https://i.blogs.es/f84e9b/nikon-d3500-1-/1366_2000.jpg", Text = "Nikon Coolpix", Description="Fotos y videos hermosos con su sensor de poca luz de 16 megapíxeles, Reducción de la vibración de Lens-Shift (VR)", Precio=8699 },
                new Item { Id = Guid.NewGuid().ToString(), Imagen="https://images.samsung.com/is/image/samsung/p6pim/latin/galaxy-s21/gallery/latin-galaxy-s21-5g-g991-sm-g991bzvjtpa-368316791?$720_576_PNG$", Text = "Galaxy S21", Description="Samsung Galaxy S21 5G, Smartphone con tres cámaras integradas y ultima tecnologia", Precio=18900 },
                new Item { Id = Guid.NewGuid().ToString(), Imagen="https://images6.alphacoders.com/317/317994.jpg", Text = "Canon T7", Description="La EOS Rebel T7 tiene capacidad de sensor CMOS de 24.1 megapíxeles.", Precio=10799 },
                new Item { Id = Guid.NewGuid().ToString(), Imagen="https://isopixel.net/wp-content/uploads/2020/04/ROG-Strix-G15-17.jpg", Text = "Laptop Asus", Description="Asus Rog Strix G15 Electro, 15 pulgadas, Geforce Gtx 1650 Ti With Rog Boost Intel, Core I5 10A Gen, 16Gb Ram, 512 Ssd, G512Li-Black", Precio=28999 },
                new Item { Id = Guid.NewGuid().ToString(), Imagen="https://media.flixcar.com/f360cdn/Lenovo-65687811-lenovo-laptop-legion-5-15-intel-subseries-feature-8-mobile.jpg", Text = "Laptop Lenovo", Description="Lenovo Laptop Legión Intel Core i3, RAM 8GB, HDD 1TB + 128 GB SDD, Windows 10, Plata.", Precio=13699 }
            };

            cart = new List<Item>();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> AddCarrito(string id)
        {
            cart.Add(items.FirstOrDefault(s => s.Id == id));

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}