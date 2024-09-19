using Microsoft.EntityFrameworkCore;
using UndergroundFootballStadium_UFSAPI.Models;

namespace UndergroundFootballStadium_UFSAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UFS> UFSs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UFS>().HasData(
                new UFS()
                {
                    Id = 1,
                    Name = "Kings Arena",
                    Details = "Mirpur UFS is a football stadium located in Mirpur, Dhaka, Bangladesh. It is the home of the Bangladesh national football team and Abahani Limited Dhaka. The stadium goes by the nickname 'The Cauldron'.",
                    ImageUrl = "",
                    Occupancy = 10,
                    Rate = 5000,
                    Sqft = 10000,
                    Amenity = "Football",
                    CreatedDate = DateTime.Now
                },
                new UFS()
                {
                    Id = 2,
                    Name = "Old Trafford",
                    Details = "Old Trafford is a football stadium in Old Trafford, Greater Manchester, England, and the home of Manchester United. With a capacity of 74,140 seats, it is the largest club football stadium in the United Kingdom, and the eleventh-largest in Europe.",
                    ImageUrl = "",
                    Occupancy = 5,
                    Rate = 25000,
                    Sqft = 12000,
                    Amenity = "Football",
                    CreatedDate = DateTime.Now
                },
                new UFS()
                {
                    Id = 3,
                    Name = "Camp Nou",
                    Details = "Camp Nou is the home stadium of FC Barcelona since its completion in 1957. With a seating capacity of 99,354, it is the largest stadium in Spain and Europe, and the third largest football stadium in the world in capacity.",
                    ImageUrl = "",
                    Occupancy = 7,
                    Rate = 2000,
                    Sqft = 15000,
                    Amenity = "Football",
                    CreatedDate = DateTime.Now
                },
                new UFS()
                {
                    Id = 4,
                    Name = "Santiago Bernabeu",
                    Details = "The Santiago Bernabéu Stadium is a football stadium in Madrid, Spain. With a current seating capacity of 81,044, it has been the home stadium of Real Madrid since its completion in 1947.",
                    ImageUrl = "",
                    Occupancy = 2,
                    Rate = 60000,
                    Sqft = 18000,
                    Amenity = "Football",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
