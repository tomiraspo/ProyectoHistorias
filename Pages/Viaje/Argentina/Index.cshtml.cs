using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using HistoriasPais.Services;

namespace HistoriasPais.Pages.Argentina
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseService _databaseService;

        public List<string> Ciudades { get; set; } = new();

        public IndexModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void OnGet()
        {
            Ciudades = _databaseService.ObtenerCiudadesPorPais("Argentina");
        }
    }
}
