namespace TheOneStudio.DuckBase.Scripts.Extensions
{
    using System.Globalization;
    using UnityEngine;

    public static class ColorExtensions
    {
        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("0x", "");
            hex = hex.Replace("#", "");

            byte a = 255;
            var  r = byte.Parse(hex[..2], NumberStyles.HexNumber);
            var  g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            var  b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);

            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
            }

            return new Color32(r, g, b, a);
        }

        public static string ColorToHex(Color32 color)
        {
            var hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");

            return hex;
        }
    }
}