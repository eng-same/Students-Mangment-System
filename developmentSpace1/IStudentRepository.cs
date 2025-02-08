using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developmentSpace1
{
    internal interface IStudentRepository
    {
        Student GetById(int id);  // Fetch student by ID
        List<Student> GetAll();  // Fetch all students
        void Add(Student student); // Insert new student
        void Update(Student student); // Update student
        void Delete(int id); // Delete student by ID
        void Save(); // Save changes
    }
}
