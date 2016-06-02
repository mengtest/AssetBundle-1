/*
文件名（File Name）:   ScriptTitleChange.cs

作者（Author）:    老而不死是为妖

创建时间（CreateTime）:  2016-6-1 17:34:21
*/
using UnityEngine;
using System.Collections;
using UnityEditor;
public class CreatAssetBundles : MonoBehaviour
{
    [MenuItem("CreatAssetBundles/Main")]
    public static void CreatAssetBundlesMain()
    {
        //获取在Project视图中选择的所有游戏对象
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        foreach (Object obj in SelectedAsset )
        {
            AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

            buildMap[0].assetBundleName = obj.name;
            string[] assetNames = new string[1];
            assetNames[0] = "Assets/Prefabs/" + obj.name.ToString() + ".prefab";
            buildMap[0].assetNames = assetNames;
            if (BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", buildMap))
            {
                Debug.Log("资源打包成功");
            }
            else
            {
                Debug.Log("资源打包失败");
            }
        }
        AssetDatabase.Refresh();	
    }
    [MenuItem("CreatAssetBundles/All")]
    public static void CreateAssetBunldesALL()
    {

        Caching.CleanCache();

        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];
        buildMap[0].assetBundleName = "All";
        string[] assetNames = new string[SelectedAsset.Length];
        for (int i = 0; i < SelectedAsset.Length; i++)
        {
            assetNames[i] = "Assets/Prefabs/" + SelectedAsset[i].name.ToString() + ".prefab";            
        }
        buildMap[0].assetNames = assetNames;
        if (BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", buildMap))
        {
            Debug.Log("资源打包成功");
        }
        else
        {
            Debug.Log("资源打包失败");
        }
        AssetDatabase.Refresh();	
    }
    [MenuItem("CreatAssetBundles/Scene")]
    public static void CreateSceneALL()
    {
        Caching.CleanCache();
        string Path = Application.streamingAssetsPath + "/MyScene.assetbundle";
        string[] levels = { "Assets/Scenes/001.unity" };
        //打包场景
        BuildPipeline.BuildPlayer(levels, Path, BuildTarget.WebPlayer, BuildOptions.BuildAdditionalStreamedScenes);
        AssetDatabase.Refresh();
    }
}