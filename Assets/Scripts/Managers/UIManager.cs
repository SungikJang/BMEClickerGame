using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour {
    Stack<GameObject> PopupStack = new Stack<GameObject>();
    private int _canvasOrder = 10;
    private GameObject _rootUIPopUp = null;
    private GameObject popUpGo = null;
    private GameObject go = null;


    // method
    public void SetCanvas(GameObject go) {
        Canvas canvasComponent = go.GetComponent<Canvas>();
        if (!canvasComponent) {
            canvasComponent = go.AddComponent<Canvas>();
        }

        canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasComponent.overrideSorting = false;
        canvasComponent.sortingOrder = _canvasOrder;

        _canvasOrder += 1;
    }
    public GameObject ShowUIPopUp(string name) {

        go = Manager.Resource.Instantiate($"Prefabs/UI/{name}");
        go.transform.SetParent(_rootUIPopUp.transform);

        PopupStack.Push(go);

        return go;
    }
    public void ClosePopUp() {
        if (PopupStack.Count == 0) {
            return;
        }
        
        popUpGo = PopupStack.Pop();
        Manager.Resource.Destory(popUpGo, 0);
    }

    // life cycle
    public void Init() {
        Debug.Log("시작");
        _rootUIPopUp = GameObject.Find("RootUIPopUp");
        if (!_rootUIPopUp) {
            _rootUIPopUp = new GameObject("RootUIPopUp");
        }
        DontDestroyOnLoad(_rootUIPopUp);
    }
    public void Clear() {
        PopupStack.Clear();
    }
}