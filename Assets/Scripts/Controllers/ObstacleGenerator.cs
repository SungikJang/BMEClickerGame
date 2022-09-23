using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Obstacles;

    private GameObject Obstacle;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()  
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            MakeObstacle();
            timer = 0;
        }
    }

    private void MakeObstacle()
    {
        Obstacle = Manager.Resource.Instantiate("Prefabs/Obstacle");
        Obstacle.transform.SetParent(Obstacles.transform, false);
        Obstacle.transform.position = new Vector3(15.5f, Random.Range(-6.5f, 0), 0);
    }

    public void ClearObstacle()
    {
        var obstacleTransforms = Obstacles.GetComponentsInChildren<Transform>();

        if (obstacleTransforms != null)
        {
            foreach (var obstacle in obstacleTransforms)
            {
                if (obstacle != Obstacles.transform)
                {
                    Manager.Resource.Destory(obstacle.gameObject);
                }
            }
        }
    }
}
