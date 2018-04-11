using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MNStoneStore.Domain.Entities;

namespace MNStoneStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}