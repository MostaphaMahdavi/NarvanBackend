using Narvan.Domains.Commons;

namespace Narvan.Domains.Sliders.Entities
{
    public class Slider:BaseEntity
    {
        #region Propertise

        public string Title { get; set; }
        public string Description { get; set; }

        public string ImageName { get; set; }
        public string Link { get; set; }

        #endregion
    }
}