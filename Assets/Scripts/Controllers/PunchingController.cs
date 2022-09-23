using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject endLapTime;
    [SerializeField] 
    private GameObject EnemyPool;
    
    
    private GameObject lapTime;
    
    [SerializeField]
    private PunchSceneButtonController punchSceneButtonController;

    private bool isLeft = true;
    private bool start = false;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Enemy") {
            Debug.Log("DIE");
            lapTime.GetComponent<UI_Laptime>().StartLapTime = false;
            endLapTime.SetActive(true);
            endLapTime.GetComponent<UI_EndJump>().TimeText.text = lapTime.GetComponent<UI_Laptime>().TimeText.text;
            Manager.Resource.Destory(lapTime);
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            gameObject.SetActive(false);
            punchSceneButtonController.EnemyGenerator.enabled = false;
            var enemyTransforms = EnemyPool.GetComponentsInChildren<Transform>();
            if (enemyTransforms != null)
            {
                foreach (var enemy in enemyTransforms)
                {
                    if (enemy != EnemyPool.transform)
                    {
                        Manager.Resource.Destory(enemy.gameObject);
                    }
                }
            }
            Manager.Input.Clear();
        }
    }
    
    
    public void StartGame()
    {
        punchSceneButtonController.EnemyGenerator.enabled = true;
        start = true;
        lapTime = Manager.UI.ShowUIPopUp("UILapTime");
    }
    
    private void Turn(Constant.ButtonEvent evt)
    {
        if (evt == Constant.ButtonEvent.ButtonDown)
        {
            if (isLeft) isLeft = false;
            else isLeft = true;
            transform.Rotate(0,180,0,Space.Self);
        }
    }
    
    
    private void OnEnable()
    {
        Manager.Input.ButtonAction += Turn;
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(start){
            if (isLeft)
            {
                transform.position += Vector3.left * Time.deltaTime;
            }
            else
            {
                transform.position -= Vector3.left * Time.deltaTime;
            }
        }
    }
}
