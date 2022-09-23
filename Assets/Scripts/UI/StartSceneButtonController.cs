using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneButtonController : MonoBehaviour
{
    [SerializeField]
    private Button StartButton;
    [SerializeField]
    private Button CloseButton;
    [SerializeField]
    private Button PunchingButton;
    [SerializeField]
    private Button SkiingButton;
    [SerializeField]
    private Button JPaaasingButton;
    [SerializeField]
    private Button jumpingButton;
    [SerializeField]
    private Button StartSceneSet;
    [SerializeField]
    private Button StartSceneMenu;
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject GameOption;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(() =>
        {
            GameOption.SetActive(true);
        });
        CloseButton.onClick.AddListener(() =>
        {
            GameOption.SetActive(false);
        });
        PunchingButton.onClick.AddListener(() => {
            Manager.Scene.LoadScene(Constant.Scene.PunchScene);
            Manager.UI.Init();
        });
        SkiingButton.onClick.AddListener(() => {
            Manager.Scene.LoadScene(Constant.Scene.SkiingScene);
            Manager.UI.Init();
        });
        JPaaasingButton.onClick.AddListener(() => {
            Manager.Scene.LoadScene(Constant.Scene.SkiingScene);
            Manager.UI.Init();
        });
        jumpingButton.onClick.AddListener(() => {
            Manager.Scene.LoadScene(Constant.Scene.JumpingScene);
            Manager.UI.Init();
        });
        StartSceneSet.onClick.AddListener(() => {
        });
        StartSceneMenu.onClick.AddListener(() => {
            if (!Menu.activeSelf) {
                Menu.SetActive(true);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
