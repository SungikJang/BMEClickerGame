using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private Rigidbody2D PlayerRigid;

    [SerializeField]
    private float JumpingPower;

    private GameObject lapTime;
    
    [SerializeField]
    private GameObject endLapTime;

    [SerializeField]
    private JumpingSceneButtonController jumpingSceneButtonController;

    // Start is called before the first frame update

    public void StartGame()
    {
        jumpingSceneButtonController.ObstacleGenerator.enabled = true;
        jumpingSceneButtonController.BackGroundAnimator.enabled = true;
        PlayerRigid.bodyType = RigidbodyType2D.Dynamic;
        lapTime = Manager.UI.ShowUIPopUp("UILapTime");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("????");
        if (other.name == "Destroy" || other.name == "Limit") {
            jumpingSceneButtonController.ObstacleGenerator.ClearObstacle();
            jumpingSceneButtonController.ObstacleGenerator.enabled = false;
            jumpingSceneButtonController.BackGroundAnimator.enabled = false;
            lapTime.GetComponent<UI_Laptime>().StartLapTime = false;
            endLapTime.SetActive(true);
            endLapTime.GetComponent<UI_EndJump>().TimeText.text = lapTime.GetComponent<UI_Laptime>().TimeText.text;
            Manager.Resource.Destory(lapTime);
            PlayerRigid.bodyType = RigidbodyType2D.Kinematic;
            gameObject.SetActive(false);
            Manager.Input.Clear();
        }
    }

    private void JumpUp(Constant.ButtonEvent evt)
    {
        if (evt == Constant.ButtonEvent.ButtonDown)
        {
            PlayerRigid.velocity = Vector2.up * JumpingPower;
        }
    }

    private void OnEnable()
    {
        Manager.Input.ButtonAction += JumpUp;
    }

    void Start()
    {
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        PlayerRigid.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
