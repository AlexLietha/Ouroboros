using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Controls playerControls;

    private InputAction cancel;
    private InputAction click;

    public MouseVisualsControler mouseVisual;
    public CheeseManager cheeseManager;

    public Transform towerParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        playerControls = new Controls();
    }
    private void OnEnable()
    {
        cancel = playerControls.UITowers.Cancel;
        click = playerControls.UITowers.Click;
        cancel.Enable();
        click.Enable();

        cancel.performed += Cancel;
        click.performed += Place;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Cancel(InputAction.CallbackContext context)
    {
       mouseVisual.SetVisualTower(null);
       mouseVisual.SetRealTower(null);


    }
    private void Place(InputAction.CallbackContext context)
    {
        
        if (mouseVisual.GetVisualTower() != null && mouseVisual.canPlace && cheeseManager.enoughCheese(mouseVisual.GetRealTower().GetComponent<TowerController>().cost))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject PlacedTower = Instantiate(mouseVisual.GetRealTower(), mousePosition, Quaternion.identity, towerParent);
            cheeseManager.LoseCheese(PlacedTower.GetComponent<TowerController>().cost);
            Cancel(context);
        }
        
    }
}
