using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Circlemov : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] fruitobj;
    static public string spawnedYet = "n";
    static public Vector2 cloudxPos;
    static public Vector2 spawnPos;
    static public string newfruit="n";
    static public int whichfruit=0;
    void Start()
    {
        
    }

    void Update()
    {
        SpawnFruit();
        ReplaceFruit();

        if (Input.GetKey("a")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2,0);
        }

        if (Input.GetKey("d")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(2,0);
        }

        if ((!Input.GetKey("a")) && (!Input.GetKey("d"))){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

        cloudxPos = transform.position;

        // if (cachedTransform.position.y >= 3.11f) // Check if fruit is above the threshold
        // {
        //     GameOver();
        // }
    }

    void SpawnFruit()
    {
        if (spawnedYet =="n")
        {
            StartCoroutine(Spawntimer());
            spawnedYet="y";
        }

    }
    void ReplaceFruit(){

        if (newfruit=="y"){
            newfruit="n";
            Instantiate(fruitobj[whichfruit+1], spawnPos, fruitobj[0].rotation);

        }
    }

    IEnumerator Spawntimer()
    {
        yield return new WaitForSeconds(.75f);
        Instantiate(fruitobj[Random.Range(0,4)], transform.position, fruitobj[0].rotation);
    }


}
