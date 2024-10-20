namespace EntityModel
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public string Gender { get; set; }

        public double Salary { get; set; }

        public int project_id { get; set; }
        
        public Employee()
        {

        }
    }

    public class Project 
    {
        public int project_id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        private string _stat;

        public string Status
        {
            get { return _stat; }
            set 
            { 
                if (value=="started" || value == "dev" || value == "build" || value == "test" || value == "deployed")
                {
                    _stat = value;
                }
                else
                {
                    throw new Exception("Invalid status");
                }
            }
        }

    }
    public class Tasks
    {
        public int task_id { get; set; }
        public string  task_name{ get; set; }
        public int proj_id { get; set; }
        public int employee_id { get; set; }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { 
                if (value == "Assigned" || value == "started" || value == "completed")
                {
                    _status = value;
                }
                else
                {
                    throw new Exception("Invalid status");
                }
            }
        }
    }
}
