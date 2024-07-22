namespace miniApp.Exceptions
{
    public class ClassroomNotFoundException : Exception { 
    
        public ClassroomNotFoundException() { }
        public ClassroomNotFoundException(string message) : base(message) { }
    }
}
