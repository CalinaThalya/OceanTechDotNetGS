using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OceanTechDotNetGS.Models;

    public class NomeDoSeuContexto : DbContext
    {
        public NomeDoSeuContexto (DbContextOptions<NomeDoSeuContexto> options)
            : base(options)
        {
        }

        public DbSet<OceanTechDotNetGS.Models.RegistroVazamento> RegistroVazamento { get; set; } = default!;
    }
