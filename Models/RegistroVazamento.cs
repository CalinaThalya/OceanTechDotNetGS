using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanTechDotNetGS.Models
{
    [Table("tb_octh_registroVazamento")]
    public class RegistroVazamento : IModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataDetecao { get; set; }
        public string TipoSeveridade { get; set; } = string.Empty;
        public string DescricaoVazamento { get; set; } = string.Empty;

        public int? RegistroUsuarioId { get; set; } 

        [ForeignKey("RegistroUsuarioId")]
        public RegistroUsuario? RegistroUsuario { get; set; }
    }
}
