using System;
using System.IO;
using UnityEngine;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of text file to read and write data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TextFileAvatar<T> : FileAvatar<T>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of file.</param>
        public TextFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Pull data from file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected override T PullFromFile(string path)
        {
            try
            {
                var lines = File.ReadAllText(Path);
                return DataFromText(lines);
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
                var lines = TextFromData(data);
                File.WriteAllText(Path, lines);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        /// <summary>
        /// Data struct from text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected abstract T DataFromText(string text);

        /// <summary>
        /// Text from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected abstract string TextFromData(T data);
    }
}