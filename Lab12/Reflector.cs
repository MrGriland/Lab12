using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class Reflector
    {
        public static void ClassInformationToFile(object inputClass)
        {
            string path = @"D:\Objects";
            string rwPath = @"D:\Objects\log.txt";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            using (StreamWriter stream = new StreamWriter(rwPath, false))
            {
                var type = inputClass.GetType(); 
                var name = type.Name; 
                var fields = type.GetFields();
                var assembly = type.Assembly; 
                var constructors = type.GetConstructors(); 
                var properties = type.GetProperties();
                var interfaces = type.GetInterfaces();
                var method = type.GetMethods(BindingFlags.Public);

                stream.WriteLine($"Название класса: {name.ToString()}");
                stream.WriteLine($"Имя сборки: {assembly.ToString()}");

                stream.WriteLine($"В классе {constructors.Length} публичных конструкторов");

                stream.WriteLine("Имена публичных свойств: ");
                foreach (var item in properties)
                {
                    stream.WriteLine(item.Name);
                }

                stream.WriteLine("Имена публичных методов: ");
                foreach (var item in method)
                {
                    stream.WriteLine(item.Name);
                }

                stream.WriteLine("Имена публичных полей: ");
                foreach (var item in fields)
                {
                    stream.WriteLine(item.Name);
                }

                stream.WriteLine("Реализованные интерфейсы: ");
                foreach (var item in interfaces)
                {
                    stream.WriteLine(item.Name);
                }
            }


        }

        public static void GetClassMethods(string className, string typeOfParam) 
        {
            var type = Type.GetType(className); 
            var param = Type.GetType(typeOfParam);

            if (param != null)
            {
                var request = type.GetMethods().Where(i => i.GetParameters().Any(item => item.ParameterType == param));

                if (request.Count() > 0)
                {
                    Console.WriteLine($"Найденные методы:");
                    foreach (var item in request)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Методы с заданным парметром не найдены");
                }
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }

        public static void CallMethod(object inputClass, string methodName)
        {
            var type = inputClass.GetType();
            var method = type.GetMethod(methodName);
            var parameterInformation = method.GetParameters();
            object[] paramFromFile = new object[1];

            string rwPath = @"D:\Objects\par.txt";
            using (StreamReader stream = new StreamReader(rwPath))
            {
                paramFromFile[0] = Int32.Parse(stream.ReadLine());
            }

            if (parameterInformation.Length == 1) 
            {
                method.Invoke(inputClass, paramFromFile);  
            }

            Random rnd = new Random();

            object[] Randparam = new object[1];
            int value = rnd.Next(10, 20);
            Randparam[0] = value;

            method.Invoke(inputClass, Randparam);
        }

        public static Object Create(Type clas)
        {
            return Activator.CreateInstance(clas);
        }
    }

}
