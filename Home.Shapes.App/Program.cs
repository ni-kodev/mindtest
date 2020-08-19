using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Home.Shapes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = typeof(BaseShape);

            //возьмем фигуры только из основной библиотеки
            var currentAssembly = Assembly.GetAssembly(bst);
            var shapeTypes = currentAssembly.ExportedTypes.Where(t => t.IsSubclassOf(bst)).ToList();

            Console.WriteLine("Select shape type for calculate Area:");
            
            for (int i = 0; i < shapeTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {shapeTypes[i].Name}");
            }

            var indexStr = Console.ReadLine();
            //пример обработки пользовательского ввода
            if (!int.TryParse(indexStr, out int index)
                || (index <= 0 || index > shapeTypes.Count))
                throw new ArgumentException();

            var selectedShapeType = shapeTypes[index - 1];
            Console.WriteLine($"Selected {selectedShapeType.Name}");

            //чтобы не усложнять тестовый пример, расчитываем что все фигуры имеют единственный конструктор
            //и юзер всегда вводит правильные значения нужных типов, в реальности это конечно может быть не так
            var constructor = selectedShapeType.GetConstructors().Single();
            var constructorParameters = constructor.GetParameters();
            var parameters = new List<object>();
            foreach (var cp in constructorParameters)
            {
                Console.WriteLine($"Enter {cp.Name}({cp.ParameterType.Name}):");
                var pStr = Console.ReadLine();
                var p = Convert.ChangeType(pStr, cp.ParameterType);
                parameters.Add(p);
            }

            var shape = constructor.Invoke(parameters?.ToArray()) as IShape;
            Console.WriteLine($"Calculated area = {shape.GetArea()}");

            switch (shape)
            {
                case Triangle t:
                    Console.WriteLine($"Triangle is {(t.IsRect ? string.Empty : "not ")}rectangle!");
                    break;
                
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
