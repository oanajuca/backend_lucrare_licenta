using Licenta.Interfaces;
using Licenta.Models.Dto;
using Licenta.Models.Entities;
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
    [RoutePrefix("api/review")]
    public class ReviewController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ReviewController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllReviews()
        {
            var review = _repository.GetReview();

            return Request.CreateResponse(HttpStatusCode.OK, review);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("trail/{trailId}")]
        public HttpResponseMessage GetTrailReview(int trailId)
        {
            var review = _repository.GetTrailReview(trailId);

            return Request.CreateResponse(HttpStatusCode.OK, review);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("add/{id}")]
        public HttpResponseMessage AddReview(int id, [FromBody] AddReviewModel trailAddReviewEntity)
        {
            var rev = _repository.AddReview(id, trailAddReviewEntity);

            return Request.CreateResponse(HttpStatusCode.OK, rev);
        }

    }
}
        

