using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RarmScript : MonoBehaviour
{

    public HingeJoint2D hJoint2D;
    private JointMotor2D motor2D;

    private bool hitLimit;

    // Start is called before the first frame update
    void Start()
    {
        hJoint2D = GetComponent<HingeJoint2D>();
        motor2D = hJoint2D.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            // JointMotor2D motor = hJoint2D.motor;
            // motor.motorSpeed = -100;
            // hJoint2D.motor = motor;
            motor2D.motorSpeed = -100;
            hJoint2D.motor = motor2D;
            

        }
        else 
        {
            // JointMotor2D motor = hJoint2D.motor;
            // motor.motorSpeed = 50;
            // // hJoint2D.motor = motor;
            motor2D.motorSpeed = 25;
            hJoint2D.motor = motor2D;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("limit"))
        {
            // Debug.Log("hit limit");
            motor2D.motorSpeed = 0;
            hJoint2D.motor = motor2D;
        }
    }
}
