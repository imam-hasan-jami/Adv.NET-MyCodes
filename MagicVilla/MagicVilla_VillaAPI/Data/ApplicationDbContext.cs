using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id=1,
                    Name = "Royal Villa",
                    Details = "Luxury Villa with private pool",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Beach Villa",
                    Details = "Villa with beach view",
                    ImageUrl = "https://balesin.com/wp-content/uploads/elementor/thumbs/The-Balesin-Royal-Villa-Main-Deck_edited-scaled-qazh3d2czzwzp6bozfkerp9ekf95twqmw41hvl9xgs.jpg",
                    Occupancy = 3,
                    Rate = 150,
                    Sqft = 450,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Pool Villa",
                    Details = "Villa with pool view",
                    ImageUrl = "https://www.villaseminyak.net/images/royal-villa-2-bedroom-b.jpg?x",
                    Occupancy = 4,
                    Rate = 180,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Garden Villa",
                    Details = "Villa with garden view",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmgo_9YY6N9i3RPYwR2f8PE0or4f1OM_RbRw&s",
                    Occupancy = 3,
                    Rate = 160,
                    Sqft = 400,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Sea View Villa",
                    Details = "Villa with sea view",
                    ImageUrl = "https://www.ghmhotels.com/wp-content/uploads/5bedroom-exterior-villa.jpg",
                    Occupancy = 4,
                    Rate = 220,
                    Sqft = 600,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
