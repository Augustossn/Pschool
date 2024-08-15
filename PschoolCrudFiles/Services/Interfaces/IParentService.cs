using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PschoolCrud.Entities;

namespace PschoolCrud.Services.Interfaces
{
    public interface IParentService
    {
        Task<List<Parent>> GetAll();
        Task<Parent> GetById(int id);
        Task<Parent> Post(Parent parent);
        Task<Parent> Put(Parent parent, int id);
        Task<bool> Delete(int id);
    }
}
