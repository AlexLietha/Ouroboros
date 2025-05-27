using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    public TMP_Text damageDisplay;
    public GameObject SelectedTower;
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
        if (SelectedTower != null)
        {
            damageDisplay.text = "Damage: " + SelectedTower.GetComponent<TowerController>().damageCount;
        }
    }
}
