using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject SnakeHead;
    public GameObject currentSnakeBody;
    public GameObject PrefabBody;
    public GameObject SnakeTail;
    public GameObject route;
    public GameObject Parent;
    private float distBetweenHeadBody;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkEndGame();
        if(Vector3.Distance(SnakeHead.transform.position, currentSnakeBody.transform.position) < 0)
        {
            float headPos = SnakeHead.transform.position.magnitude + (2 * Mathf.PI);
            distBetweenHeadBody = headPos - currentSnakeBody.transform.position.magnitude;
        }
        else
        {
            distBetweenHeadBody = Vector3.Distance(SnakeHead.transform.position, currentSnakeBody.transform.position);
        }

        if (distBetweenHeadBody > 1.6f)
        {
            SpawnBody();
        }





    }
    public void checkEndGame()
    {
        if ((SnakeHead.transform.position - SnakeTail.transform.position).magnitude  < .01f)

        {
            Debug.Log("End Game, Bad Ending");
        }
        else if(health <= 0)
        {
            Debug.Log("End Game, Good Ending");
        }
    }


    public void SpawnBody()
    {
       currentSnakeBody = Instantiate(PrefabBody, SnakeHead.transform.position, SnakeHead.transform.rotation, Parent.transform);
        SnakeMovement snakeMovement = currentSnakeBody.GetComponent<SnakeMovement>();
        snakeMovement.route = route;
        snakeMovement.phase = SnakeHead.GetComponent<SnakeMovement>().currentTrackPosition;
        snakeMovement.controller = SnakeHead.GetComponent<SnakeMovement>().controller;

    }

    public void ChangeHealth(int damage)
    {
        health = health - damage;
    }


}
