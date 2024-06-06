using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OceanTechDotNetGS.Models
{[Table("tb_octh_empresaUsuario")]
    public class EmpresaUsuario
    {
         [Key]
    public int EmpresaUsuarioId { get; set; }

    public int EmpresaId { get; set; }
    public Empresa? Empresa { get; set; }

    public int UsuarioId { get; set; }
    public required Usuario Usuario { get; set; }
    }
}