using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scalewidth = ((float) Screen.width / Screen.height) / ((float) 9 / 16);
        float scaleheight = 1f / scalewidth;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }

        camera.rect = rect;
    }*/

    //private void OnPreCull() => GL.Clear(true, true, Color.black);

    // Update is called once per frame
    void Update()
    {
        
    }
}
