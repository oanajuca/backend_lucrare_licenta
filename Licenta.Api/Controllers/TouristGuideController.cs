using Licenta.Interfaces;
using Licenta.Models.Dto;
using System;
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
        [HttpGet]
        [Route("trail/{trailId}")]
        public HttpResponseMessage GetTrailTouristGuide(int trailId)
        {
            var guide = _repository.GetTrailTouristGuide(trailId);

            return Request.CreateResponse(HttpStatusCode.OK, guide);
        }
    }
}