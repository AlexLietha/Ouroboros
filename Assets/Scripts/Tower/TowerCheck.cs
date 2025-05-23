using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerCheck : MonoBehaviour
{
    private List<GameObject> SnakeParts;
    // Start is called before the first frame update
    void Start()
    {
        SnakeParts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FindClosestPart()
    {
        GameObject closest = SnakeParts[0];
        foreach (GameObject c in SnakeParts)
        {
            if ((transform.position - c.transform.position).magnitude < (transform.position - closest.transform.position).magnitude)
            {
                closest = c;
            }
        }
        return closest;
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snake"))
        {
            SnakeParts.Add(collision.gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (SnakeParts!=null && SnakeParts.Count != 0)
        {
            StartCoroutine(transform.GetComponentInParent<TowerController>().Throw(FindClosestPart()));
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Snake"))
        {
            SnakeParts.Remove(collision.gameObject);
        }

    }
}
