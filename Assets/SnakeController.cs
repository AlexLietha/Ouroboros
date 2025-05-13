using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject SnakeHead;
    public GameObject currentSnakeBody;
    public GameObject SnakeTail;
    public float distBetweenHeadBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distBetweenHeadBody = Vector3.Distance(SnakeHead.transform.position, currentSnakeBody.transform.position);
        //Debug.Log(Vector3.Distance(SnakeHead.transform.position, currentSnakeBody.transform.position));
        if (distBetweenHeadBody > 1.5f)
        {
            Debug.Log("AHHHHHHHHHHHHHHHHHHH");
            currentSnakeBody = Instantiate(currentSnakeBody, SnakeHead.transform.position, Quaternion.identity);
            currentSnakeBody.GetComponent<SnakeHeadController>().SetTrackPosition(SnakeHead.GetComponent<SnakeHeadController>().GetTrackPosition() - .25f);
        }
    }
}
