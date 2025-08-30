using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarmScript : MonoBehaviour
{

    public Rigidbody2D RB;
    public float movingForce = 20f;
    public Transform moveDirec;

    public Vector2 moveup;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RB.AddForce(moveDirec.up * movingForce);
            // moveDirec.Translate(0, Time.deltaTime, 0, Space.World);
            
        }
    }
}
