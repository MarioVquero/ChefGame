using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarmScript : MonoBehaviour
{

    public HingeJoint2D hingeJoint2D;
    JointMotor2D motor2D;


    // Start is called before the first frame update
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        motor2D.maxMotorTorque = 10000;
        if (Input.GetKey(KeyCode.W))
        {
            motor2D.motorSpeed = 100;
            hingeJoint2D.motor = motor2D;
        }
        else
        {
            motor2D.motorSpeed = -25;
            hingeJoint2D.motor = motor2D;

        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("limit"))
        {
            // Debug.Log("hit limit");
            // motor2D.motorSpeed = 0;
            hingeJoint2D.motor = motor2D;
        }
    }
}
