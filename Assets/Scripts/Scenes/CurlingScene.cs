using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurlingScene : BaseScene
{
    public Constant.Scene SceneType {
        get;
        protected set;
    } = Constant.Scene.CurlingScene;
    // Start is called before the first frame update
    void Start()
    {
        Manager.Scene.NowScene = Constant.Scene.CurlingScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Clear() { 

    }
}
