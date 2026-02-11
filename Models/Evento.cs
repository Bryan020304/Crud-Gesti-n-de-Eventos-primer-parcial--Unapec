using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosCRUD.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Evento")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El lugar es obligatorio")]
        [Display(Name = "Lugar")]
        public string Lugar { get; set; }

        [Required(ErrorMessage = "Los asistentes son obligatorios")]
        [Range(0, 1000, ErrorMessage = "Debe ser entre 0 y 1000")]
        [Display(Name = "Asistentes Registrados")]
        public int AsistentesRegistrados { get; set; }

        [Required(ErrorMessage = "La capacidad es obligatoria")]
        [Range(1, 1000, ErrorMessage = "Debe ser entre 1 y 1000")]
        [Display(Name = "Capacidad Máxima")]
        public int CapacidadMaxima { get; set; }

        // PROPIEDADES DE INTELIGENCIA DE NEGOCIOS (calculadas)
        [NotMapped] // No se guarda en la BD
        [Display(Name = "Lugares Disponibles")]
        public int LugaresDisponibles => CapacidadMaxima - AsistentesRegistrados;

        [NotMapped]
        [Display(Name = "Porcentaje Ocupación")]
        public string PorcentajeOcupacion =>
            CapacidadMaxima > 0 ? $"{(AsistentesRegistrados * 100 / CapacidadMaxima)}%" : "0%";

        [NotMapped]
        [Display(Name = "Estado")]
        public string Estado
        {
            get
            {
                if (Fecha < DateTime.Today)
                    return "Finalizado";
                if (Fecha.Date == DateTime.Today.Date)
                    return "Hoy";
                if (Fecha <= DateTime.Today.AddDays(7))
                    return "Próximo";
                return "Programado";
            }
        }

        [NotMapped]
        [Display(Name = "Disponibilidad")]
        public string Disponibilidad
        {
            get
            {
                if (LugaresDisponibles <= 0)
                    return "Agotado";
                if (LugaresDisponibles <= 10)
                    return "Últimos lugares";
                return "Disponible";
            }
        }
    }
}