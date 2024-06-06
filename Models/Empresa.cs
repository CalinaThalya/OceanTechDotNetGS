using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanTechDotNetGS.Models
{
    [Table("tb_octh_empresa")]
    public class Empresa : IModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome da Empresa é obrigatório.")]
        public string nomeEmpresa { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório.")]
        public string nomeFantasia { get; set; }= string.Empty;

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public string CNPJ { get; set; }= string.Empty;

        public ICollection<EmpresaUsuario> EmpresaUsuarios { get; set; } = new List<EmpresaUsuario>();
    }
}
