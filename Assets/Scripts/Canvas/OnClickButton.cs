using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class OnClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject RealTower;
    public GameObject VisualTower;
    public MouseVisualsControler mouseVisual;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        createVisualTower();


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Highlight button?

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //unhighlight Button?

    }
    public void createVisualTower()
    {
        mouseVisual.SetVisualTower(VisualTower);
        mouseVisual.SetRealTower(RealTower);

    }
}
