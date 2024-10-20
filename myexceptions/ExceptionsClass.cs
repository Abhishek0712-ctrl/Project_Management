namespace myexceptions
{
        [Serializable]
        public class EmployeeNotFoundException : Exception
        {
            public EmployeeNotFoundException() { }
            public EmployeeNotFoundException(string message) : base(message) { }
            public EmployeeNotFoundException(string message, Exception inner) : base(message, inner) { }
            protected EmployeeNotFoundException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }


        [Serializable]
        public class ProjectNotFoundException : Exception
        {
            public ProjectNotFoundException() { }
            public ProjectNotFoundException(string message) : base(message) { }
            public ProjectNotFoundException(string message, Exception inner) : base(message, inner) { }
            protected ProjectNotFoundException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
}
