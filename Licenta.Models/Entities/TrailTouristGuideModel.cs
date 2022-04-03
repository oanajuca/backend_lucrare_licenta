using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Licenta.Models.Entities
{
    public class TrailTouristGuideModel
    {
        [XmlElement("trailId")]
        public int TrailId { get; set; }

        [XmlArray("")]
        public List<TouristGuideEntity> TouristGuides { get; set; }
    }
}

