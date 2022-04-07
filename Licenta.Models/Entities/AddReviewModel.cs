using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Licenta.Models.Entities
{
    [XmlRoot("")]
    public class AddReviewModel
    {
        [XmlElement("trailId")]
        public int TrailId { get; set; }

        [XmlArray("reviews")]
        public List<ReviewEntity> Reviews { get; set; }
    }
}

