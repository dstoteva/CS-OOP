using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType($"Stealer.{className}");

            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            object classInstance = Activator.CreateInstance(classType, new object[] { });

            var sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
