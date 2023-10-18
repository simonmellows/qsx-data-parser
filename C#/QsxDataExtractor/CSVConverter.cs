using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QsxDataExtractor
{
    class CSVConverter
    {
        public static List<T> ConvertToClassData<T>(string csvData, char delimiter) where T : new()
        {
            var lines = csvData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 2)
            {
                throw new ArgumentException("Invalid CSV data format.");
            }

            var properties = lines[0].Split(delimiter).Select(p => p.Trim()).ToArray();
            var result = new List<T>();

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(delimiter).Select(v => v.Trim()).ToArray();
                var obj = new T();
                var objType = obj.GetType();
                var objProperties = objType.GetProperties();

                for (int j = 0; j < objProperties.Length; j++)
                {
                    var propertyInfo = objProperties[j];
                    if (j < values.Length)
                    {
                        var value = Convert.ChangeType(values[j], propertyInfo.PropertyType);
                        propertyInfo.SetValue(obj, value);
                    }
                }

                result.Add(obj);
            }

            return result;
        }
    }
}
