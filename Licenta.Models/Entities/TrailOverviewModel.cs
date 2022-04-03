using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Licenta.Models.Entities
{
    public class TrailOverviewModel
    {
        [XmlArray("")]
        public List<DescriptionEntity> Descriptions { get; set; }
    }
}
