//#define DEVELOP

using UnityEngine;

namespace MGS.FileAvatar.Sample
{
    public class FileAvatarSample : MonoBehaviour
    {
        protected string FileDir
        {
            get
            {
#if DEVELOP
                var fileDir = $"{Application.dataPath}/Samples/Sample/Files";
#else
                var fileDir = $"{Application.dataPath}/Samples/File Avatar/1.0.0/Files";
#endif
                return fileDir;
            }
        }
    }
}