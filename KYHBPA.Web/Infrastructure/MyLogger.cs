namespace KYHBPA
{
    public class MyLogger
    {
        public void Log(string component, string message)
        {
            System.Diagnostics.Debug.WriteLine("Component: {0} Message: {1} ", component, message);
        }
    }
}