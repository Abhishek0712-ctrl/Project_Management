using EntityModel;
using System;
using HelperModule;
using UtilPackage;
using System.Xml;
using System.Runtime.InteropServices.Marshalling;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\t \t \t \t \t Hello, Welcome to Our Project Management Console");
        Console.WriteLine("\t \t \t \t \t ------------------------------------------------");
        Employee employee = new Employee();
        Project project = new Project();
        Tasks task = new Tasks();
        Helperclass helper = new Helperclass();

        char ans = 'N';
        do
        {
            Console.WriteLine("Menu : ");
            Console.WriteLine("-------");
            Console.WriteLine("1. Add Employee " + "\n" + "2. Add Project " + "\n" + "3. Add Task "+"\n"+ "4. Assign project to employee "+"\n"+"5. Assign task within a project to employee "+"\n"+ "6. Delete Employee. "+"\n"+ "7. Delete Project "+"\n"+ "8. List all projects assigned with tasks to an employeee");
            Console.WriteLine("\n");
            Console.Write("Enter Your Choice from Menu: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            bool status= false;
            
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Employee ID are auto generate so no need to enter");
                    Console.WriteLine("Enter the Employee Name: ");
                    employee.Name = Console.ReadLine();
                    Console.WriteLine("Enter the Employee Designation: ");
                    employee.Designation = Console.ReadLine();
                    Console.WriteLine("Enter the Gender: ");
                    employee.Gender = Console.ReadLine();
                    Console.WriteLine("Enter the Employee Salary: ");
                    employee.Salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the project id they are assigned: ");
                    employee.project_id = Convert.ToInt32(Console.ReadLine());

                    status = helper.createnewEmployee(employee);
                    if (status)
                    {
                        Console.WriteLine("Employee Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Added");
                    }
                    break;
                case 2:
                    Console.WriteLine("Project ID are auto generate so no need to enter");
                    Console.WriteLine("Enter the Project Name: ");
                    project.ProjectName = Console.ReadLine();
                    Console.WriteLine("Enter the Project Description: ");
                    project.Description = Console.ReadLine();
                    Console.WriteLine("Enter the Project Start Date(YYYY-MM-DD): ");
                    project.StartDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter the project Status(started/dev/build/test/deployed): ");
                    project.Status = Console.ReadLine();
                    status = helper.createNewProject(project);
                    if (status)
                    {
                        Console.WriteLine("Project Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Project Not Added");
                    }
                    break;

                case 3:
                    Console.WriteLine("Task Id is auto generated !");
                    Console.WriteLine("Enter the task name: ");
                    task.task_name = Console.ReadLine();
                    Console.WriteLine("Enter the project id: ");
                    task.proj_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the employee id: ");
                    task.employee_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the task status(Assigned, started, completed): ");
                    task.Status = Console.ReadLine();
                    status = helper.createNewTask(task);
                    if (status)
                    {
                        Console.WriteLine("Task Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Task Not Added");
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter the project id: ");
                    int proj_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the employee id: ");
                    int emp_id = Convert.ToInt32(Console.ReadLine());
                    status = helper.assignProjToEmp(proj_id, emp_id);
                    if (status)
                    {
                        Console.WriteLine("Project Assigned Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Project Not Assigned");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter the task id: ");
                    int task_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the project id: ");
                    int proj_id1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the employee id: ");
                    int emp_id1 = Convert.ToInt32(Console.ReadLine());
                    status = helper.assignTaskofProjToEmp(task_id, proj_id1, emp_id1);
                    if (status)
                    {
                        Console.WriteLine("Task Assigned Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Task Not Assigned");
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter the employee id: ");
                    int emp_id2 = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        helper.deletenewEmployee(emp_id2);
                        Console.WriteLine("Deleted Successfully");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                    //if (status)
                    //{
                    //    Console.WriteLine("Employee Deleted Successfully");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Employee Not Deleted");
                    //}
                    break;
                case 7:
                    Console.WriteLine("Enter the project id: ");
                    int projid = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        helper.deleteProject(projid);
                        Console.WriteLine("Deleted Project Successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 8:
                    List<Tasks> alltasks= new List<Tasks>();
                    Console.WriteLine("Enter the project id: ");
                    int projID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the employee id: ");
                    int empid = Convert.ToInt32(Console.ReadLine());
                    alltasks = helper.getAllTasks(empid,projID);
                    foreach (var item in alltasks)
                    {
                        Console.WriteLine("Task ID: " + item.task_id + " Task Name: " + item.task_name + " Project ID: " + item.proj_id + " Employee ID: " + item.employee_id+ "Status:" + item.Status);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.WriteLine("\n");
            Console.Write("Do you want to continue ? (Y/N): ");

            ans = Convert.ToChar(Console.ReadLine());
        } while (ans == 'Y');
        Console.ReadLine();
    }
}