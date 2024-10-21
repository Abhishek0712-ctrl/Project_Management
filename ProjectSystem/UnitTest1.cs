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
                project_id = 8
            };
            Assert.That(helperobj.createnewEmployee(emp), Is.True);
        }

        [Test]
        public void TestTaskCreation()
        {
            Tasks task = new Tasks
            {
                task_name = "Design Database",
                proj_id = 8,
                employee_id = 23,
                Status = "Assigned"
            };
            Assert.That(helperobj.createNewTask(task), Is.True);
        }

        [Test]
        [TestCase(61,7,21)]
        //[TestCase(4,3,3)]
        public void TestSearchProjectsAndTasksAssignedToEmployee(int taskid,int projectid,int empid)
        {
            Assert.That(helperobj.assignTaskofProjToEmp(taskid,projectid,empid));
        }

        [TestCase(15)]
        public void TestProjectNotFoundException(int projid)
        {
            var ex = Assert.Throws<ProjectNotFoundException>(() => helperobj.deleteProject(projid));
            Assert.That(ex.Message, Is.EqualTo("Project Dosent exsit to be removed"));
        }

        [TestCase(15)]
        public void TestEmployeeNotFoundException(int empid)
        {
            var ex = Assert.Throws<EmployeeNotFoundException>(() => helperobj.deletenewEmployee(empid));
            Assert.That(ex.Message, Is.EqualTo("Employee not found in DB"));
        }
    }
}
