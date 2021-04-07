using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLights
{
    public class LightChanger
    {
        private Light light;

        public string TrafficLight
        {
            get => this.light.ToString();
            set
            {
                Light.TryParse(value, out light);
            }
        }
        public LightChanger(string light)
        {
            this.TrafficLight = light;
        }

        public void ChangeLight()
        {
            var lights = typeof(Light).GetEnumValues();
            this.light = (Light)lights.GetValue((int)light % lights.Length);
        }

        public override string ToString()
        {
            return this.light.ToString();
        }
    }
}
