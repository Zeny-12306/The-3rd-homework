using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools_For_Translation
{
    /// <summary>
    /// The main Basic Tool class. Contains methods for input detection and unit conversion functions.
    /// <list type="number">
    /// <item>
    /// <term>Check_Input</term>
    /// <description>Ensure the input is valid</description>
    /// </item>
    /// <item>
    /// <term>ToInch</term>
    /// <description>Convert centimeters to inches</description>
    /// </item>
    /// <item>
    /// <term>ToCm</term>
    /// <description>Convert inches to centimeters</description>
    /// </item>
    /// </list>
    /// </summary>
    public class Tool
    {
        private const double cmtoinch = 0.393701;
        /// <summary>
        /// Determine if the input is valid and returns true or false.
        /// Input is valid when it contains only numbers, ','(separators), less than ONE '.'(decimal points).
        /// </summary>
        /// <param name="input">The input string</param>
        /// <example>
        /// <code>
        /// bool flag = Tool.check_input(a.text); //a.text类型为字符串
        /// if (!flag)
        /// {
        ///     Console.WriteLine("Input is invalid!");
        ///  }
        /// </code>
        /// </example>
        /// <returns>Valid or not</returns>
        public static bool check_input(string input)
        {
            int cnt = 0;
            int location = input.Length;
            if (input.Length == 0) return false;
            if (input[0] == ',' || input[input.Length-1] ==',') return false;
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if ((ch < '0' || ch > '9') && ch!='.' && ch != ',') { return false; }
                if (ch == '.') { cnt++; location = i; }
            }
            if (cnt > 1) return false;
            for(int i = location; i < input.Length; i++)
                if (input[i] == ',') return false;
            return true;
        }

        /// <summary>
        /// Convert centimeters to inches
        /// </summary>
        /// <param name="data">The data in centimeter units(of string type)</param>
        /// <example>
        /// <code>
        /// string Length = "1.0";
        /// Length = ToInch(Length);
        /// </code>
        /// Length = 0.393
        /// </example>
        /// <returns>The data in inch units(of string type)</returns>
        public static string ToInch(string data)
        {
            return (double.Parse(data) * cmtoinch).ToString("N3");
        }

        /// <summary>
        /// Convert inches to centimeters
        /// </summary>
        /// <param name="data">The data in inch units(of string type)</param>
        /// <example>
        /// <code>
        /// string Length = "1.0";
        /// Length = ToCm(Length);
        /// </code>
        /// Length = 2.545
        /// </example>
        /// <returns>The data in centimeter units(of string type)</returns>
        public static string ToCm(string data)
        {
            return (double.Parse(data) / cmtoinch).ToString("N3");
        }

    }
}
