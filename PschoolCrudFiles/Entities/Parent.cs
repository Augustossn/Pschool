using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PschoolCrud.Entities
{
    public class Parent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
    }
}
