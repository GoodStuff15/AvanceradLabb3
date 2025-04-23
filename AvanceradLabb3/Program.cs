
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

Din f�rsta uppgift �r att skapa ett grundl�ggande API med en databas som har f�ljande funktioner:

- [ ]  Det ska g� att lagra personer med grundl�ggande information om dem som namn och telefonnummer
- [ ]  Systemet ska kunna lagra ett obegr�nsat antal intressen. Varje intresse ska ha en titel och en kort beskrivning
- [ ]  Varje person ska kunna kopplas till valfritt antal intressen
- [ ]  Det ska g� att lagra ett obegr�nsat antal l�nkar till webbplatser f�r varje intresse och person. En l�nk �r alltid kopplad till b�de personen och intresset
</aside>

<aside>
?? **Skapa ett REST-API**

Det andra steget �r att skapa ett REST-API som l�ter externa tj�nster utf�ra f�ljande operationer i din applikation:

- [ ]  H�mta alla personer i systemet
- [ ]  H�mta alla intressen kopplade till en specifik person
- [ ]  H�mta alla l�nkar kopplade till en specifik person
- [ ]  Koppla en person till ett nytt intresse
- [ ]  L�gga till nya l�nkar f�r en specifik person och ett specifikt intresse
</aside>

<aside>
<img src="/icons/zoom-in_green.svg" alt="/icons/zoom-in_green.svg" width="40px" /> **Extra utmaning (g�r om du vill)**

- [ ]  G�r det m�jligt f�r API-anrop som h�mtar en person att direkt f� ut alla personens intressen och l�nkar i en hierarkisk JSON-struktur
- [ ]  L�gg till filtreringsfunktion i API:et. Till exempel, om man skickar med "to" vid h�mtning av personer ska man f� tr�ffar p� namn som inneh�ller "to", som "Tobias" eller "Tomas". Du kan implementera denna funktion f�r alla API-anrop om du vill.
- [ ]  Implementera paginering i API:et. Till exempel, vid h�mtning av personer kan man f� de f�rsta 100 personerna och beh�ver g�ra ytterligare anrop f�r att f� fler. L�t anropet specificera hur m�nga personer som ska returneras per sida � anv�ndaren kan d� v�lja att f� exempelvis 10 personer per anrop.
</aside>

<aside>
??? **Testa ditt API**

Det sista steget �r att testa ditt API genom antingen [Postman](https://www.postman.com/) eller Swagger.

- [ ]  G�r ett testanrop f�r varje API-krav som listats ovan
- [ ]  Dokumentera alla testanrop i din readme-fil p� GitHub s� att vi kan se din t�nkta struktur f�r API-anropen
</aside>

<aside>
?

**F�r VG**

- [ ]  Skriv en reflektion �ver hur du har till�mpat SOLID principles i din applikation, l�mna in denna som en pdf tillsammans med l�nken till ditt GitHub-repo p� LearnPoint.
</aside>
 
 */

// Repository pattern - klass som sk�ter kommunikation med databasen