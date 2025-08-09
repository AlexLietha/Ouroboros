using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public TMP_Text damageDisplay;
    public GameObject SelectedTower;
   

    public GameObject[] upgradeButtons;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNull()
    {
        SelectedTower = null;
        
        UpdateInformation();
    }

    public void SetInformation(GameObject Tower)
    {
        SelectedTower = Tower;
        UpdateInformation();
    }
    public void UpdateInformation()
    {
        if (SelectedTower == null)
        {
            return;
        }

        
        UpdateButtons();
        damageDisplay.text = "Damage: " + SelectedTower.GetComponent<TowerController>().damageCount;
    }

    public void UpdateButtons()
    {
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].GetComponent<OnClickUpgradeButton>().animatorController.SetInteger("idTower", SelectedTower.GetComponent<TowerController>().id);  
            upgradeButtons[i].GetComponent<OnClickUpgradeButton>().animatorController.SetInteger(upgradeButtons[i].GetComponent<OnClickUpgradeButton>().parameterName, SelectedTower.GetComponent<TowerController>().upgrades[i]);

            //if (SelectedTower.GetComponent<TowerController>().upgrades[i] == SelectedTower.GetComponent<TowerController>().upgradeLimit)
            //{
            //    upgradeButtons[i].GetComponent<Image>().color = Color.white;
            //}
            //else
            //{
            //    upgradeButtons[i].GetComponent<Image>().color = upgradeButtons[i].GetComponent<OnClickUpgradeButton>().originalColor;
            //}
        }
    }

    public bool isUpgrading()
    {
        for (int i = 0; i < upgradeButtons.Length; i++) {
            if (upgradeButtons[i].GetComponent<OnClickUpgradeButton>().isHovered)
            {
                return true;
            }
        }
        return false;
    }
}
