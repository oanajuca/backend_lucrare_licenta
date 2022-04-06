using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Licenta.Models.Entities
{
    [XmlRoot("trailDescription")]
    public class TrailOverviewModel
    {
        [XmlArray("description")]
        public List<DescriptionEntity> Descriptions { get; set; }
    }
}
