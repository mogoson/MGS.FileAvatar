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

using System;
using System.IO;
using UnityEngine;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of file to read and write data.
    /// </summary>
    public class FileAvatar : IFileAvatar
    {
        /// <summary>
        /// Path of file.
        /// </summary>
        public string Path { protected set; get; }

        /// <summary>
        /// Content cache of file.
        /// </summary>
        public string Content { protected set; get; }

        /// <summary>
        /// The data is dirty?
        /// </summary>
        public bool Dirty { protected set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public FileAvatar(string path)
        {
            Path = path;
            Pull();
        }

        /// <summary>
        /// Pull content from file and refresh cache.
        /// </summary>
        /// <returns>Content of file.</returns>
        public string Pull()
        {
            var content = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    content = File.ReadAllText(Path);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
            RefreshContentCache(content);
            Dirty = false;
            return content;
        }

        /// <summary>
        /// Commit to the content cache.
        /// </summary>
        /// <param name="content">New content to refresh.</param>
        public void Commit(string content)
        {
            RefreshContentCache(content);
            Dirty = true;
        }

        /// <summary>
        /// Push the content cache to text file.
        /// </summary>
        public void Push()
        {
            if (Dirty)
            {
                var content = CollectContentCache();
                try
                {
                    File.WriteAllText(Path, content);
                    Dirty = false;
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
        }

        /// <summary>
        /// Refresh content cache.
        /// </summary>
        /// <param name="content"></param>
        protected virtual void RefreshContentCache(string content)
        {
            Content = content;
        }

        /// <summary>
        /// Collect content cache.
        /// </summary>
        /// <returns></returns>
        protected virtual string CollectContentCache()
        {
            return Content;
        }
    }
}