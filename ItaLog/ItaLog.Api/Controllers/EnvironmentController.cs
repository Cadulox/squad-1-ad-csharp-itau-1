﻿using AutoMapper;
using ItaLog.Api.ViewModels;
using ItaLog.Api.ViewModels.Environment;
using ItaLog.Domain.Interfaces.Models;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ItaLog.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentRepository _repo;
        private readonly IMapper _mapper;
        public EnvironmentController(IEnvironmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a page of environment 
        /// </summary>
        /// <param name="pageFilter">Page filtering object</param>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>         
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult<PageViewModel<EnvironmentViewModel>> GetEnvironments(
        [FromQuery] PageFilter pageFilter)
        {
            var enviromnments = _repo.GetPage(pageFilter);

            return Ok(_mapper.Map<PageViewModel<EnvironmentViewModel>>(enviromnments));
        }

        /// <summary>
        /// Get environment by Id
        /// </summary>
        /// <param name="id">Environment identifier</param>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the environment is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult<EnvironmentViewModel> GetById(int id)
        {
            var env = _mapper.Map<EnvironmentViewModel>(_repo.FindById(id));

            if (env is null)
                return NotFound();

            return Ok(env);
        }

        /// <summary>
        /// Creates an environment
        /// </summary>
        /// <param name="Env">Environment object</param>
        /// <response code="201">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>         
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<EntityBase> Create([FromBody] EnvironmentCreateViewModel Env)
        {
            var newId = _repo.Add(_mapper.Map<Environment>(Env));
            return Created(nameof(GetById), new EntityBase { Id = newId });
        }

        /// <summary>
        /// Update an environment
        /// </summary>
        /// <param name="id"> Environment Id</param>
        /// <param name="env"> Environment object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the environment is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] EnvironmentViewModel env)
        {
            if (env.Id != id)
                return BadRequest();

            if (!_repo.ExistsEntity(id))
                return NotFound();

            _repo.Update(_mapper.Map<Environment>(env));

            return NoContent();
        }

        /// <summary>
        /// Deletes an environment by Id
        /// </summary>
        /// <param name="id"> Environment Id</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the environment is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var envFind = _repo.FindById(id);

            if (envFind is null)
                return NotFound();

            _repo.Remove(id);

            return NoContent();
        }
    }
}