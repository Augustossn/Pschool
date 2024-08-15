using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PschoolCrud.Entities;

namespace PschoolCrud.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Post(Student student);
        Task<Student> Put(Student student, int id);
        Task<bool> Delete(int id);
        Task<List<Parent>> GetAllParents();
    }
}
