using System;
using Xamarin.Forms;

namespace What_Should_I_Do
{
    public class ReminderColor 
    {
        public static Color[] colors = { Color.Black};
        public static Color RandomColor => GetRandomColor();

        public static Color GetRandomColor()
        {
            var random = new Random();
            return colors[random.Next(colors.Length)];
        }        
    }
}
