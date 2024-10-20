using EntityModel;
using DAOModule;
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

        public bool deleteProject(int projectid)
        {
            bool status = projectRepository.deleteProject(projectid);
            return status;
        }

        public bool deleteEmployee(int empid)
        {
            bool status = projectRepository.deleteEmployee(empid);
            return status;
        }

        public List<Tasks> getAllTasks(int empid, int projectid)
        {
            return projectRepository.getAllTasks(empid, projectid);
        }

    }
}
