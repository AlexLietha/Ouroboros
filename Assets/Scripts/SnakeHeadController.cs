using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeHeadController : MonoBehaviour
{
    private int speed = 1;
    private float rotSpeed = 0;
    public int health;
    public GameObject route;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(move());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator move()
    {
        while (true)
        {
            transform.position = new Vector2(route.transform.localScale.x / 2 * Mathf.Cos(speed * Time.time) + route.transform.position.x
                                            , route.transform.localScale.y / 2 * Mathf.Sin(speed * Time.time) + route.transform.position.y);
            rotSpeed += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, rotSpeed * Mathf.Rad2Deg);

            yield return null;
            
        }
        yield return null;
    }
}
