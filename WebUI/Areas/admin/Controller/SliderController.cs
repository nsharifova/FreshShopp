using Business.Abstract;
using EducalProjectT210.Helpers;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class SliderController : Controller
    {
        private readonly ISliderManager _sliderManager;
        private readonly IWebHostEnvironment _environment;
        

        public SliderController(ISliderManager sliderManager, IWebHostEnvironment environment)
        {
            _sliderManager = sliderManager;
            _environment = environment;
        }

        // GET: SliderController
        public ActionResult Index()
        {
            return View(_sliderManager.GetAll());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View(_sliderManager.GetById(id));
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Slider slider, IFormFile Image)
        {

            string photoName = PictureHelper.UploadPicture(Image, _environment);
            slider.PhotoUrl = photoName;

            _sliderManager.Create(slider);
            return RedirectToAction(nameof(Index));

           
          
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_sliderManager.GetById(id));
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, Slider slider, string OldPhoto, IFormFile Image)
        {
            
         try
            {

                if (Image != null)
                {
                    string photoName = PictureHelper.UploadPicture(Image, _environment);
                    slider.PhotoUrl = photoName;
                }
                else
                {
                    slider.PhotoUrl = OldPhoto;
                }
                _sliderManager.Update(slider);

               }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int? id)
        {
           

            return View();
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Slider slider)
        {
            if (id == null) return NotFound();
            if (slider == null) return NotFound();
            try
            {
                _sliderManager.Delete(slider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
