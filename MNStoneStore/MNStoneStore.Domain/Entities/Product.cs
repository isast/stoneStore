﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MNStoneStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput (DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string category { get; set; }
        [Required(ErrorMessage = "Please a damage value")]
        public string Damage { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}