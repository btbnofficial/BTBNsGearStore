using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Models
{
    public class Post
    {
        private int id;
        private DateTime datePosted;
        private string title;
        private string noiDung;

        public int Id { get => id; set => id = value; }
        [Display(Name = "Tiêu đề")]
        public string Title { get => title; set => title = value; }
        [Display(Name = "Nội dung")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string NoiDung { get => noiDung; set => noiDung = value; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime DatePosted { get => datePosted; set => datePosted = value; }
    }
}