using InvoiceMs.Models.DTO.External;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvoiceMs.DataClients
{
    public class ShoppingCartMsClients
    {
        private static string ShoppingCartMsEndPoint = "http://localhost:4985";
        private static string ApiBaseAddress = "api/v1/Carts";
        private static HttpClient httpClient = new HttpClient();
        public static async Task<ShoppingCartDTO> GetShoppingCart(int userID)
        {
            string requestURI = $"{ShoppingCartMsEndPoint}/{ApiBaseAddress}/{userID}";
            string cartJSON = await httpClient.GetStringAsync(requestURI);
            return JsonConvert.DeserializeObject<ShoppingCartDTO>(cartJSON);
        }
    }
}
