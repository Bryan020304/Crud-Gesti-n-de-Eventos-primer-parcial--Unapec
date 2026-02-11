using System;
using System.ComponentModel.DataAnnotations;

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
    }
}