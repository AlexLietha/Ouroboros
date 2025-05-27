using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 1;
    public GameObject route;
    public float currentTrackPosition;
    public float startingPos;
    public bool moving;
    public float phase;

    public SnakeController controller;
    // Start is called before the first frame update
    void Start() {
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move();
        }
    }


    private void Move()
    {
        phase += speed * Time.deltaTime;

        

        transform.position = new Vector2(route.transform.localScale.x / 2 * Mathf.Cos(phase + startingPos) + route.transform.position.x
                                       , route.transform.localScale.y / 2 * Mathf.Sin(phase + startingPos) + route.transform.position.y);

        Vector3 direction = transform.position - route.transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        //currentTrackPosition = Mathf.Abs(Mathf.Atan2(direction.y, direction.x));

        currentTrackPosition = Mathf.Atan2(direction.y, direction.x);
        if (currentTrackPosition < 0)
        {
            currentTrackPosition += 2 * Mathf.PI;
        }
    }



    public void SetStartPosition(float position)
    {
        startingPos = position;
    }
    public float GetStartPosition()
    {
       return startingPos;
    }
    public float GetTrackPosition()
    {
        return currentTrackPosition;
    }




    

}
