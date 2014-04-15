﻿using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Controllers
{
    public class TermController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult AddEdit()
        {
            return View(new TermModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(TermModel model)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                client.BaseAddress = new Uri("http://localhost:2043/");
                var response = await client.PostAsJsonAsync<TermModel>("api/terms", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
            }

            return View(model);
        }
	}
}