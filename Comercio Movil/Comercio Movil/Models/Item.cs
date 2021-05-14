using System;

namespace Comercio_Movil.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Imagen { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Precio { get; set; }
    }
}