using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Models
{
    public class Product
    {
        private int id;
        private string name;
        private int categoryId;
        private string brandId;
        private int guarantee;
        private double entryPrice;
        private double price;
        private string image1;
        private string image2;
        private string image3;
        private string image4;
        private string detail;
        private int amount;
        private string noiDung;

        [Display(Name = "Mã sản phẩm")]
        public int Id { get => id; set => id = value; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn cần nhập tên sản phẩm")]
        [StringLength(100,MinimumLength = 1, ErrorMessage = "Bạn cần phải nhập tên sản phầm tối thiểu {2}")]
        public string Name { get => name; set => name = value; }
        [Display(Name = "ID danh mục")]
        public int CategoryId { get => categoryId; set => categoryId = value; }
        [Display(Name = "ID nhãn hiệu")]
        public string BrandId { get => brandId; set => brandId = value; }
        [Display(Name = "Bảo hành(tháng)")]
        public int Guarantee { get => guarantee; set => guarantee = value; }
        [Display(Name = "Giá nhập")]
        public double EntryPrice { get => entryPrice; set => entryPrice = value; }
        [Display(Name = "Giá bán")]
        public double Price { get => price; set => price = value; }
        [Display(Name = "Ảnh 1")]
        public string Image1 { get => image1; set => image1 = value; }
        [Display(Name = "Ảnh 2")]
        public string Image2 { get => image2; set => image2 = value; }
        [Display(Name = "Ảnh 3")]
        public string Image3 { get => image3; set => image3 = value; }
        [Display(Name = "Ảnh 4")]
        public string Image4 { get => image4; set => image4 = value; }
        [Display(Name = "Mô tả")]
        public string Detail { get => detail; set => detail = value; }
        [Display(Name = "Số lượng")]
        public int Amount { get => amount; set => amount = value; }

        [Display(Name = "Nội dung")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string NoiDung { get => noiDung; set => noiDung = value; }
    }
}