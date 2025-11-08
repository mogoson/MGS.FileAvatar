/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IFileAvatar.cs
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
    /// Interface for avatar of file to read and write data.
    /// </summary>
    public interface IFileAvatar<T>
    {
        /// <summary>
        /// Path of file.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Data cache.
        /// </summary>
        T Data { get; }

        /// <summary>
        /// Data cache is dirty?
        /// </summary>
        bool Dirty { get; }

        /// <summary>
        /// Pull Data from file and refresh cache.
        /// </summary>
        /// <returns>Data of file.</returns>
        T Pull();

        /// <summary>
        /// Commit data to cache.
        /// </summary>
        /// <param name="data"></param>
        void Commit(T data);

        /// <summary>
        /// Push data cache to file.
        /// </summary>
        void Push();
    }
}