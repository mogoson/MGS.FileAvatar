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
    public interface IFileAvatar
    {
        /// <summary>
        /// Path of file.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Content cache of file.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// The data is dirty?
        /// </summary>
        bool Dirty { get; }

        /// <summary>
        /// Pull content from file and refresh cache.
        /// </summary>
        /// <returns>Content of file.</returns>
        string Pull();

        /// <summary>
        /// Commit to the content cache.
        /// </summary>
        /// <param name="content">New content to refresh.</param>
        void Commit(string content);

        /// <summary>
        /// Push the content cache to text file.
        /// </summary>
        void Push();
    }
}