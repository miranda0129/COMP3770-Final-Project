using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowablePowerup : Powerup
{
    private Vector3 mousePosition;
    private int count = 5;
    private GameObject throwable;
    public GameObject throwablePrefab;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        inputManager.SwitchCurrentActionMap("ThrowableMode");
        throwable = Instantiate(throwablePrefab, new Vector3(20, 10, 1), Quaternion.identity);
        
    }

    void OnThrow(InputValue input)
    {
        Debug.Log("Throw object");

        mousePosition = Mouse.current.position.ReadValue();
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 10)); //get click position
        clickPosition = new Vector3(clickPosition.x, clickPosition.y, 0);
        Vector3 direction = clickPosition - transform.position; //calculate ray direction from player to click point

        ThrowObject();
        count--;
    }

    void ThrowObject()
    {
        Debug.Log("go time");
        
    }
}
