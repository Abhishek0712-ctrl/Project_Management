using HelperModule;
using EntityModel;
using myexceptions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ProjectSystem
{
    public class Tests
    {
        Helperclass helperobj = null;

        [SetUp]
        public void Setup()
        {
            helperobj = new Helperclass();
        }

        [Test]
        public void TestEmployeeCreation()
        {
            Employee emp = new Employee
            {
                Name = "John Doe",
                Designation = "Developer",
                Gender = "Male",
                Salary = 60000,
                project_id = 3
            };
            Assert.That(helperobj.createnewEmployee(emp), Is.True);
        }

        [Test]
        public void TestTaskCreation()
        {
            Tasks task = new Tasks
            {
                task_name = "Design Database",
                proj_id = 3,
                employee_id = 14,
                Status = "Assigned"
            };
            Assert.That(helperobj.createNewTask(task), Is.True);
        }

        [Test]
        [TestCase(62,10,10)]
        [TestCase(4,3,3)]
        public void TestSearchProjectsAndTasksAssignedToEmployee(int taskid,int empid,int projectid)
        {
            Assert.That(helperobj.assignTaskofProjToEmp(taskid,empid,projectid));
        }

        [TestCase(1)]
        [TestCase(15)]
        public void TestProjectNotFoundException(int empid)
        {
            var ex = Assert.Throws<ProjectNotFoundException>(() => helperobj.deleteEmployee(empid));
            Assert.That(ex.Message, Is.EqualTo("Invalid!!! ProjectID doesn't exist in DB"));
        }

        [TestCase(1)]
        [TestCase(15)]
        public void TestEmployeeNotFoundException(int projectid)
        {
            var ex = Assert.Throws<EmployeeNotFoundException>(() => helperobj.deleteProject(projectid));
            Assert.That(ex.Message, Is.EqualTo("Invalid!!! EmployeeID doesn't exist in DB"));
        }
    }
}
