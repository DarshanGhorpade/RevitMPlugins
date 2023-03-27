namespace OOPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new operator: to allocate memory to that object
            Person person1 = new Person("Darshan", "Ghorpade");
            person1.Introduce();

            System.Console.ReadLine();
        }
    }
}
