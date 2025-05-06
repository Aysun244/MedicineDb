using Microsoft.EntityFrameworkCore;
using SinifTask.Models;
using SinifTask.ViewModel.Slider;

namespace SinifTask.DataAccessLayer
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<SinifTask.ViewModel.Slider.SliderGetVM> SliderGetVM { get; set; } = default!;

    }
}
