1. Otvorite test-exam-server i uradite npm i(node_modules izbrisan pa ponovo kreirajte dependencies)
2. Kucajte node index.js
3. Otvorite task folder i task.sln zatim api.sln
4. U task.sln i api.sln namjestiti lokaciju u 
File.WriteAllText(filename->lokacija na vašem racunaru,json); isto i za read u api.sln
System.IO.File.ReadAllText(path->lokacija na vašem racunaru gdje je spremljen cache.json)
4. f5 za ispunjavenje taska 2, provjerite da li je generisan cache.json
5. Komentarišite funkciju u mainu GetRequest(url); 
6. Odkomentarišite gettingApi().Wait(); za izvršavanje taskova 3 i 4 
8. Prije pokretanja sa f5, podignite web server koji se nalazi u folderu api, otvorite fajl i pritisnite f5
zatim pokrenite konzolnu aplikaciju 
7. Funkcije GetRequest(url) i gettingApi().Wait(); nek stoje komentarisane i za task 5 odkomentarišite 
Test().Wait();

Dependecies u console app (nuget paketi):
1. Microsoft.AspNet.Mvc 5.2.7
2. SocketIOClient version 1.0.2.1
3 za task.sln defaultni

Using Visual Studio 2019 

Microsoft.Net Core SDK - 2.2.401(x64) 
Microsoft.Net Core SDK - 2.1.202(x64) 
Microsoft.Net Core SDK - 2.1.502(x64)  
Microsoft.Net Core SDK - 2.1.503(x64)
Microsoft.Net Core SDK - 2.1.508(x64)
Microsoft.Net Core SDK - 2.1.801(x64)
Microsoft.Net Framework 4.5.1 SDK 