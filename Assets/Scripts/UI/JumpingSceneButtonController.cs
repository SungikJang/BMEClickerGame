using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingSceneButtonController : MonoBehaviour
{
    [SerializeField]
    private Button PinkBirdButton;
    [SerializeField]
    private Button YellowBirdButton;
    [SerializeField]
    private Button CyanBirdButton;
    [SerializeField]
    private Button SettingButton;

    [SerializeField]
    private ObstacleGenerator obstacleGenerator;
    [SerializeField]
    private Animator backGroundAnimator;
    
    [SerializeField]
    private GameObject PinkBird;
    [SerializeField] 
    private GameObject YellowBird;
    [SerializeField]
    private GameObject CyanBird;
    
    [SerializeField]
    private GameObject ChoiceMenu;
    
    private JumpingController birdOnControl;

    public JumpingController BirdOnControl
    {
        get
        {
            return birdOnControl;
        }
        set
        {
            if (birdOnControl == value) {
                return;
            }
            birdOnControl = value;
        }
    }
    
    public Animator BackGroundAnimator
    {
        get
        {
            return backGroundAnimator;
        }
        set
        {
            if (backGroundAnimator == value) {
                return;
            }
            backGroundAnimator = value;
        }
    }
    
    public ObstacleGenerator ObstacleGenerator
    {
        get
        {
            return obstacleGenerator;
        }
        set
        {
            if (obstacleGenerator == value) {
                return;
            }
            obstacleGenerator = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Manager.Scene.NowScene = Constant.Scene.JumpingScene;
        obstacleGenerator.enabled = false;
        backGroundAnimator.enabled = false;
        SettingButton.onClick.AddListener(() => {
            
        });
        PinkBirdButton.onClick.AddListener(() => {
            LapStart(PinkBird);
        });
        YellowBirdButton.onClick.AddListener(() => {
            LapStart(YellowBird);
        });
        CyanBirdButton.onClick.AddListener(() => {
            LapStart(CyanBird);
        });
    }


    void LapStart(GameObject bird)
    {
        bird.SetActive(true);
        bird.transform.localPosition = new Vector3(-5.73999977f, 0.0846055597f, 0.0701884776f);
        birdOnControl = bird.GetComponent<JumpingController>();
        ChoiceMenu.SetActive(false);
        Manager.UI.ShowUIPopUp("UICountDown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
