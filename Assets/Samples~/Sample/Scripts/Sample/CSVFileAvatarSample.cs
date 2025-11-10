/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CSVFileAvatarSample.cs
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
    public class CSVFileAvatarSample : FileAvatarSample
    {
        void Start()
        {
            var file = $"{FileDir}/CSVFile.csv";
            var avatar = new CSVFileAvatar(file);

            var data = avatar.Data[0];
            Debug.Log(data[0]);
            Debug.Log(data[1]);

            data[1] = $"Sample content {DateTime.Now}";
            Debug.Log(data[1]);

            avatar.Commit(avatar.Data);
            avatar.Push();

            Debug.Log($"Save data to file at path {file}");
        }
    }
}