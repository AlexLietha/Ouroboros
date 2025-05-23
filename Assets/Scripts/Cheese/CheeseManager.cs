using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class CheeseManager : MonoBehaviour
{
    public int cheese;
    public TMP_Text cheeseAmountDisplay;
    // Start is called before the first frame update
    void Start()
    {
        cheeseAmountDisplay.text = "Cheese: " + cheese;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GainCheese(int cheese)
    {
        this.cheese = this.cheese + cheese;
        cheeseAmountDisplay.text = "Cheese: " + this.cheese;
    }
    public void LoseCheese(int cheese)
    {
        this.cheese = this.cheese - cheese;
        cheeseAmountDisplay.text = "Cheese: " + this.cheese;
    }
    public bool enoughCheese(int requestedCheese)
    {
        if (cheese - requestedCheese >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
