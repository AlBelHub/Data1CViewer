﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Data1C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rumba()
        {
            return View();
     
        }

        [HttpGet]
        public void MainMenu_Click(object sender, EventArgs e)
        {



        }


    }
}
