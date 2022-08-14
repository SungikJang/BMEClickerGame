using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers
{
    public Constant.Scene NowScene;
    public void LoadScene(Constant.Scene Scene) {
        Manager.Clear();
        SceneManager.LoadScene(System.Enum.GetName(typeof(Constant.Scene), Scene));
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}