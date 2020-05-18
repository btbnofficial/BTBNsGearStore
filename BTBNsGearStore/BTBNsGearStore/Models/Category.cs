using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class Category
    {
        private int id;
        private string name;
        private string image;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
    }
}