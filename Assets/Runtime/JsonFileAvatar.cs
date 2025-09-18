/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  JsonFileAvatar.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/21/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using Newtonsoft.Json;

namespace MGS.FileAvatar
{
    /// <summary>
    /// Avatar of json file to read and write data.
    /// </summary>
    public class JsonFileAvatar<T> : FileAvatar
    {
        /// <summary>
        /// Content of json file.
        /// </summary>
        public new T Content { protected set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public JsonFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Commit to the content cache.
        /// </summary>
        /// <param name="content">New content to refresh.</param>
        public void Commit(T content)
        {
            Content = content;
            Dirty = true;
        }

        /// <summary>
        /// Refresh content cache.
        /// </summary>
        /// <param name="content"></param>
        protected override void RefreshContentCache(string content)
        {
            base.RefreshContentCache(content);
            if (string.IsNullOrEmpty(content))
            {
                Content = default(T);
            }
            else
            {
                Content = JsonConvert.DeserializeObject<T>(content);
            }
        }

        /// <summary>
        /// Collect content cache.
        /// </summary>
        /// <returns></returns>
        protected override string CollectContentCache()
        {
            if (Content == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(Content);
        }
    }
}