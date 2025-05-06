using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinifTask.DataAccessLayer;
using SinifTask.Models;
using SinifTask.ViewModel.Slider;

namespace SinifTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(TaskDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Slider> datas =await _context.Sliders.ToListAsync();                        
            List<SliderGetVM> slider = [];
            foreach (var item in datas)
            {
                slider.Add(new SliderGetVM()
                {
                   
                    Id = item.Id,
                    Title = item.Title,                  
                    ImageUrl = item.ImageUrl,
                });
            }
            return View(slider);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderGetVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Slider slider = new();
            slider.Description = model.Description;
            slider.Title = model.Title;         
            slider.ImageUrl = model.ImageUrl;
         await   _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value < 1) return BadRequest();
          
            return RedirectToAction(nameof(Index));
        }
    }
}
