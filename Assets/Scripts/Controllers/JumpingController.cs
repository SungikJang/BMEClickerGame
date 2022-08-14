using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private Rigidbody2D PlayerRigid;

    [SerializeField]
    private float JumpingPower;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("????");
        if (other.name == "Destroy" || other.name == "Limit") {
            GameObject.Destroy(Player);
        }
    }

    void Start()
    {
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayerRigid.velocity = Vector2.up * JumpingPower;
        }
    }
}
