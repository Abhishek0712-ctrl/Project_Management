using EntityModel;
using UtilPackage;
using myexceptions;
using Microsoft.Data.SqlClient;
using Azure.Core;
using System.Reflection.PortableExecutable;
using System.Xml;
using System.ComponentModel.Design;

namespace DAOModule
{
    public class ProjectRepositoryImpl : IProjectRepository
    {
        public bool createEmployee(Employee emp)
        {
            bool status = false;
            status = createEmployeeforproject(emp, out status);
            return status;
        }
        private static bool createEmployeeforproject(Employee emp, out bool status)
        {
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Employee(Name, Designation, Gender, Salary, project_id) values(@name,@desig,@gender,@sal,@projid)", cn);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@desig", emp.Designation);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@sal", emp.Salary);
                cmd.Parameters.AddWithValue("@projid", emp.project_id);
                cn.Open();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }
        public bool createProject(Project pj)
        {
            bool status = false;
            status = CreateNewProjects(pj, out status);
            return status;
        }

        private static bool CreateNewProjects(Project pj, out bool status)
        {
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Project(ProjectName,Description,StartDate,Status) values(@projname,@desc,@sdate,@stat)", cn);
                cmd.Parameters.AddWithValue("@projname", pj.ProjectName);
                cmd.Parameters.AddWithValue("@desc", pj.Description);
                //yyyy - mm - dd input format for datetime
                cmd.Parameters.AddWithValue("@sdate", pj.StartDate);
                cmd.Parameters.AddWithValue("@stat", pj.Status);
                cn.Open();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }
        public bool createTask(Tasks ta)
        {
            bool status = false;
            status = CreateNewTasks(ta, out status);
            return status;
        }

        private bool CreateNewTasks(Tasks ta, out bool status)
        {
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Task(task_name,project_id,employee_id,Status) VALUES (@TaskName, @ProjectId, @EmployeeId, @Status)", cn);
                cmd.Parameters.AddWithValue("@TaskName", ta.task_name);
                cmd.Parameters.AddWithValue("@ProjectId", ta.proj_id);
                cmd.Parameters.AddWithValue("@EmployeeId", ta.employee_id);
                cmd.Parameters.AddWithValue("@Status", ta.Status);
                cn.Open();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                return status;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }
        public bool deleteEmployee(int empid)
        {
            bool status = false;
            try
            {
                status = RemoveEmployeeFromDB(empid, out status);
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine("Employee doesn't exist in the DB");
                throw;
            }
            return status;
        }

        private static bool RemoveEmployeeFromDB(int empid, out bool status)
        {
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmdnew = new SqlCommand("delete from Task where employee_id=" + empid, cn);
                SqlCommand cmd = new SqlCommand("delete from Employee where ID=" + empid, cn);
                cn.Open();
                cmdnew.ExecuteNonQuery();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                return status;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }
        public bool deleteProject(int projectid)
        {
            bool status = false;
            try
            {
                status = RemoveProjectFromDb(projectid, out status);

            }
            catch (ProjectNotFoundException ex)
            {
                Console.WriteLine("Project Dosent exsit to be removed");
                throw;
            }
            return status;
        }

        private bool RemoveProjectFromDb(int proj_id, out bool status)
        {
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmdTask = new SqlCommand("DELETE FROM Task WHERE project_id=@projid", cn);
                cmdTask.Parameters.AddWithValue("@projid", proj_id);
                SqlCommand cmdEmp = new SqlCommand("DELETE FROM Employee WHERE project_id=@projid", cn);
                cmdEmp.Parameters.AddWithValue("@projid", proj_id);
                SqlCommand cmdProj = new SqlCommand("DELETE FROM Project WHERE Id=@projid", cn);
                cmdProj.Parameters.AddWithValue("@projid", proj_id);
                cn.Open();
                cmdTask.ExecuteNonQuery();
                cmdEmp.ExecuteNonQuery();
                int cnt = cmdProj.ExecuteNonQuery();

                if (cnt > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                    return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }
        public bool assignProjectToEmployee(int projectid, int emp_id)
        {
            bool status = false;
            try
            {
                status = AssignProjecttoemp(projectid, emp_id, out status);
            }
            catch (ProjectNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return status;
        }

        private bool AssignProjecttoemp(int proj_id,int emp_id,out bool status)
        {
            Employee emp = new Employee();
            Project project = new Project();
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("update Employee set project_id=@projid where ID=@empid", cn);
            cmd.Parameters.AddWithValue("@projid", proj_id);
            cmd.Parameters.AddWithValue("@empid", emp_id);
            cn.Open();
            SqlCommand getProjCmd = new SqlCommand("select Id from Project where Id=@projid", cn);
            getProjCmd.Parameters.AddWithValue("@projid", proj_id);
            SqlDataReader reader = getProjCmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                cn.Close();
                throw new ProjectNotFoundException("Invalid!!! ProjectID doesn't exist in DB");
            }
            reader.Close();
            int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    throw new ProjectNotFoundException("Invalid!!! ProjectID doesn't exist in DB");

                    status = false;
                }
                return status;
        }
        public bool AssigntaskInProjecttoEmployee(int taskid, int projectid, int employeeid)
        {
            bool status = false;
            try
            {

            }
            catch (ProjectNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmployeeNotFoundException  ex)
            {
                Console.WriteLine(ex.Message);
            }
            status = AssignTaskofProjecttoEmployee(taskid, projectid, employeeid, out status);
            return status;
        }

