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

namespace MGS.FileAvatars.Demo
{
    public class TestJsonFileAvatar : MonoBehaviour
    {
        void Start()
        {
            var file = string.Format("{0}/MGS.Packages/FileAvatar/Demo/Files/JsonFile.json", Application.dataPath);
            var avatar = new JsonFileAvatar<TestInfo>(file);

            var info = avatar.Content;
            Debug.LogFormat("tittle is {0}", info.tittle);

            info.tittle = string.Format("Tittle {0}", DateTime.Now);
            avatar.Commit(info);
            avatar.Push();
        }
    }

    public class TestInfo
    {
        public string tittle;
        public string content;
    }
}