using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
    private Action A;
    
    public T Load<T>(string path) where T : UnityEngine.Object {
        //디스크에서 메모리로 LOAD하는과정에서 PoolManager활용
        string name = path.Substring(path.LastIndexOf('/') + 1);
        GameObject go = Manager.Pool.GetOriginal(name);
        if (go != null) {
            return go as T;
        }
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path) {
        //
        GameObject go = Load<GameObject>(path);
        if (go == null) {
            Debug.Log("Fucked up");
            return null;
        }
        if (go.GetComponent<PoolLabel>() != null) {
            return Manager.Pool.Pop(go).gameObject;
        }
        return Object.Instantiate(go);
    }
    public void Destory(GameObject obj, float t = 0.0f) {
        try{
            if (obj == null)
            {
                return;
            }

            Object.Destroy(obj, t);
        }
        catch (Exception e) {
            Debug.LogError(e);
        }
    }

}