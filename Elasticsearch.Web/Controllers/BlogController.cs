﻿using Elasticsearch.Web.Services;
using Elasticsearch.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Search()
        {

            return View(await _blogService.SearchAsync(string.Empty));
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchText)
        {

            ViewBag.searchText = searchText;

            return View(await _blogService.SearchAsync(searchText));
        }
        public IActionResult Save()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlogCreateViewModel model)
        {

            var isSucces = await _blogService.SaveAsync(model);

            if (!isSucces)
            {
                TempData["result"] = "kayıt başarısız";
                return RedirectToAction(nameof(BlogController.Save));
            }


            TempData["result"] = "kayıt başarılı";
            return RedirectToAction(nameof(BlogController.Save));
        }
    }
}
