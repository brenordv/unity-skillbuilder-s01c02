using System;
using Core.Enums;
using UnityEngine;
using Random = System.Random;

namespace Core.Helpers
{
    public static class ColorOptionsHelper
    {
        private static readonly Random Rnd = new Random();

        public static Color ToColor(ColorOption colorOption)
        {
            switch (colorOption)
            {
                case ColorOption.Red:
                    return Color.red;

                case ColorOption.Yellow:
                    return Color.yellow;

                case ColorOption.Green:
                    return Color.green;

                case ColorOption.Blank:
                    return Color.white;

                default:
                    throw new ArgumentOutOfRangeException(nameof(colorOption), colorOption, null);
            }
        }

        public static ColorOption GetRandom()
        {
            var values = Enum.GetValues(typeof(ColorOption));
            var randomColor = ColorOption.Blank;
            while (randomColor == ColorOption.Blank)
            {
                randomColor = (ColorOption)values.GetValue(Rnd.Next(values.Length));
            }

            return randomColor;
        }
    }
}