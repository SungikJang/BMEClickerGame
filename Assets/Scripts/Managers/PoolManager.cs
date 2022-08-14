using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool {
    public GameObject Original { get; set; }
    Stack<PoolLabel> PoolLabels = new Stack<PoolLabel>();
    public void Init(GameObject go, int count) {
        Original = go;
        for (int i = 0; i < count; i++) {
            GameObject gO = Object.Instantiate<GameObject>(Original);
            PoolLabels.Push(gO.GetComponent<PoolLabel>());
        }
    }
    public PoolLabel Pop() {
        if (PoolLabels.Count == 0) {
            GameObject go = Object.Instantiate<GameObject>(Original);
            PoolLabels.Push(go.GetComponent<PoolLabel>());
        }
        PoolLabel PoolLabel = PoolLabels.Pop();
        PoolLabel.gameObject.SetActive(true);
        return PoolLabel;
    }
    public void Push(PoolLabel p) {
        p.gameObject.SetActive(false);
        PoolLabels.Push(p);
    }
}
public class PoolManager {
    Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();
    public void CreatePool(GameObject go, int count = 5) {
        Pool p = new Pool();
        p.Init(go, count);
        _pools.Add(go.name, p);
    }
    public GameObject GetOriginal(string name) {
        if (_pools.ContainsKey(name) == false) {
            return null;
        }
        Pool pool;
        _pools.TryGetValue(name, out pool);
        return pool.Original;
    }
    public PoolLabel Pop(GameObject go) {
        if (_pools.ContainsKey(go.name) == false) {
            CreatePool(go);
        }
        return _pools[go.name].Pop();
    }
    public void Push(PoolLabel p) {
        _pools[p.gameObject.name].Push(p);
    }
}