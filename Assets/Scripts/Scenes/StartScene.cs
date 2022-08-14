using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    public Constant.Scene SceneType {
        get;
        protected set;
    } = Constant.Scene.StartScene;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Clear() { 

    }
}
