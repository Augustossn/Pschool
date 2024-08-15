using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PschoolCrud.Data;
using PschoolCrud.Entities;
using PschoolCrud.Services.Interfaces;

namespace PschoolCrud.Services
{
    public class StudentService : IStudentService
    {
        private readonly PschoolContext _dbContext;

        public StudentService(PschoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbContext.Students
                .Include(x => x.Parent)
                .ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students
                .Include(x => x.Parent)
                .FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<Student> Post(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return student;
        }

        public async Task<Student> Put(Student student, int id)
        {
            Student studentById = await GetById(id);

            if (studentById == null)
            {
                throw new Exception($"Student ID: {id} wasn't found in the databank.");
            }

            studentById.StudentName = student.StudentName;
            studentById.Parent = student.Parent;

            _dbContext.Entry(studentById).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return studentById;
        }

        public async Task<bool> Delete(int id)
        {
            Student studentById = await GetById(id);

            if (studentById == null)
            {
                throw new Exception($"Student ID: {studentById} wasn't found in the databank.");
            }

            _dbContext.Students.Remove(studentById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Parent>> GetAllParents()
        {
            return await _dbContext.Parents.ToListAsync();
        }
    }
}
