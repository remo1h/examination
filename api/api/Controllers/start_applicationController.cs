using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class start_applicationController : ControllerBase
    {
    
     
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string novi = "";
            string path = @"C:\Users\omera\OneDrive\Desktop\examination\task\cache.json"; // pazite na putanje ne rade mi defaultne

            if (System.IO.File.Exists(path))
            {
                novi = System.IO.File.ReadAllText(path);
                Data user = JsonConvert.DeserializeObject<Data>(novi.ToString());
                //serviramo sa apija na konzolnu aplikaciju link iz cache.json
                novi = user.displays[0].applications[0].url;

            }

            return new string[] { novi };
        }
    }
}
