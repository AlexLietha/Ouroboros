using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementHitboxDetector : MonoBehaviour
{
    public MouseVisualsControler mouseVisuals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("is collided");
        mouseVisuals.SetCanPlace(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mouseVisuals.SetCanPlace(true);

    }
}
