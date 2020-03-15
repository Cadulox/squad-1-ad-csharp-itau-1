﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItaLog.Models;
using ItaLog.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ItaLog.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet("{id}", Name= "GetUser")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.FindById(id);
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user is null)
                return BadRequest();

            _userRepository.Add(user);

            return CreatedAtAction("GetUser", new { id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (user is null || user.Id != id)
                return BadRequest();

            var userFind = _userRepository.FindById(id);

            if (userFind is null)
                return NotFound();

            userFind.Name = user.Name;
            userFind.Password = user.Password;
            userFind.Email = user.Email;

            _userRepository.Update(userFind);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userFind = _userRepository.FindById(id);

            if (userFind is null)
                return NotFound();

            _userRepository.Remove(id);

            return new NoContentResult();
        }
    }
}