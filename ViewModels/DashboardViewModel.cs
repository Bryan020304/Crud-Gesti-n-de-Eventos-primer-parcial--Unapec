using EventosCRUD.Models;
using System.Collections.Generic;

namespace EventosCRUD.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalEventos { get; set; }
        public int EventosProximos { get; set; }
        public int EventosFinalizados { get; set; }
        public int TotalAsistentes { get; set; }
        public int CapacidadTotal { get; set; }
        public int PorcentajeOcupacionTotal { get; set; }
        public List<Evento> Eventos { get; set; } = new List<Evento>();
    }
}