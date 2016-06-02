/*
文件名（File Name）:   ScriptTitleChange.cs

作者（Author）:    老而不死是为妖

创建时间（CreateTime）:  2016-6-2 9:50:24
*/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class RunScript : MonoBehaviour
{
    public static readonly string PathURL = "file://" + Application.dataPath + "/StreamingAssets/";
    void Awake()
    {
        //print(Application.dataPath);
        //print(Application.streamingAssetsPath);
    }
    void Start()
    {
    }
    void Update()
    {
    }
    void OnGUI()
    {
        if (GUILayout.Button("分别加载"))
        {
            StartCoroutine(LoadByMain("prefab0"));
            StartCoroutine(LoadByMain("prefab1"));
        }

        if (GUILayout.Button("统一加载"))
        {
            StartCoroutine(LoadByALL("all"));
        }
        if (GUILayout.Button("加载场景"))
        {
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadByMain(string path)
    {
        WWW www = new WWW(PathURL + path);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            GameObject go = www.assetBundle.LoadAsset(path) as GameObject;
            yield return Instantiate(go);
            www.assetBundle.Unload(false);
        }
    }
    IEnumerator LoadByALL(string path)
    {
        WWW www = new WWW(PathURL + path);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            Object[] gos = www.assetBundle.LoadAllAssets();
            foreach (GameObject item in gos)
            {
                yield return Instantiate(item);
            }
            www.assetBundle.Unload(false);
        }
    }
    private IEnumerator LoadScene()
    {
        WWW www = WWW.LoadFromCacheOrDownload("file://" + Application.streamingAssetsPath + "/MyScene.assetbundle",0);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            SceneManager.LoadScene("001");
        }
    }

}