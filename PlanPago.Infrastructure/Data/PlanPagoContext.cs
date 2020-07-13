using Microsoft.EntityFrameworkCore;
using PagoPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanPago.Infrastructure.Data
{
    public class PlanPagoContext : DbContext
    {
        public PlanPagoContext(DbContextOptions<PlanPagoContext> option): base(option)
        {
        }

        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Plan> PlanesPagos { get; set; }
    }
}
