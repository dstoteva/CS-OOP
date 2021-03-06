using InfernoInfinity.Contracts;
using InfernoInfinity.Enums;
using InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Factories
{
    public class GemFactory
    {
        public IGem CreateGem(string kind, string clarity)
        {
            GemClarity gemClarity;
            var isGemValid = Enum.TryParse(clarity, out gemClarity);
            if (!isGemValid)
            {
                return null;
            }
            switch (kind)
            {
                case "Ruby":
                    return new Ruby(gemClarity);
                case "Emerald":
                    return new Emerald(gemClarity);
                case "Amethyst":
                    return new Amethyst(gemClarity);
                default:
                    return null;
            }

        }
    }
}
