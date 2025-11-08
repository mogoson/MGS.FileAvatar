/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KVFileAvatar.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/21/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of key=value lines file to read and write data.
    /// </summary>
    public class KVFileAvatar : LineFileAvatar<Dictionary<string, string>>
    {
        /// <summary>
        /// Separator of key=value.
        /// </summary>
        public const char SEPARATOR_KV = '=';

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public KVFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Data struct from text lines.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override Dictionary<string, string> DataFromLines(IEnumerable<string> lines)
        {
            var data = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                var kv = line.Split(SEPARATOR_KV);
                data.Add(kv[0], kv[1]);
            }
            return data;
        }

        /// <summary>
        /// Text lines from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override IEnumerable<string> LinesFromData(Dictionary<string, string> data)
        {
            var lines = new List<string>();
            foreach (var kv in data)
            {
                var line = $"{kv.Key}={kv.Value}";
                lines.Add(line);
            }
            return lines;
        }
    }

    /// <summary>
    /// Avatar of key=value lines file to read and write data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KVFileAvatar<T> : LineFileAvatar<T>
    {
        /// <summary>
        /// Separator of key=value.
        /// </summary>
        public const char SEPARATOR_KV = '=';

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public KVFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Data struct from text lines.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override T DataFromLines(IEnumerable<string> lines)
        {
            var data = Activator.CreateInstance<T>();
            foreach (var line in lines)
            {
                var kv = line.Split(SEPARATOR_KV);
                var field = typeof(T).GetField(kv[0]);
                if (field == null)
                {
                    continue;
                }
                field.SetValue(data, kv[1]);
            }
            return data;
        }

        /// <summary>
        /// Text lines from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override IEnumerable<string> LinesFromData(T data)
        {
            var lines = new List<string>();
            var fields = typeof(T).GetFields();
            foreach (var field in fields)
            {
                var line = $"{field.Name}{SEPARATOR_KV}{field.GetValue(data)}";
                lines.Add(line);
            }
            return lines;
        }
    }
}