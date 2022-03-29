﻿using Licenta.Interfaces;
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
    [RoutePrefix("api/description")]
    public class DescriptionController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public DescriptionController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllDescriptions()
        {
            var description = _repository.GetDescription();

            return Request.CreateResponse(HttpStatusCode.OK, description);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("trail/{descriptionId}")]
        public HttpResponseMessage GetTrailDescription(int descriptionId)
        {
            var description = _repository.GetTrailDescription(descriptionId);

            return Request.CreateResponse(HttpStatusCode.OK, description);
        }

    }
}