        private bool AssignTaskofProjecttoEmployee(int taskid, int proj_id, int employeeid,out bool status)
        {
            Employee emp = new Employee();
            Project project = new Project();
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("update Task set employee_id=@empid where task_id=@taskid and project_id=@projid", cn);
            cmd.Parameters.AddWithValue("@empid", employeeid);
            cmd.Parameters.AddWithValue("@taskid", taskid);
            cmd.Parameters.AddWithValue("@projid", proj_id);
            cn.Open();
            SqlCommand getProjCmd = new SqlCommand("select Id from Project where Id=@projid", cn);
            getProjCmd.Parameters.AddWithValue("@projid", proj_id);
            SqlDataReader reader = getProjCmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                cn.Close();
                throw new ProjectNotFoundException("Invalid!!! ProjectID doesn't exist in DB");
            }
            reader.Close();
            SqlCommand getEmpCmd = new SqlCommand("select ID from Employee where ID=@empid", cn);
            getEmpCmd.Parameters.AddWithValue("@empid", employeeid);
            SqlDataReader reader1 = getEmpCmd.ExecuteReader();
            if (!reader1.HasRows)
            {
                reader1.Close();
                cn.Close();
                throw new EmployeeNotFoundException("Invalid!!! EmployeeID doesn't exist in DB");
            }
            reader1.Close();
            int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                return status;
        }

        public List<Tasks> getAllTasks(int empid,int projectid)
        {
            string cnstr = PropertyUtil.getPropertyString("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("select * from Task where project_id=@projid and employee_id=@empid", cn);
            cmd.Parameters.AddWithValue("@projid", projectid);
            cmd.Parameters.AddWithValue("@empid", empid);
            cn.Open();
            //SqlCommand getProjCmd = new SqlCommand("select Id from Project where Id=@projid", cn);
            //getProjCmd.Parameters.AddWithValue("@projid", projectid);
            //SqlDataReader reader = getProjCmd.ExecuteReader();

            //if (!reader.HasRows)
            //{
            //    reader.Close();
            //    cn.Close();
            //    throw new ProjectNotFoundException("Invalid!!! ProjectID doesn't exist in DB");
            //}
            //reader.Close();
            //SqlCommand getEmpCmd = new SqlCommand("select ID from Employee where ID=@empid", cn);
            //getEmpCmd.Parameters.AddWithValue("@empid", empid);
            //SqlDataReader reader1 = getEmpCmd.ExecuteReader();
            //if (!reader1.HasRows)
            //{
            //    reader1.Close();
            //    cn.Close();
            //    throw new EmployeeNotFoundException("Invalid!!! EmployeeID doesn't exist in DB");
            //}
            //reader1.Close();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Tasks> tasks = new List<Tasks>();
            while (dr.Read())
            {
                Tasks task = new Tasks();
                task.task_id = Convert.ToInt32(dr["task_id"]);
                task.task_name = dr["task_name"].ToString();
                task.proj_id = Convert.ToInt32(dr["project_id"]);
                task.employee_id = Convert.ToInt32(dr["employee_id"]);
                task.Status = dr["Status"].ToString();
                tasks.Add(task);
            }
            cn.Close();
            return tasks;
        }
    }
}