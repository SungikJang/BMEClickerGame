using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private GameObject Obstacle;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()  
    {
        this.timer += Time.deltaTime;
        if (this.timer > 2f)
        {
            this.MakeObstacle();
            this.timer = 0;
        }
    }

    private void MakeObstacle()
    {
        this.Obstacle = Manager.Resource.Instantiate("Prefabs/Obstacle");
        this.Obstacle.transform.position = new Vector3(15.5f, Random.Range(-6.5f, 0), 0);
    }
    
    
}
