/*
文件名（File Name）:   ScriptTitleChange.cs

作者（Author）:    老而不死是为妖

创建时间（CreateTime）:  2016-6-1 17:30:20
*/
using UnityEngine;
using System.Collections;
public class PrintGameObjectName : MonoBehaviour
{
    public string name;
    void Awake()
    {
        Debug.Log("My name is " + name.ToString());
    }
    void Start()
    {
    }
    void Update()
    {
    }
}