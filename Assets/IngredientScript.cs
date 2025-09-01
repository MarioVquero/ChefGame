using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IngredientScript : MonoBehaviour
{


    public bool canJump;

    public Sprite sprite1;
    public Sprite sprite2;
    public SpriteRenderer spriteRenderer;

    public Rigidbody2D RB;
    public Transform transform;
    public float timer;
    public float scoreGiven;
    public float jumpforce;
    public int decayStatus = 0;

    public GameManagerScript gameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        RB = GetComponent<Rigidbody2D>();

        scoreGiven = 1f;
        jumpforce = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            decayStatus++;
            timer = 0;
        }

        if (decayStatus == 1)
        {
            spriteRenderer.sprite = sprite1;
            scoreGiven = 0.5f;

        }
        else if (decayStatus == 2)
        {
            spriteRenderer.sprite = sprite2;
            gameManagerScript.lives--;
            gameManagerScript.UpdateLivesDisplay(gameManagerScript.lives);
        }
        else if (decayStatus == 3)
        {
            Destroy(gameObject);
        }



    }
     /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            RB.AddForce(transform.up * jumpforce);
            Debug.Log("Jump" + jumpforce);
            canJump = false;
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            Destroy(gameObject);
            gameManagerScript.score += scoreGiven;
        }
        else if (collision.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject);
            gameManagerScript.lives--;
            gameManagerScript.UpdateLivesDisplay(gameManagerScript.lives);
        }

        if (collision.gameObject.CompareTag("tray"))
        {
            canJump = true;
        }
        else
            canJump = false;
    }
}
