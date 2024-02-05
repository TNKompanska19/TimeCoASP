using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data.Models;
using TimeCo.Data.Data;

namespace TimeCo.Data.Repositories
{
    public class DepartmentRepository
    {
        // Private fields
        private TimeCoAspContext _context;
        private UserRepository _userRepository;

        // Constructor
        public DepartmentRepository()
        {
            _context = new TimeCoAspContext();
            _userRepository = new UserRepository();
        }

        // Method for returning all departments
        public List<Department> GetDepartmentsList()
        {
            return _context.Departments.Select(x => x).ToList();
        }

        // Method for adding departments
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();
        }

        // Method for updating department
        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);

            _context.SaveChanges();
        }
    }
}
