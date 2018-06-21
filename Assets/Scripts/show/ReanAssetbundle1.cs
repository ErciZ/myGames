//using UnityEngine;
//using System.Collections;

//public class ReanAssetbundle1 : MonoBehaviour
//{

//    //不同平台下StreamingAssets的路径是不同的，这里需要注意一下。  
//    public static readonly string m_PathURL =
//#if UNITY_ANDROID
//        "jar:file://" + Application.dataPath + "!/assets/";  
//#elif UNITY_IPHONE
//        Application.dataPath + "/Raw/";  
//#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
//        "file://" + Application.dataPath + "/AssetBundleLearn/StreamingAssets/equipment/";
//#else
//        string.Empty;  
//#endif

//    void OnGUI()
//    {
//        if (GUILayout.Button("加载分开打包的Assetbundle"))
//        {
//            StartCoroutine(LoadGameObjectPackedByThemselves(m_PathURL + "31001.ab"));
                   
//        }



//    }
//    //单独读取资源  
//    private IEnumerator LoadGameObjectPackedByThemselves(string path)
//    {
//        WWW bundle = new WWW(path);
//        yield return bundle;

//        //加载  
//        yield return Instantiate(bundle.assetBundle.mainAsset);
//        bundle.assetBundle.Unload(false);
//    }

    
//}
