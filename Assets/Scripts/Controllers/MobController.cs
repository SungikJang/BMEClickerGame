using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private GameObject player;
    private bool move = true;
    private Rigidbody2D Rigidbody2D;

    [SerializeField] private float velocity = 0.3f;

    public GameObject Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "boxing-glove") {
            Debug.Log("?!??!!?SDFSDFSDFS");
            PunchAway();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        transform.GetChild(0).gameObject.layer = 8;
        var x = player.transform.position.x - transform.position.x;
        if (x > 0)
        {
            transform.Rotate(0,180,0,Space.Self);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(move){
            var x = player.transform.position.x - transform.position.x;
            transform.position += (new Vector3(x, 0, 0) * Time.deltaTime * velocity);
            velocity += 0.002f;
        }
    }

    void PunchAway()
    {
        move = false;
        var x = player.transform.position.x - transform.position.x;
        if (x > 0)
        {
            Rigidbody2D.AddForce(new Vector2(-50,50), ForceMode2D.Impulse);
        }
        else
        {
            Rigidbody2D.AddForce(new Vector2(50,50), ForceMode2D.Impulse);
        }
    }
}
