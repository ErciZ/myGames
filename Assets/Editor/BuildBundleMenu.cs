using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BuildBundleMenu : MonoBehaviour
{

    public static string sourcePathPrefab = Application.dataPath + "/_Creepy_Cat/Realistic_Weather_Effects/_Prefabs/";
    public static string sourcePathMater = Application.dataPath + "/_Creepy_Cat/Realistic_Weather_Effects/_Materials/";

#if UNITY_EDITOR
    [MenuItem("Example/Build Asset Bundles")]
    static void BuildABs()
    {

        ClearAssetBundlesName();

        FindAllFile(sourcePathPrefab);
        FindAllFile(sourcePathMater);

        // Put the bundles in a folder called "ABs" within the Assets folder.
        BuildPipeline.BuildAssetBundles("Assets/ABs", BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneOSXIntel64);
    }


    /// <summary> 
    /// 清除之前设置过的AssetBundleName，避免产生不必要的资源也打包 
    /// 之前说过，只要设置了AssetBundleName的，都会进行打包，不论在什么目录下 
    /// </summary> 
    static void ClearAssetBundlesName()
    {
        int length = AssetDatabase.GetAllAssetBundleNames().Length;
        Debug.Log(length);
        string[] oldAssetBundleNames = new string[length];
        for (int i = 0; i < length; i++)
        {
            oldAssetBundleNames[i] = AssetDatabase.GetAllAssetBundleNames()[i];
        }

        for (int j = 0; j < oldAssetBundleNames.Length; j++)
        {
            AssetDatabase.RemoveAssetBundleName(oldAssetBundleNames[j], true);
        }
        length = AssetDatabase.GetAllAssetBundleNames().Length;
        Debug.Log(length);
    }

    /// <summary>
    /// 遍历文件夹里面的所有文件夹和文件
    /// </summary>
    /// <param name="source"></param>
    static void FindAllFile(string source)
    {
        DirectoryInfo folder = new DirectoryInfo(source);
        FileSystemInfo[] files = folder.GetFileSystemInfos();
        int length = files.Length;
        for (int i = 0; i < length; i++)
        {
            if (files[i] is DirectoryInfo)
            {
                FindAllFile(files[i].FullName);
            }
            else
            {
                if (!files[i].Name.EndsWith(".meta"))
                {
                    SetAssetName(files[i].FullName);
                }
            }
        }
    }

    /// <summary>
    /// 为需要打包的文件设置assetName.
    /// </summary>
    /// <param name="source"></param>
    static void SetAssetName(string source)
    {
        string _assetPath = "Assets" + source.Substring(Application.dataPath.Length);
        //string _assetPath2 = source.Substring (Application.dataPath.Length + 1);  
        //在代码中给资源设置AssetBundleName 
        AssetImporter assetImporter = AssetImporter.GetAtPath(_assetPath);
        //string assetName = _assetPath2.Substring (_assetPath2.IndexOf("/") + 1); 
        //assetName = assetName.Replace(Path.GetExtension(assetName),".unity3d"); 
        //assetImporter.assetBundleName = assetName;
        assetImporter.assetBundleName = "Weather.unity3d";
    }
#endif
}