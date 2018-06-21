using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateAssetBundles  {

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
		string dir = Application.dataPath + "/StreamingAssets";
        if( Directory.Exists(dir)==false)
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
		AssetDatabase.Refresh();
        
    }
	
}
