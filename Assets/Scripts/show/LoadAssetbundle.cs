using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetbundle : MonoBehaviour
{

    private string pathurl = "";
    // Use this for initialization
    void Start()
    {
        string pathPrefab = "file://" + Application.dataPath + "/ABs/weather.unity3d";

        StartCoroutine(LoadALLGameObject(pathPrefab));
    }

    //读取全部资源 
    private IEnumerator LoadALLGameObject(string path)
    {

        WWW bundle = new WWW(path);

        yield return bundle;

        //通过Prefab的名称把他们都读取出来 
        Object obj0 = bundle.assetBundle.LoadAsset("CloudStorm_02_8x8-64.prefab");

        //加载到游戏中    
        yield return Instantiate(obj0);
        bundle.assetBundle.Unload(false);
    }
}