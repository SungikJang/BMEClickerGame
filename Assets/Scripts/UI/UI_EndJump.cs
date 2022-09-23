using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndJump : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Button reStartBtn;
    [SerializeField] private Button exitBtn;
    [SerializeField] private GameObject Choice;
    // Start is called before the first frame update

    public Text TimeText
    {
        get
        {
            return timeText;
        }
        set
        {
            if (timeText == value) return;
            timeText = value;
            return;
        }
    }
    void Start()
    {
        reStartBtn.onClick.AddListener(() => {
            Choice.SetActive(true);
            gameObject.SetActive(false);
        });
        exitBtn.onClick.AddListener(() => {
            Manager.Scene.LoadScene(Constant.Scene.StartScene);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
