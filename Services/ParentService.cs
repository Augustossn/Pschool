using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PschoolCrud.Entities;
using PschoolCrud.Services.Interfaces;
using PschoolCrud.Data;

namespace PschoolCrud.Services
{
    public class ParentService : IParentService
    {
        private readonly PschoolContext _dbContext;

        public ParentService(PschoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Parent>> GetAll()
        {
            return await _dbContext.Parents
                .Include(x => x.Students)
                .ToListAsync();
        }

        public async Task<Parent> GetById(int id)
        {
            return await _dbContext.Parents
                .Include(x => x.Students)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Parent> Post(Parent parent)
        {
            await _dbContext.Parents.AddAsync(parent);
            await _dbContext.SaveChangesAsync();

            return parent;
        }

        public async Task<Parent> Put(Parent parent, int id)
        {
            Parent parentById = await GetById(id);

            if (parentById == null)
            {
                throw new Exception($"Parent ID: {parentById} wasn't found in the databank.");
            }

            parentById.Name = parent.Name;
            parentById.Students = parent.Students;

			_dbContext.Entry(parentById).State = EntityState.Modified;

			await _dbContext.SaveChangesAsync();

			return parent;
        }

        public async Task<bool> Delete(int id)
        {
            Parent parentById = await GetById(id);

            if (parentById == null)
            {
                throw new Exception($"Parent ID: {parentById} wasn't found in the databank.");
            }

            _dbContext.Parents.Remove(parentById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetStudentCountByParentId(int parentId)
        {
            return await _dbContext.Students.CountAsync(s => s.ParentId == parentId);
        }
    }
}
