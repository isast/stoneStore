﻿using System.Web.Mvc;
using System.Collections.Generic;
using MNStoneStore.Domain.Abstract;
using System.Linq;

namespace MNStoneStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController (IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products.Select(x => x.category)
                                                                .Distinct()
                                                                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}