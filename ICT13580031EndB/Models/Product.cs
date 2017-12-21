using System;
using SQLite;
namespace ICT13580031EndB.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Name { get; set; }



        [NotNull]
		[MaxLength(100)]
		public string Category { get; set; }

        [NotNull]
        public string Brand { get; set; }

        public string Generation { get; set; }

        public int Year { get; set; }

        public string Mileage { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Province { get; set; }

        public string TelephoneNumber { get; set; }

    }
}
