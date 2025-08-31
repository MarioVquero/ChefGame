using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{


    public GameObject[] Ingredients;

    public float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            Instantiate(Ingredients[Random.Range(0, 3)], gameObject.GetComponent<Transform>().position, Quaternion.identity);
            timer = 0;
        }
    }
}
