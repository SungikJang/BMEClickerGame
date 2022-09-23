using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchSceneButtonController : MonoBehaviour
{
     [SerializeField]
    private Button MaskDudeButton;
    [SerializeField]
    private Button NinjaFrogButton;
    [SerializeField]
    private Button PinkManButton;
    [SerializeField]
    private Button VirtualGuyButton;
    [SerializeField]
    private Button SettingButton;
    

    [SerializeField]
    private EnemyGenerator enemyGenerator;

    [SerializeField]
    private GameObject MaskDude;
    [SerializeField] 
    private GameObject NinjaFrog;
    [SerializeField]
    private GameObject PinkMan;
    [SerializeField]
    private GameObject VirtualGuy;
    
    [SerializeField]
    private GameObject ChoiceMenu;
    
    private PunchingController characterOnControl;

    public PunchingController CharacterOnControl
    {
        get
        {
            return characterOnControl;
        }
        set
        {
            if (characterOnControl == value) {
                return;
            }
            characterOnControl = value;
        }
    }

    public EnemyGenerator EnemyGenerator
    {
        get
        {
            return enemyGenerator;
        }
        set
        {
            if (enemyGenerator == value) {
                return;
            }
            enemyGenerator = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Manager.Scene.NowScene = Constant.Scene.PunchScene;
        enemyGenerator.enabled = false;
        SettingButton.onClick.AddListener(() => {
            
        });
        MaskDudeButton.onClick.AddListener(() => {
            LapStart(MaskDude);
        });
        NinjaFrogButton.onClick.AddListener(() => {
            LapStart(NinjaFrog);
        });
        PinkManButton.onClick.AddListener(() => {
            LapStart(PinkMan);
        });
        VirtualGuyButton.onClick.AddListener(() => {
            LapStart(VirtualGuy);
        });
    }


    void LapStart(GameObject character)
    {
        character.SetActive(true);
        enemyGenerator.Player = character;
        ChoiceMenu.SetActive(false);
        characterOnControl = character.GetComponent<PunchingController>();
        Manager.UI.ShowUIPopUp("UICountDown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
