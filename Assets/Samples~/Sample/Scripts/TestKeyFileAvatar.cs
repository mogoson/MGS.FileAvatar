/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestKeyFileAvatar.cs
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
    public class TestKeyFileAvatar : MonoBehaviour
    {
        void Start()
        {
            var file = $"{Application.dataPath}/Assets/Samples/File Avatar/1.0.0/Files/KeyFile.txt";
            var avatar = new KeyFileAvatar(file);

            Debug.Log($"key0 = {avatar.GetValue("key0")}");

            avatar.SetValue("key0", $"Tittle {DateTime.Now}");
            avatar.Push();

            Debug.Log($"Save to file at path {file}");
        }
    }
}