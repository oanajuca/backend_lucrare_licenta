using Licenta.Interfaces;
using Licenta.Models.Dto;
using Licenta.Models.Entities;
using System;
using Licenta.Infrastructure.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Licenta.Api.Controllers
{
    [AllowCrossSiteJson]
    [RoutePrefix("api/touristguide")]
    public class TouristGuideController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TouristGuideController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllGuides()
        {
            var guide = _repository.GetGuide();

            return Request.CreateResponse(HttpStatusCode.OK, guide);
        }
       
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("save/{id}")]
       
        public HttpResponseMessage SaveTouristGuide(int id, [FromBody] TrailTouristGuideModel trailTouristGuideEntity)
        {
            var ghid = _repository.SaveTouristGuide(id, trailTouristGuideEntity);

            return Request.CreateResponse(HttpStatusCode.OK, ghid);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("addnewguide")]
        public HttpResponseMessage NewTrailGuide(int trailid, int guideid)
        {
            var response = _repository.CreateTrailGuide(trailid,guideid);

            if (response.Category == Constants.Info)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, response);
        }

    }
}