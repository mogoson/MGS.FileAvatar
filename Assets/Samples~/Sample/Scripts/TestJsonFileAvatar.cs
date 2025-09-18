/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestJsonFileAvatar.cs
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
    public class TestJsonFileAvatar : MonoBehaviour
    {
        void Start()
        {
            var file = $"{Application.dataPath}/Assets/Samples/File Avatar/1.0.0/Files/JsonFile.json";
            var avatar = new JsonFileAvatar<TestInfo>(file);

            var info = avatar.Content;
            Debug.Log($"tittle is {info.tittle}");

            info.tittle = $"Tittle {DateTime.Now}";
            avatar.Commit(info);
            avatar.Push();

            Debug.Log($"Save to file at path {file}");
        }
    }

    public class TestInfo
    {
        public string tittle;
        public string content;
    }
}