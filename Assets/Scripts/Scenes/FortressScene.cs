using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressScene : BaseScene
{
    public Constant.Scene SceneType {
        get;
        protected set;
    } = Constant.Scene.FortressScene;
    // Start is called before the first frame update
    void Start()
    {
        Manager.Scene.NowScene = Constant.Scene.FortressScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Clear() { 

    }
}
