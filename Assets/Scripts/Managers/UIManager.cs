using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    Stack<UI_Base> PopupStack = new Stack<UI_Base>();
    Stack<UI_Base> SceneStack = new Stack<UI_Base>();
    public void ShowPopup<T>(string name) where T : UI_Base {
        GameObject go = Manager.Resource.Instantiate($"Prefabs/Popup/{name}");
        T P = Utils.GetOrAddComponent<T>(go);
        PopupStack.Push(P);
    }
    public void ShowScene<T>(string name) where T : UI_Base {
        GameObject go = Manager.Resource.Instantiate($"Prefabs/Scene/{name}");
        T P = Utils.GetOrAddComponent<T>(go);
        SceneStack.Push(P);
    }
    public void ShowWorldSpaceUI<T>(GameObject root, string name) where T : UI_Base {
        GameObject go = Manager.Resource.Instantiate($"Prefabs/WorldMotherFucker/{name}");
        go.transform.SetParent(root.transform);
        go.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        go.GetComponent<Canvas>().worldCamera = Camera.main;
        T P = Utils.GetOrAddComponent<T>(go);
    }
    public void ClosePopup() {
        UI_Base P = PopupStack.Pop();
        Manager.Resource.Destory(P.gameObject, 0.0f);
    }
    public void Clear() {
        PopupStack.Clear();
        SceneStack.Clear();
    }
}