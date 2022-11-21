/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KeyFileAvatar.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/21/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.FileAvatars
{
    /// <summary>
    /// Avatar of key value lines file to read and write data.
    /// </summary>
    public class KeyFileAvatar : FileAvatar
    {
        /// <summary>
        /// Separator of key value lines.
        /// </summary>
        public readonly string[] SEPARATOR_LINE = new string[] { "\r\n" };

        /// <summary>
        /// Separator of key value.
        /// </summary>
        public readonly string[] SEPARATOR_KV = new string[] { "=" };

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public KeyFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Set value for key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, string value)
        {
            keyValuePairs[key] = value;
            Dirty = true;
        }

        /// <summary>
        /// Get value of key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            if (keyValuePairs.ContainsKey(key))
            {
                return keyValuePairs[key];
            }
            return null;
        }

        /// <summary>
        /// Refresh content cache.
        /// </summary>
        /// <param name="content"></param>
        protected override void RefreshContentCache(string content)
        {
            base.RefreshContentCache(content);

            keyValuePairs.Clear();
            if (!string.IsNullOrEmpty(content))
            {
                var lines = content.Split(SEPARATOR_LINE, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var kv = line.Split(SEPARATOR_KV, StringSplitOptions.RemoveEmptyEntries);
                    keyValuePairs.Add(kv[0], kv[1]);
                }
            }
        }

        /// <summary>
        /// Collect content cache.
        /// </summary>
        /// <returns></returns>
        protected override string CollectContentCache()
        {
            var content = string.Empty;
            foreach (var kv in keyValuePairs)
            {
                content += string.Format("{0}={1}\r\n", kv.Key, kv.Value);
            }
            return content;
        }
    }
}