using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{

    public GameObject player;
    public Transform moveDirection;
    public Rigidbody2D RB;
    public float moveSpeed = 20f;
    public Vector3 moveSpeed2;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("move left");
            // RB.AddForce(moveDirection.forward * -moveSpeed);
            RB.MovePosition(new Vector2(moveSpeed2.x * Time.deltaTime, 0));
            
        }

        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("move Right");    
            RB.AddForce(moveDirection.forward * moveSpeed);

        }
    }
}
