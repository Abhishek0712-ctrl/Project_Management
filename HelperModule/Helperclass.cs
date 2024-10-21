using EntityModel;
using DAOModule;
using myexceptions;
namespace HelperModule
{
    public class Helperclass
    {
        ProjectRepositoryImpl projectRepository = null;
        public Helperclass()
        {
            projectRepository = new ProjectRepositoryImpl();
        }

        public bool createnewEmployee(Employee emp)
        {
            bool status = projectRepository.createEmployee(emp);
            return status;
        }

        public bool createNewProject(Project pj)
        {
            bool status = projectRepository.createProject(pj);
            return status;
        }

        public bool createNewTask(Tasks ta)
        {
            bool status = projectRepository.createTask(ta);
            return status;
        }

        public bool assignProjToEmp(int projectid, int employee_id)
        {
            bool status = projectRepository.assignProjectToEmployee(projectid, employee_id);
            return status;
        }

        public bool assignTaskofProjToEmp(int taskid, int projectid, int employeeid)
        {
            bool status = projectRepository.AssigntaskInProjecttoEmployee(taskid, projectid, employeeid);
            return status;
        }

        public void deleteProject(int projectid)
        {
            try
            {
                bool status = projectRepository.deleteProject(projectid);
            }
            catch (ProjectNotFoundException ex)
            {
                throw;
            }
            
        }

        public void deletenewEmployee(int empid)
        {
            try
            {
                bool status = projectRepository.deleteEmployee(empid);

            }
            catch (EmployeeNotFoundException ex)
            {
                throw;
            }

            
        }

        public List<Tasks> getAllTasks(int empid, int projectid)
        {
            return projectRepository.getAllTasks(empid, projectid);
        }

    }
}
