using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OnClickTower : MonoBehaviour
{
    public GameObject RealTower;
    public GameObject VisualTower;
    public MouseVisualsControler mouseVisual;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createVisualTower()
    {
        Debug.Log("Button Clicked");
        mouseVisual.SetVisualTower(VisualTower);
        mouseVisual.SetRealTower(RealTower);

    }
}
