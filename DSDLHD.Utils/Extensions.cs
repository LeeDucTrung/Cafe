using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Linq;

namespace VPDT.Utils
{
    public class Extensions
    {
        /// <summary>
        /// 0: chỉ xóa khoảng trắng
        /// 1: viết hoa ký tự đầu của các chữ
        /// 2: chỉ viết hoa ký tự đầu của chuỗi
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static string StringStandar(string inputText, int type = 2)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return null;
            }
            var name = inputText.Trim();
            if (type == 1)
            {
                name = name.ToLower();
                name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            }
            else if (type == 2)
            {
                name = name.ToLower();
                var sInput = name.Split(" ");
                var firstLetter = sInput[0];
                var secondLetter = name.Remove(0, firstLetter.Length);
                name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstLetter) + secondLetter;
            }

            var s = name.Split(" ");
            var nameFormat = "";

            for (var i = 0; i < s.Length; i++)
            {
                if (!string.IsNullOrEmpty(s[i]))
                {
                    nameFormat = nameFormat + s[i] + " ";
                }
            }
            return nameFormat.Trim();
        }
        public static string RemoveDataBeforeCharacter(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return null;
            }
            string output = inputText.Substring(inputText.LastIndexOf('/') + 1);
            return output;
        }
    }
}
