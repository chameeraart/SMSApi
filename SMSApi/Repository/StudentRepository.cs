using SMSApi.Infrastructure;
using SMSApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace SMSApi.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly SMSDbContext _context;

        public StudentRepository(SMSDbContext context)
        {
            this._context = context;
        }

        public List<Student> GetAll()
        {
          return _context.students.ToList();
        }

        public Student GetStudent(int id)
        {
            var student = _context.students.Where(x => x.Id == id).FirstOrDefault();

            if (student is null)
            {
                throw new Exception($"Student {id} is not found.");
            }
            else
            {
                return _context.students.Where(x => x.Id == id).FirstOrDefault();
            }
           
        }

        public void DeleteStudent(Student student)
        {
            var Deletestudent = _context.students.FirstOrDefault(s => s.Id == student.Id);
            if (Deletestudent != null)
            {
                _context.students.Remove(Deletestudent);
            }

        }

        public void InsertUpdateStudent(Student student) {

            _context.Update(student);
            _context.SaveChanges();

        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
