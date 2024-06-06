using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OceanTechDotNetGS.Models
{public interface IModel

    {
    [Key]
    int Id { get; set; }
    }
}
    