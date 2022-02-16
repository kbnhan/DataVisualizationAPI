using System;
using System.Collections.Generic;

namespace DataVisualizationAPI.Models
{
    public partial class FairMarketRent
    {
        public int Id { get; set; }
        public decimal Rent { get; set; }
        public short Year { get; set; }
        public string Bedrooms { get; set; } = null!;
        public string Areaname { get; set; } = null!;
        public string State { get; set; } = null!;
        public string? Pmsaname { get; set; }
        public int? Pop2017 { get; set; }
    }
}
