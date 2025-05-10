using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Controls playerControls;

    private InputAction cancel;
    private InputAction interact;
    private InputAction place;

    public MouseVisualsControler mouseVisual;
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
        interact = playerControls.UITowers.Interact;
        place = playerControls.UITowers.Place;
        cancel.Enable();
        interact.Enable();
        place.Enable();

        cancel.performed += Cancel;
        place.performed += Place;
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
        if (mouseVisual.GetVisualTower() != null && mouseVisual.canPlace)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(mouseVisual.GetRealTower(), mousePosition, Quaternion.identity, towerParent);
        }
    }
}
