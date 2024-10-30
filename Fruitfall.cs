using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitfall : MonoBehaviour
{
    // Start is called before the first frame update

    private string inthecloud = "y";
    void Start()
    {
        if (transform.position.y< 3.10){
            inthecloud = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inthecloud == "y"){
            GetComponent<Transform>().position = Circlemov.cloudxPos;
        }

        if(Input.GetKeyDown("space")){
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inthecloud = "n";
            Circlemov.spawnedYet = "n";

        }
        // if (transform.position.y >= 3.1f) // Check if fruit is above the threshold
        // {
        //     LoseGame();
        // }
    }

     private void LoseGame()
    {
        Time.timeScale = 0;
        Debug.Log("You Lost!");
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag==gameObject.tag){

            Circlemov.spawnPos = transform.position;

            Circlemov.newfruit = "y";
            Circlemov.whichfruit = int.Parse(gameObject.tag);

            Destroy(gameObject);

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); 
            if (scoreManager != null)
            {
                int pointsToAdd = 0;
                switch (gameObject.tag)
                {
                    case "0":
                        pointsToAdd = 1;
                        break;
                    case "1":
                        pointsToAdd = 2;
                        break;
                    case "2":
                        pointsToAdd = 3;
                        break;
                    case "3":
                        pointsToAdd = 5;
                        break;
                    // Add more cases if needed
                }
                scoreManager.IncreaseScore(pointsToAdd);
            }
        }
        
    }
}
