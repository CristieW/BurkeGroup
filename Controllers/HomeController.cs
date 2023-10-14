using BurkeGroup.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RestSharp;
using Newtonsoft.Json;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using Elmah.ContentSyndication;
using System.Linq;
using System.Text.Json.Serialization;

namespace BurkeGroup.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string ApiUrl = "https://api.shopmonkey.io/v2/orders";
        private List<ShopModel> shops = new List<ShopModel>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            shops.Add(new ShopModel() { Id=1, Name="SterlingHeights", PrivateKey = "r3fm4MOXebxlc7AWgWJIdjjZW5JOvJ0g", PublicKey= "vO8rwnt8VA" });
            shops.Add(new ShopModel() { Id = 2, Name = "GrandRapids", PrivateKey = "r3fm4MOXebxlc7AWgWJIdjjZW5JOvJ0g", PublicKey = "vO8rwnt8VA" });
            shops.Add(new ShopModel() { Id = 3, Name = "Pittsburgh(cochrans)", PrivateKey = "r3fm4MOXebxlc7AWgWJIdjjZW5JOvJ0g", PublicKey = "vO8rwnt8VA" });
            shops.Add(new ShopModel() { Id = 4, Name = "Farmington Hills", PrivateKey = "r3fm4MOXebxlc7AWgWJIdjjZW5JOvJ0g", PublicKey = "vO8rwnt8VA" });
            shops.Add(new ShopModel() { Id = 5, Name = "Taylor", PrivateKey = "r3fm4MOXebxlc7AWgWJIdjjZW5JOvJ0g", PublicKey = "vO8rwnt8VA" });

        }


       
        public async Task<IActionResult> Index(int? selectedShopId)
            {
            int shopId = selectedShopId ?? 1;
            int shopIndex = shopId - 1;
            //Gets Barer Token
            var optionsToken = new RestClientOptions("https://api.shopmonkey.io/v2/token");
            var clientToken = new RestClient(optionsToken);
            var requestToken = new RestRequest("");
            requestToken.AddHeader("accept", "text/html");
            requestToken.AddJsonBody("{\"publicKey\":\"" + shops[shopIndex].PublicKey +"\",\"privateKey\":\""+shops[shopIndex].PrivateKey + "\"}", false);
            var responseToken = await clientToken.PostAsync(requestToken);
            var token = responseToken.Content;

            // Create a RestSharp client and specify the API endpoint
            var options = new RestClientOptions("https://api.shopmonkey.io/v2/orders");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("authorization", "Bearer " + token);
            var response = client.Execute(request);

           
            DateTime lastWeek = DateTime.Now.AddDays(-7);
           
            

            List<APIData> itemList = client.Execute<List<APIData>>(request).Data;
            List<APIData> filteredList = itemList
                .Where(item => item.UpdateDate <= lastWeek)
                //.Where(item => item.IsArchived  == false)
              // .Where(item => item.IsAuthorized == false)
               .OrderByDescending(item => item.TotalAmount)
                .ToList();

         




            
           
            

            return View(filteredList);


           

        }
    }



}
