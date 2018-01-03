using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SimpleCalculator.Models
{
    public class Calculation
    {
            public int ID { get; set; }
            [Display(Name = "First Number")]
            public double Param1 { get; set; }
            [Display(Name = "Second Number")]
            public double Param2 { get; set; }
            [StringLength(1)]
            public string Operator { get; set; }
            public double? Result { get; set; }

    }

    public class CalculationDBContext : DbContext
    {
        public DbSet<Calculation> Calculations { get; set; }
    }
}