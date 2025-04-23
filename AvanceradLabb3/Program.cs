
using AvanceradLabb3.Data;
using AvanceradLabb3.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AvanceradLabb3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IPersonRepo, PersonRepo>();
            builder.Services.AddScoped<IInterestRepo, InterestRepo>();
            builder.Services.AddScoped<ILinkRepo, LinkRepo>();
            builder.Services.AddDbContext<InterestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

/*
 
<aside>
?? **Applikationen/databasen**

Din första uppgift är att skapa ett grundläggande API med en databas som har följande funktioner:

- [ ]  Det ska gå att lagra personer med grundläggande information om dem som namn och telefonnummer
- [ ]  Systemet ska kunna lagra ett obegränsat antal intressen. Varje intresse ska ha en titel och en kort beskrivning
- [ ]  Varje person ska kunna kopplas till valfritt antal intressen
- [ ]  Det ska gå att lagra ett obegränsat antal länkar till webbplatser för varje intresse och person. En länk är alltid kopplad till både personen och intresset
</aside>

<aside>
?? **Skapa ett REST-API**

Det andra steget är att skapa ett REST-API som låter externa tjänster utföra följande operationer i din applikation:

- [ ]  Hämta alla personer i systemet
- [ ]  Hämta alla intressen kopplade till en specifik person
- [ ]  Hämta alla länkar kopplade till en specifik person
- [ ]  Koppla en person till ett nytt intresse
- [ ]  Lägga till nya länkar för en specifik person och ett specifikt intresse
</aside>

<aside>
<img src="/icons/zoom-in_green.svg" alt="/icons/zoom-in_green.svg" width="40px" /> **Extra utmaning (gör om du vill)**

- [ ]  Gör det möjligt för API-anrop som hämtar en person att direkt få ut alla personens intressen och länkar i en hierarkisk JSON-struktur
- [ ]  Lägg till filtreringsfunktion i API:et. Till exempel, om man skickar med "to" vid hämtning av personer ska man få träffar på namn som innehåller "to", som "Tobias" eller "Tomas". Du kan implementera denna funktion för alla API-anrop om du vill.
- [ ]  Implementera paginering i API:et. Till exempel, vid hämtning av personer kan man få de första 100 personerna och behöver göra ytterligare anrop för att få fler. Låt anropet specificera hur många personer som ska returneras per sida – användaren kan då välja att få exempelvis 10 personer per anrop.
</aside>

<aside>
??? **Testa ditt API**

Det sista steget är att testa ditt API genom antingen [Postman](https://www.postman.com/) eller Swagger.

- [ ]  Gör ett testanrop för varje API-krav som listats ovan
- [ ]  Dokumentera alla testanrop i din readme-fil på GitHub så att vi kan se din tänkta struktur för API-anropen
</aside>

<aside>
?

**För VG**

- [ ]  Skriv en reflektion över hur du har tillämpat SOLID principles i din applikation, lämna in denna som en pdf tillsammans med länken till ditt GitHub-repo på LearnPoint.
</aside>
 
 */

// Repository pattern - klass som sköter kommunikation med databasen