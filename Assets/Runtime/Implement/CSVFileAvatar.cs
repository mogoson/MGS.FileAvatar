/*************************************************************************
 *  Copyright © 2025 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CSVFileAvatar.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/08/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of csv lines file to read and write data.
    /// </summary>
    public class CSVFileAvatar : LineFileAvatar<List<List<string>>>
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
        protected override List<List<string>> DataFromLines(IEnumerable<string> lines)
        {
            var datas = new List<List<string>>();
            foreach (var line in lines)
            {
                var fieldValues = line.Split(SEPARATOR_CSV);
                var data = new List<string>(fieldValues);
                datas.Add(data);
            }
            return datas;
        }

        /// <summary>
        /// Text lines from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override IEnumerable<string> LinesFromData(List<List<string>> data)
        {
            var lines = new List<string>();
            foreach (var row in data)
            {
                var line = string.Join(SEPARATOR_CSV, row);
                lines.Add(line);
            }
            return lines;
        }
    }
}