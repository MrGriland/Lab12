using lab12;
using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Grisha", "Bulgak", 2002);
            Reflector.ClassInformationToFile(human);
            Reflector.GetClassMethods("Lab12.Human", "System.Int32");
            Reflector.CallMethod(human, "Analyze");
            var human1 = Reflector.Create(typeof(Human));
        }
    }
}
