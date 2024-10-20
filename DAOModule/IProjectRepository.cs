using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;

namespace DAOModule
{
    public interface IProjectRepository
    {
        public bool createEmployee(Employee emp);

        public bool createProject(Project pj);

        public bool createTask(Tasks ta);

        public bool assignProjectToEmployee(int projectid, int employee_id);

        public bool AssigntaskInProjecttoEmployee(int taskid, int projectid, int employeeid);

        public bool deleteEmployee(int empid);

        public bool deleteProject(int projectid);

        public List<Tasks> getAllTasks(int empid, int projectid);
    }
}
