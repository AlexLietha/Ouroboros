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
    public SnakeController snakeController;

    public Transform towerParent;
    public GameObject selectedTower;

    public GameObject panelSelect;
    public GameObject panelUpgrade;

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
        click.performed += Click;
    }

   

    private void Cancel(InputAction.CallbackContext context)
    {
        mouseVisual.GetVisualTower().transform.position = new Vector2 (-100, 100);   
       mouseVisual.SetVisualTower(null);
       mouseVisual.SetRealTower(null);


    }
    private void Click(InputAction.CallbackContext context)
    {
        if ((selectedTower != null))
        {
            selectedTower.GetComponent<TowerController>().ShowRange(false);
            selectedTower = null;
            panelSelect.SetActive(true);
            panelUpgrade.GetComponent<UpgradePanel>().SetNull();
            panelUpgrade.SetActive(false);


        }
        if (mouseVisual.GetVisualTower() != null && mouseVisual.canPlace && cheeseManager.enoughCheese(mouseVisual.GetRealTower().GetComponent<TowerController>().cost))
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject PlacedTower = Instantiate(mouseVisual.GetRealTower(), mousePosition, Quaternion.identity, towerParent);
            PlacedTower.GetComponent<TowerController>().playerController = this.gameObject;
            SelectTower(PlacedTower);
            cheeseManager.LoseCheese(PlacedTower.GetComponent<TowerController>().cost);
            Cancel(context);
        }
    }

    public void SelectTower(GameObject tower)
    {
        if ((selectedTower != null))
        {
            selectedTower.GetComponent<TowerController>().ShowRange(false);

        }
        selectedTower = tower;
        tower.GetComponent<TowerController>().ShowRange(true);
        panelSelect.SetActive(false);
        panelUpgrade.SetActive(true);
        panelUpgrade.GetComponent<UpgradePanel>().SetInformation(tower);

    }


}
