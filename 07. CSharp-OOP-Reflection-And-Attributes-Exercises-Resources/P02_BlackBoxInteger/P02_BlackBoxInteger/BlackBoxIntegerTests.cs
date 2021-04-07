namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var instance = Activator.CreateInstance(type, true);

            while (true)
            {
                string[] input = Console.ReadLine().Split("_");
                string command = input[0];
                if (command == "END")
                {
                    break;
                }
                int value = int.Parse(input[1]);

                var method = methods.FirstOrDefault(x => x.Name == command);
                method.Invoke(instance, new object[] { value });

                var field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}
