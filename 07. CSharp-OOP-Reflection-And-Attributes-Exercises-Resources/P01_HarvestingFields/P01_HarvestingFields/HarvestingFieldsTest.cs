 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == nameof(HarvestingFields));

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "HARVEST")
                {
                    break;
                }
                FieldInfo[] fieldsToPrint = null;
                switch (command)
                {
                    case "private":
                        fieldsToPrint = fields.Where(x => x.IsPrivate).ToArray();
                        break;
                    case "protected":
                        fieldsToPrint = fields.Where(x => x.IsFamily).ToArray();
                        break;
                    case "public":
                        fieldsToPrint = fields.Where(x => x.IsPublic).ToArray();
                        break;
                    default:
                        fieldsToPrint = fields;
                        break;
                }
                foreach (var field in fieldsToPrint)
                {
                    string accessModifier = field.Attributes.ToString().ToLower() == "family" ? "protected"
                        : field.Attributes.ToString().ToLower();
                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
