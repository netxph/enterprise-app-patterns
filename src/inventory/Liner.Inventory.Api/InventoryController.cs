using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Liner.Inventory.Api
{
    public class InventoryController
    {

        [FunctionName("Inventory_GetAll")]
        public IActionResult GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "inventory")]
            HttpRequest request)
        {
            return new JsonResult(new
            {
                message = "Hello world"
            });
        }
    }
}
