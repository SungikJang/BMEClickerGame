using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UI_CountDown : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    private float time = 3;
    private Color alpha;
    private float alphaSpeed;
    private bool FadeOutStart = false;
    private bool Started = false;

    void Start() {
        alphaSpeed = 1.5f;
        alpha = timeText.color;
    }

    void Update() {
        if (FadeOutStart)
        {
            alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
            timeText.color = alpha;
        }
        else
        {
            time -= Time.deltaTime;
            if (time > 2)
            {
                timeText.text = "3";
            }
            else if (time > 1)
            {
                timeText.text = "2";
            }
            else if (time > 0)
            {
                timeText.text = "1";
            }
            else if (time > -1)
            {
                timeText.text = "0";
            }
            else
            {
                timeText.text = "Start!";
                Manager.Resource.Destory(gameObject, 2);
                switch (Manager.Scene.NowScene)
                {
                    case Constant.Scene.JumpingScene:
                        GameObject.Find("JumpingSceneButtonController").GetComponent<JumpingSceneButtonController>().BirdOnControl.StartGame();
                        break;
                    case Constant.Scene.SkiingScene:
                        break;
                    case Constant.Scene.PunchScene:
                        GameObject.Find("PunchSceneButtonController").GetComponent<PunchSceneButtonController>().CharacterOnControl.StartGame();
                        break;
                    case Constant.Scene.SlidingScene:
                        break;
                    case Constant.Scene.JumpPassScene:
                        break;
                }
                FadeOutStart = true;
            }
        }
    }
}
