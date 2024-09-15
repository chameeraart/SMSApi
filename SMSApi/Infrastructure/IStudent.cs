using SMSApi.Models;

namespace SMSApi.Infrastructure
{
    public interface IStudent
    {
        List<Student> GetAll();
        Student GetStudent(int id);
        void DeleteStudent(Student student);
        void InsertUpdateStudent(Student student1);
        void Save();
    }
}
