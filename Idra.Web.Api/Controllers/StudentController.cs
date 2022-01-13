using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indra.Web.Dto;
using Microsoft.AspNetCore.Mvc;

using Indra.Web.Dto;

using Indra.Application.services.Interfaces;
using Indra.Domain.Entities;
using WebApplication.JwtHelpers;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Idra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            var res = await _studentService.GetAll();
            return StudentDto.MapFromStudentEntityList(res);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<StudentDto> Get(int id)
        {
            var res = await _studentService.Get(id);
            return StudentDto.MapFromStudentEntity(res);
        }

        // POST api/<StudentController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<StudentDto> Post([FromBody] StudentDto studentDto)
        {
            var res = await _studentService.Insert(StudentDto.MapToStudentEntity(studentDto));
            return StudentDto.MapFromStudentEntity(res);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<StudentDto> Put(int id, [FromBody] StudentDto studentDto)
        {
            var res = await _studentService.Update(id, StudentDto.MapToStudentEntity(studentDto));
            return StudentDto.MapFromStudentEntity(res);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<StudentDto> Delete(int id)
        {
            var res = await _studentService.Remove(id);
            return StudentDto.MapFromStudentEntity(res);
        }
    }
}