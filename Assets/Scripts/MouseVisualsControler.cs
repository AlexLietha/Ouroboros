using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVisualsControler : MonoBehaviour
{
    public GameObject visualTower;
    public GameObject realTower;
    public int moveSpeed;
    public bool canPlace;
    // Start is called before the first frame update
    void Start()
    {
        realTower = null;
        visualTower = null;
        canPlace = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (visualTower != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            visualTower.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
    }


    
    public void SetVisualTower(GameObject Tower)
    {
        visualTower = Tower;
    }
    public GameObject GetVisualTower()
    {
        return visualTower;
    }


    public void SetRealTower(GameObject Tower)
    {
        realTower = Tower;
    }
    public GameObject GetRealTower()
    {
        return realTower;
    }


    public void SetCanPlace(bool can)
    {
        canPlace = can;
    }
    public bool GetCanPlace()
    {
        return canPlace;
    }
}

