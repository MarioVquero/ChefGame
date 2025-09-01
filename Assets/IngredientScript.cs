using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IngredientScript : MonoBehaviour
{

    [SerializeField] public float timer;

    public Sprite sprite1;
    public Sprite sprite2;

    public float scoreGiven;

    public SpriteRenderer spriteRenderer;

    public int decayStatus = 0;

    public GameManagerScript gameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManagerScript = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        scoreGiven = 1f;
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
    }
}
