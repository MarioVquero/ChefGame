using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float moveSpeed = 5f;
    float horMovement;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        RB.velocity = new Vector2(horMovement * moveSpeed, RB.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horMovement = context.ReadValue<Vector2>().x;
    }
}
