using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeHeadController : MonoBehaviour
{
    public float speed = 1;
    public int health;
    public GameObject route;
    public float currentTrackPosition;

    public float startingPos;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(route.transform.localScale.x / 2 * Mathf.Cos((speed * Time.time) + startingPos) + route.transform.position.x
                                       , route.transform.localScale.y / 2 * Mathf.Sin((speed * Time.time) + startingPos) + route.transform.position.y);

        Vector3 direction = transform.position - route.transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        currentTrackPosition = Mathf.Abs(Mathf.Atan2(direction.y, direction.x));
    }

    public void SetTrackPosition(float position)
    {
        currentTrackPosition = position;
    }
    public float GetTrackPosition()
    {
        return currentTrackPosition;
    }
 
}
