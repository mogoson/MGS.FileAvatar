/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileAvatar.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/21/2022
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of file to read and write data.
    /// </summary>
    public abstract class FileAvatar<T> : IFileAvatar<T>
    {
        /// <summary>
        /// Path of file.
        /// </summary>
        public string Path { protected set; get; }

        /// <summary>
        /// Data cache.
        /// </summary>
        public T Data { protected set; get; }

        /// <summary>
        /// Data cache is dirty?
        /// </summary>
        public bool Dirty { protected set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of file.</param>
        public FileAvatar(string path)
        {
            Path = path;
            Pull();
        }

        /// <summary>
        /// Pull Data from file and refresh cache.
        /// </summary>
        /// <returns>Data of file.</returns>
        public T Pull()
        {
            Data = PullFromFile(Path);
            Dirty = false;
            return Data;
        }

        /// <summary>
        /// Commit data to cache.
        /// </summary>
        /// <param name="data"></param>
        public void Commit(T data)
        {
            Data = data;
            Dirty = true;
        }

        /// <summary>
        /// Push data cache to file.
        /// </summary>
        public void Push()
        {
            if (Dirty)
            {
                PushToFile(Data);
                Dirty = false;
            }
        }

        /// <summary>
        /// Pull data from file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected abstract T PullFromFile(string path);

        /// <summary>
        /// Push data to file.
        /// </summary>
        /// <param name="data"></param>
        protected abstract void PushToFile(T data);
    }
}