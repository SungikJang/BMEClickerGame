using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Button fortressButton;
    [SerializeField]
    private Button jumpingButton;
    [SerializeField]
    private Button StartSceneSet;
    [SerializeField]
    private Button StartSceneMenu;
    [SerializeField]
    private GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (Manager.Scene.NowScene)
        {
            case Constant.Scene.StartScene:
                this.fortressButton.onClick.AddListener(() => {
                    Manager.Scene.LoadScene(Constant.Scene.FortressScene);
                });
                this.jumpingButton.onClick.AddListener(() => {
                    Manager.Scene.LoadScene(Constant.Scene.JumpingScene);
                });
                this.StartSceneSet.onClick.AddListener(() => {
                });
                this.StartSceneMenu.onClick.AddListener(() => {
                    if (!Menu.activeSelf) {
                        Menu.SetActive(true);
                    }
                });
                break;
        }

    }
}
