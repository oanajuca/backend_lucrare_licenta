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
    [RoutePrefix("api/difficulty")]
    public class DifficultyController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public DifficultyController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllDifficulties()
        {
            var difficulty = _repository.GetDifficulty();

            return Request.CreateResponse(HttpStatusCode.OK, difficulty);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("trail/{trailId}")]
        public HttpResponseMessage GetTrailDifficulty(int trailId)
        {
            var difficulty = _repository.GetTrailDifficulty(trailId);

            return Request.CreateResponse(HttpStatusCode.OK, difficulty);
        }

    }
}
