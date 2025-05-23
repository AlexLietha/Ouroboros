using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementHitboxDetector : MonoBehaviour
{
    public MouseVisualsControler mouseVisuals;
    public int collisionCount;
    // Start is called before the first frame update
    void Start()
    {
        collisionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            collisionCount++;
            mouseVisuals.SetCanPlace(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            collisionCount--;
            if (collisionCount == 0)
            {
                mouseVisuals.SetCanPlace(true);
            }
        }
    }
}
