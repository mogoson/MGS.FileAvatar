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

namespace MGS.FileAvatars.Demo
{
    public class TestKeyFileAvatar : MonoBehaviour
    {
        void Start()
        {
            var file = string.Format("{0}/MGS.Packages/FileAvatar/Demo/Files/KeyFile.txt", Application.dataPath);
            var avatar = new KeyFileAvatar(file);

            Debug.LogFormat("key0 = {0}", avatar.GetValue("key0"));

            avatar.SetValue("key0", string.Format("Tittle {0}", DateTime.Now));
            avatar.Push();
        }
    }
}