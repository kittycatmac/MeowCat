using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MeowCat.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeowCat.Controllers
{
    public class PartialViewResult : Controller
    {
        // GET: Breed
        public ActionResult Index()
        {
            IEnumerable<BreedModel> breeds;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
                //HTTP GET
                var responseTask = client.GetAsync("breeds");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BreedModel>>();
                    readTask.Wait();

                    breeds = readTask.Result;
                }
                else //web api sent error response
                {
                    //log response status here..

                    breeds = Enumerable.Empty<BreedModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(breeds);
        }
    }
}
