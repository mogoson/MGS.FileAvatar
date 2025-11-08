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
    public class JsonFileAvatar<T> : TextFileAvatar<T>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of text file.</param>
        public JsonFileAvatar(string path) : base(path) { }

        /// <summary>
        /// Data struct from text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override T DataFromText(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        /// <summary>
        /// Text from data struct.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override string TextFromData(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}