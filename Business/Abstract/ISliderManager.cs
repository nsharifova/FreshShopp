
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderManager
    {

        List<Slider> GetAll();
        void Create(Slider slider);
        Slider GetById(int? id);
        void Update(Slider slider);

        void Delete(Slider slider);
    }
}
