using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Iso8583.Types
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Iso8583ValueAttribute : Attribute
    {
        public Iso8583ValueAttribute()
        {

        }

        public int Number { get; set; }

        public Iso8583DataTypes Type { get; set; }

        public int Length { get; set; }

        public Iso8583LengthTypes LengthType { get; set; }

        public Iso8583VariableLengthTypes VariableLengthType { get; set; }

        public bool NumericHasSigne { get; set; }

        public bool AlphaHasSpecialChars { get; set; }

        public bool AlphaHasNumerics { get; set; }

        public bool AlphaHasLetters { get; set; }

        public bool AlphaHasPadChars { get; set; }

        public bool Truncate { get; set; }

        public object Normalize(object value)
        {
            if (Truncate && Type == Iso8583DataTypes.ALPHA)
            {
                var valueString = value as string;
                if (valueString.Length > Length)
                {
                    return valueString.Substring(0, Length);
                }
            }
            return value;
        }

        public bool Validate(object value)
        {
            switch (Type)
            {
                case Iso8583DataTypes.ALPHA:
                    var valueString = value as string;
                    return ValidateAlpha(valueString);
                case Iso8583DataTypes.BINARY:
                    var valueDecimal = (value as decimal?) ?? 0;
                    return ValidateNumeric(valueDecimal);
            }
            return true;
        }

        private bool ValidateAlpha(string value)
        {
            if (Truncate)
            {

            }
            return true;
        }

        private bool ValidateNumeric(decimal value)
        {
            return true;
        }

        public static IEnumerable<PropertyInfo> GetPropertiesByBitmaps<T>(IIso8583Message message, ISet<int> bitmap) where T : IIso8583Message
        {
            var r = new List<PropertyInfo>();
            var c = new List<int>();
            foreach (var p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                var a = p.GetCustomAttribute<Iso8583ValueAttribute>();

                if (a == null)
                {
                    continue;
                }

                var n = a.Number;
                if ((bitmap?.Contains(n) ?? false) && !c.Contains(n))
                {
                    c.Add(n);
                    r.Add(p);
                }
            }
            foreach (var p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                var a = p.GetCustomAttribute<Iso8583ValueAttribute>();

                if (a == null)
                {
                    continue;
                }

                var n = a.Number;
                if ((bitmap?.Contains(n) ?? false) && !c.Contains(n))
                {
                    c.Add(n);
                    r.Add(p);
                }
            }
            return r.OrderBy(
                p => p.GetCustomAttributes(typeof(Iso8583ValueAttribute), true)
                .Select(a => ((Iso8583ValueAttribute)a)?.Number)
                .Where(n => n != null)
                .First()
            );
        }
    }
}