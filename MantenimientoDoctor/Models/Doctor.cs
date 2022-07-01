using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MantenimientoDoctor.Models
{
    public partial class Doctor
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CodigoPostal { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
