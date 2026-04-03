using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using System.Security.Principal;

namespace StudentManagementAPI.Repositories
{
    public class StudentRepository:IstudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
           return await _context.students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
             return await _context.students.FindAsync(id);
        }

        public async Task Add(Student stu)
        {
             _context.students.Add(stu);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student stu)
        {
            _context.students.Update(stu);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var stu = await _context.students.FindAsync(Id);

            if(stu != null)
            {
                _context.students.Remove(stu);
                await _context.SaveChangesAsync();
            }
        }
    }
}
