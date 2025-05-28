using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickUpgradeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UpgradePanel UpgradePanel;
    public int upgradePath;
    public bool isHovered;
    public Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<Image>().color;
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
        UpgradePanel.GetComponent<UpgradePanel>().SelectedTower.GetComponent<TowerController>().Upgrade(upgradePath);
        UpgradePanel.GetComponent<UpgradePanel>().UpdateInformation();
    }
    public void OnPointerClick(PointerEventData eventData)
    {


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered=false;
    }
    
}
