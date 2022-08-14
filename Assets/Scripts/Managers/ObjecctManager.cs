using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager {
    List<GameObject> gameObjects = new List<GameObject>();

    public void Add(GameObject go) {
        gameObjects.Add(go);
    }

    public GameObject Find(Vector3Int cellPos) {
        foreach (GameObject go in gameObjects) {
            BaseController BaseController = go.GetComponent<BaseController>();
            if (BaseController == null) {

            }
            if (BaseController.CellPos == cellPos) {
                return go;
            }
        }
        return null;
    }

    public void Remove(GameObject go) {
        gameObjects.Remove(go);
    }
    public void Clear() {
        gameObjects.Clear();
    }
}