using Microsoft.AspNetCore.Mvc;
using Narvan.Domains.Sliders.Repositories;
using System.Threading.Tasks;

namespace Narvan.WebApi.Controllers
{

    public class SliderController : BaseController
    {
        private readonly ISliderRepositoryQuery _sliderRepositoryQuery;

        public SliderController(ISliderRepositoryQuery sliderRepositoryQuery)
        {
            _sliderRepositoryQuery = sliderRepositoryQuery;
        }

        [HttpGet("GetActiveSliders")]
        public async Task<IActionResult> GetActiveSliders()
        {
            var sliders = await _sliderRepositoryQuery.GetActiveSlider();
            return Success(sliders);
        }

    }
}
