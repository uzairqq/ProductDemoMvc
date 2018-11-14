using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using ProductDemoMvc.Attribute;
using ProductDemoMvc.DataModels;
using ProductDemoMvc.Helper;
using ProductDemoMvc.Models;
using ProductDemoMvc.Services;

namespace ProductDemoMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderServices orderServices, ILogger<OrderController> logger)
        {
            _orderServices = orderServices;
            _logger = logger;
        }

        [GenerateAntiforgeryTokenCookieForAjax]
        [HttpGet]
        public ViewResult Add() => View("AddOrder");

        [HttpGet]
        public async Task<ViewResult> All()
        {
            var result = await  _orderServices.Get();
            var map = new OrderGridViewModel()
            {
                Grid = result
            };
           return View("AllOrder", map);
        }

        [HttpPost]
        public async Task<ActionResult> Save(OrderViewModel order)
        {
             await _orderServices.AddAsync(new Order
             {
                 Name = order.Name,
                 CreatedOn = DateTime.Now
             });
            return RedirectToAction("All");
        }
        
    }
}
