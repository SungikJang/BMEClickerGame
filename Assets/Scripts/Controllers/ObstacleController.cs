using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    // Start is called before the first frame update

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("????");
        if (other.name == "Destroy") {
            GameObject.Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * velocity;
    }
}
