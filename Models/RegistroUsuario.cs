using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OceanTechDotNetGS.Models
{
    [Table("tb_octh_registroUsuario")]
    public class RegistroUsuario : IModel
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public ICollection<RegistroVazamento> RegistroVazamentos { get; set; } = new List<RegistroVazamento>();
    }
}
