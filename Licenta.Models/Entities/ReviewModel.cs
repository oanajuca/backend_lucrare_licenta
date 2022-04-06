using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Licenta.Models.Entities
{
    [XmlRoot("review")]
    public class ReviewModel
    {
        [XmlElement("trailId")]
        public int TrailId { get; set; }
        [XmlArray("review")]
        public List<ReviewEntity> Review { get; set; }
    }
}

