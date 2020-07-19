using System.Collections.Generic;
using System.Threading.Tasks;
using Narvan.Domains.Sliders.Entities;

namespace Narvan.Domains.Sliders.Repositories
{
    public interface ISliderRepositoryQuery
    {
        Task<List<Slider>> GetActiveSlider();
    }
}