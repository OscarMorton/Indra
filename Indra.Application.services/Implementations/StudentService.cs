using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapgeminiUnitOfWork.Infrastructure.Repository.DataContext.Generic;
using Indra.Application.services.Interfaces;
using Indra.Domain.Entities;
using Indra.Infrastructure.Repository;

namespace Indra.Application.services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentEntity> Get(int id)
        {
            var repositoryResult = await _studentRepository.GetByIdAsync(id);
            return StudentEntity.MapFromStudentModel(repositoryResult);
        }

        public async Task<IEnumerable<StudentEntity>> GetAll()
        {
            var repositoryResult = await _studentRepository.GetAllAsync();
            return StudentEntity.MapFromStudentModelList(repositoryResult);
        }

        public async Task<StudentEntity> Insert(StudentEntity studentEntity)
        {
            studentEntity.Age = CalculateAge(studentEntity.Birthday);
            var insertedStudent = await _studentRepository.InsertAsync(StudentEntity.MapToStudent(studentEntity)); // This might not work
            _unitOfWork.Commit();
            return StudentEntity.MapFromStudentModel(insertedStudent);
        }

        public async Task<StudentEntity> Remove(int id)
        {
            var repositoryResult = await _studentRepository.RemoveByIdAsync(id);
            _unitOfWork.Commit();
            return StudentEntity.MapFromStudentModel(repositoryResult);
        }

        public async Task<StudentEntity> Update(int id, StudentEntity studentEntity)
        {
            studentEntity.Age = CalculateAge(studentEntity.Birthday);
            await _studentRepository.UpdateAsync(id, StudentEntity.MapToStudent(studentEntity)); // This might not work
            _unitOfWork.Commit();
            return studentEntity;
        }

        public static int CalculateAge(DateTime birthday)
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear)
                age--;
            return age;
        }
    }
}