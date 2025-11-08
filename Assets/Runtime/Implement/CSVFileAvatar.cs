using System;
using System.Collections.Generic;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of csv lines file to read and write data.
    /// </summary>
    public class CSVFileAvatar<T> : LineFileAvatar<List<T>>
    {
        /// <summary>
        /// Separator of csv line.
        /// </summary>
        public const char SEPARATOR_CSV = ',';

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public CSVFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Data struct from text lines.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override List<T> DataFromLines(IEnumerable<string> lines)
        {
            var datas = new List<T>();
            foreach (var line in lines)
            {
                var fieldValues = line.Split(SEPARATOR_CSV);
                var fields = typeof(T).GetFields();
                var data = Activator.CreateInstance<T>();
                for (int i = 0; i < fieldValues.Length; i++)
                {
                    if (i >= fields.Length)
                    {
                        break;
                    }
                    fields[i].SetValue(data, fieldValues[i]);
                }
                datas.Add(data);
            }
            return datas;
        }

        /// <summary>
        /// Text lines from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override IEnumerable<string> LinesFromData(List<T> datas)
        {
            var lines = new List<string>();
            foreach (var data in datas)
            {
                var fields = typeof(T).GetFields();
                var fieldValues = new List<string>();
                foreach (var field in fields)
                {
                    fieldValues.Add($"{field.GetValue(data)}");
                }
                var line = string.Join(SEPARATOR_CSV, fieldValues);
                lines.Add(line);
            }
            return lines;
        }
    }
}