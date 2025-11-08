/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  JsonFileAvatarSample.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/21/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.FileAvatar.Sample
{
    public class JsonFileAvatarSample : FileAvatarSample
    {
        void Start()
        {
            var file = $"{FileDir}/JsonFile.json";
            var avatar = new JsonFileAvatar<FileDataSample>(file);

            var data = avatar.Data;
            Debug.Log(data.tittle);
            Debug.Log(data.content);

            data.content = $"Sample content {DateTime.Now}";
            Debug.Log(data.content);

            avatar.Commit(data);
            avatar.Push();

            Debug.Log($"Save data to file at path {file}");
        }
    }
}