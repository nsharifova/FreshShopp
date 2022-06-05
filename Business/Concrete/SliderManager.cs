using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class SliderManager : ISliderManager
    {
        private readonly FreshDbContext _context;

        public SliderManager(FreshDbContext context)
        {
            _context = context;
        }

        public void Create(Slider slider)
        {
           
            _context.Sliders.Add(slider);
            _context.SaveChanges();
        }

        public void Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
        }

        public List<Slider> GetAll()
        {
            var slider = _context.Sliders.ToList();
            return slider;
        }

        public Slider GetById(int? id)
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            return slider;
        }

        public void Update(Slider slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
        }

    }
}
