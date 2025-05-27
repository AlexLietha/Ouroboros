using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectTower : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TowerController controller;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<TowerController>();
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
        controller.playerController.GetComponent<PlayerController>().SelectTower(Parent);

    }
    public void OnPointerClick(PointerEventData eventData)
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        controller.ShowRange(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(controller.playerController.GetComponent<PlayerController>().selectedTower != Parent)
        {
            controller.ShowRange(false);
        }

    }
}
