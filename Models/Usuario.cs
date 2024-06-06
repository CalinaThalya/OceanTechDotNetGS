using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanTechDotNetGS.Models
{
    [Table("tb_octh_usuario")]
    public class Usuario : IModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string email { get; set; } = string.Empty;

        [Required]
        public string senha { get; set; } = string.Empty;

        public RegistroUsuario? RegistroUsuario { get; set; }

        public ICollection<EmpresaUsuario> EmpresaUsuarios { get; set; } = new List<EmpresaUsuario>();
    }
}
