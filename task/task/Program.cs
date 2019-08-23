using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using SocketIOClient;
using task;
using System.Diagnostics;
using url.Model;
using System.Web.Mvc;

class Program
{
  

    static void Main(string[] args)
    {

       GetRequest("http://localhost:3000/api/device/configuration");//generiranje cache.json na samo pokretanje aplikacije (task2)

      // gettingApi().Wait(); //taskovi 3 i 4 

      // Test().Wait(); //task 5


        Console.ReadKey();
    }
    public static class UrlPoredjenje
    {
        public static string url { get; set; }
    }
    [HttpGet]
    async static void GetRequest(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                using (HttpContent content = response.Content)
                {
                    string myContent =  await content.ReadAsStringAsync();



                    if (myContent.Length > 0){
                        //upisivanje objekta u folder task preko system.io.file
                       
                        File.WriteAllText(@"C:\Users\omera\OneDrive\Desktop\examination\task\cache.json", myContent); 
                    }
                    else
                    {
                       //ukoliko se ništa ne upiše vraćen je null iz index.jsa, potrebno je ponovo podići koznol app ->f5
                        Console.WriteLine("start console app again");

                    }
                   
                    Console.WriteLine(myContent + "\n"); // provjera da li je isti fajl koji se generiše u index.js-u sa onim u chace.json-u 
                  
                }
            }
        }
    }


    //dodan novi api projekt untar folder nsoft_tasks pod nazivom api
    //prije pokretanja ove aplikacije potrebno prvo pokrenuti server iz ovog foldra
    // napravljen get request na prvi kontroler api/conffiguration iz kojeg
    //dohvaćam objekat koji je spremljen u chace.json i prikazujem u konzoli
    // drugi ckontroler api/start_aplication poslužuje url iz objekta koji se nalazi u cache.json
    [HttpGet]
    static async Task gettingApi()
    {
        using (var cli = new HttpClient())
        {
            cli.BaseAddress = new Uri("http://localhost:57671");
            cli.DefaultRequestHeaders.Accept.Clear();
            cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            // prvi endpoint get na api/configuration koji dohvata objekat koji se nalazi u chace.json-u
            string res = await cli.GetStringAsync("api/configuration");
            ////drugi endpoint koji pokreće chrome service na link koji se nalazi u objektu
            string gettingProceses = await cli.GetStringAsync("api/start_application");

          
                Console.WriteLine(res + "\n");

            string novi = gettingProceses.Replace(@"[", "");
            string novi2 = novi.Replace(@"]", "");
           // Console.WriteLine(novi2);
            UrlPoredjenje.url = novi2;
            var ps = new ProcessStartInfo(novi2)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
    }

        [HttpOptions]
        static async Task Test()
        {
            var client = new SocketIO("http://localhost:3001");
          // slušanje state message na portu 3001 i primanje objekta 
            client.On("state", args => {
                string json = args.Text;

                //kreiranje objekta da poredim urlove kako bi pokrenuo novi proces tj novi url
                KreirajObj us = JsonConvert.DeserializeObject<KreirajObj>(json);
                string path = @"C:\Users\omera\OneDrive\Desktop\examination\task\cache.json";
                string novi = File.ReadAllText(path);
                CacheJson izFajla = JsonConvert.DeserializeObject<CacheJson>(novi);
                if (us.data != null)
                {
                    string str2 = izFajla.displays[0].applications[0].url;
                    string str1 = us.data.displays[0].applications[0].url;
                    
                    if (!(str2.Equals(str1)))
                    {

                        var ps = new ProcessStartInfo(str1)
                        {
                            UseShellExecute = true,
                            Verb = "open"
                        };
                        Process.Start(ps);
                        foreach (var process in Process.GetProcessesByName(str1))
                        {
                            process.Kill();
                            Console.WriteLine("kraj");
                        }
                    }
                }

            });

            await client.ConnectAsync();

            client.OnConnected += async () =>
            {
                //await Task.Delay(3000);
                await client.EmitAsync("state", "cb");
             
            };
       
        }


}


    


