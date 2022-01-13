using System;
using System.Collections.Generic;
using Indra.Domain.Entities;

namespace Indra.Web.Dto
{
    // This class will only have the connection from the frount and the backend
    public class StudentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public static StudentEntity MapToStudentEntity(StudentDto student)
        {
            return new StudentEntity
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday
            };
        }

        public static StudentDto MapFromStudentEntity(StudentEntity student)
        {
            return new StudentDto
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday
            };
        }

        public static IEnumerable<StudentDto> MapFromStudentEntityList(IEnumerable<StudentEntity> studentEntities)
        {
            List<StudentDto> studentDTOs = new List<StudentDto>();
            foreach (var student in studentEntities)
            {
                studentDTOs.Add(MapFromStudentEntity(student));
            }
            return studentDTOs;
        }
    }
}