using CloudinaryDotNet.Actions;
using CRM.Application.Modelos.Authorization;
using CRM.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Persistence
{
    public class CRMDbContextData
    {
        public static async Task LoadDataAsync(
        CRMDbContext context,
        UserManager<Usuario> usuarioManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory
    )
        {

            try
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(RoleAuth.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(RoleAuth.USER));
                }


                if (!usuarioManager.Users.Any())
                {
                    var usuarioAdmin = new Usuario
                    {
                        Nombres = "ELIEZER",
                        Apellidos = "COCOM",
                        CorreoElectronico = "e.cocom@gmail.com",
                        UserName = "e.cocom",
                        NumeroTelefono = "985644644",
                        UrlImagen = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24",
                    };
                    await usuarioManager.CreateAsync(usuarioAdmin, "PasswordECC123$");
                    await usuarioManager.AddToRoleAsync(usuarioAdmin, RoleAuth.ADMIN);
                }

                if (!context.Categorias!.Any())
                {
                    var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                    var categories = JsonConvert.DeserializeObject<List<Categoria>>(categoryData);
                    await context.Categorias!.AddRangeAsync(categories!);
                    await context.SaveChangesAsync();
                }

                if (!context.Paises!.Any())
                {
                    var countryData = File.ReadAllText("../Infrastructure/Data/countries.json");
                    var countries = JsonConvert.DeserializeObject<List<Pais>>(countryData);
                    await context.Paises!.AddRangeAsync(countries!);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                var logger = loggerFactory.CreateLogger<CRMDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}
