using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebAplicacion.Models;

namespace WebAplicacion.Pages.Viaje.Portugal
{
    public class HistoriaModel : PageModel
    {
        public List<Ciudad> Ciudades { get; set; } = new();

        public void OnGet()
        {
            var rutaJson = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "portugal.json");
            if (System.IO.File.Exists(rutaJson))
            {
                var json = System.IO.File.ReadAllText(rutaJson);
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Ciudades = JsonSerializer.Deserialize<List<Ciudad>>(json, opciones) ?? new();
            }
        }
    }
}
