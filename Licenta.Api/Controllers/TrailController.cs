using Licenta.Interfaces;
using Licenta.Models.Dto;
using Licenta.Infrastructure.Wrappers;
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
        [RoutePrefix("api/trail")]
        public class TrailController : ApiController
        {
            private readonly IRepository _repository;

            public TrailController(IRepository repository)
            {
                _repository = repository;
            }

            [EnableCors(origins: "*", headers: "*", methods: "*")]
            [HttpGet]
            [Route("all")]
            public HttpResponseMessage GetTrail()
            {
                var trails = _repository.GetTrail();
                foreach (var item in trails)
                {

                    item.TrailReview = _repository.GetTrailReview(Decimal.ToInt32(item.Id));
                    item.Description = _repository.GetTrailDescription(Decimal.ToInt32(item.Id));
                item.TrailTouristGuide = _repository.GetTrailTouristGuide(Decimal.ToInt32(item.Id));

            }
                return Request.CreateResponse(HttpStatusCode.OK, trails);
            }

            [EnableCors(origins: "*", headers: "*", methods: "*")]
            [HttpGet]
            [Route("{id}")]
            public HttpResponseMessage GetTrail(int id)
            {
                var trails = _repository.GetTrail(id);
            trails.TrailReview = _repository.GetTrailReview(id);
            trails.Description = _repository.GetTrailDescription(id);
            trails.TrailTouristGuide = _repository.GetTrailTouristGuide(id);

            return Request.CreateResponse(HttpStatusCode.OK, trails);
            }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("addnew")]
        public HttpResponseMessage NewTrail(string name, string location, string distance, string time, string mark, string map, string difficulty)
        {
            var response = _repository.CreateTrail(name, location, distance, time, mark, map, difficulty);

            if (response.Category == Constants.Info)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, response);
        }

    }
}

