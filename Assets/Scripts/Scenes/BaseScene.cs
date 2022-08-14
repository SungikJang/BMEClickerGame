using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour {
    protected virtual void Init() {
        Object go = GameObject.FindObjectOfType(typeof(EventSystem));
        if (go == null) {
            GameObject eventsystem = Manager.Resource.Instantiate("Prefabs/EventSystem");
            eventsystem.name = "@EventSystem";
        }
        Screen.SetResolution(640, 480, false);
    }
    public abstract void Clear();
}