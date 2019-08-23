
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace api.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {  // GET api/configuration
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string novi = "";
            string path = @"C:\Users\omera\OneDrive\Desktop\examination\task\cache.json"; 

            if (System.IO.File.Exists(path))
            {
                novi = System.IO.File.ReadAllText(path);
                Data user = JsonConvert.DeserializeObject<Data>(novi.ToString());
                novi =  " displayinfo { id: " + user.displays[0].id + "  refresh_rate: "  + user.displays[0].refresh_rate + " manufacturer: " + user.displays[0].refresh_rate + " }  applicationInfo { name: "
                + user.displays[0].applications[0].name + " runtime: " + user.displays[0].applications[0].runtime + " url: " + user.displays[0].applications[0].url + "}";
               
            }
          
            return new string[] { novi };
        }
    }
}