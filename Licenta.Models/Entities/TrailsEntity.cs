using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models.Entities
{
    public class TrailsEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Location { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }
        public string Mark { get; set; }
        public List<DifficultyEntity> TrailDifficulty { get; set; }
        public List<DescriptionEntity> Description { get; set; }
        public List<ReviewEntity> TrailReview { get; set; }
        public List<TouristGuideEntity> TrailTouristGuide { get; set; }
    }
}
