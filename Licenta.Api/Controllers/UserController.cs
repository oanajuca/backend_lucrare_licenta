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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //api/login?username=a&password=b
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage LoginUser(string username, string password)
        {
            var user = _repository.GetUser(username, password);

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);

            }

            return Request.CreateResponse(HttpStatusCode.Forbidden, new MessageDto { Category = "ERROR", Description = "Invalid username or password." });
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("signup")]
        public HttpResponseMessage SignUp(string firstname,string lastname,string username, string email, string role, string password)
        {
            var response = _repository.CreateUser(firstname, lastname, username, email,role, password);

            if (response.Category == Constants.Info)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, response);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("review/{reviewId}")]
        public HttpResponseMessage GetUserReview(int reviewId)
        {
            var userreview = _repository.GetUserReview(reviewId);

            return Request.CreateResponse(HttpStatusCode.OK, userreview);
        }

      //  [EnableCors(origins: "*", headers: "*", methods: "*")]
       // [HttpGet]
      //  [Route("all")]
      //  public HttpResponseMessage GetUserRev()
     //   {
     //       var users = _repository.GetUserRev();
       //     foreach (var item in users)
        //    {
            //    item.Review = _repository.GetReviewUser(Decimal.ToInt32(item.Id));
         //   }
         //   return Request.CreateResponse(HttpStatusCode.OK, users);
       // }

      //  [EnableCors(origins: "*", headers: "*", methods: "*")]
       // [HttpGet]
       // [Route("{id}")]
      //  public HttpResponseMessage GetUserRev(int id)
      //  {
      //      var review = _repository.GetUserRev(id);

        //    review.Review = _repository.GetReviewUser(id);

       //     return Request.CreateResponse(HttpStatusCode.OK, review);
       // }
    }
}

