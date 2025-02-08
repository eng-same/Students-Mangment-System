using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace developmentSpace1
{
    internal class StudentRepository : IStudentRepository
    {
        private AppDbContext _context = new AppDbContext();
        public void Add(Student student)
        {
            _context.Students.Add(student);
            Save();
        }

        public void Delete(int id)
        {
            _context.Students.Remove(GetById(id));
            Save();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return (id!=0)? _context.Students.Find(id) : null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            Save();
        }
    }
}
