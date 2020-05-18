using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class Brand
    {
        private string id;
        private string name;
        private string image;
        private string info;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string Info { get => info; set => info = value; }
    }
}