using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of text lines file to read and write data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class LineFileAvatar<T> : FileAvatar<T>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of file.</param>
        public LineFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Pull data from file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected override T PullFromFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(Path);
                return DataFromLines(lines);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                return default;
            }
        }

        /// <summary>
        /// Push data to file.
        /// </summary>
        /// <param name="data"></param>
        protected override void PushToFile(T data)
        {
            try
            {
                var lines = LinesFromData(data);
                File.WriteAllLines(Path, lines);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        /// <summary>
        /// Data struct from text lines.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected abstract T DataFromLines(IEnumerable<string> lines);

        /// <summary>
        /// Text lines from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected abstract IEnumerable<string> LinesFromData(T data);
    }
}