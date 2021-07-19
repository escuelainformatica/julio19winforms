namespace Julio19.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        [StringLength(40)]
        public string Usuario { get; set; }

        [StringLength(64)]
        public string Clave { get; set; }

        [StringLength(200)]
        public string NombreCompleto { get; set; }
    }
}
