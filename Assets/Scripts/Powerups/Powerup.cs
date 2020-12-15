using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Powerup : MonoBehaviour
{
    protected Player player;
    protected PlayerInput inputManager;

    // Start is called before the first frame update
    protected void Start()
    {
        inputManager = gameObject.GetComponent<PlayerInput>();
        player = gameObject.GetComponent<Player>();
        player.SetCurrentPowerup(this);
    }

    //used to disable a powerup
    //pass gameObject.getCompnet<>() reference as parameter
    public void RemovePowerup(Powerup disable)
    {
        player.ResetMaterial();
        inputManager.SwitchCurrentActionMap("Normal (No Powerups)");
        Debug.Log("Powerup removed");
        Destroy(disable);
    }

    //powerup timer will destory powerup after set time
    public IEnumerator Timer(float time, Powerup type)
    {
        Debug.Log("timer started");
        yield return new WaitForSeconds(time);
        Debug.Log("timer finished");
        player.ResetMaterial();
        RemovePowerup(type);
    }


    /* Invincibility Frames - still a WIP*/
    public IEnumerator iFrames(int invincibilityTime)
    {
        Debug.Log("Invincibility period started");
        gameObject.layer = 10; // Changes the players layer to ignore enemies/projectiles during the invincibility period
        yield return new WaitForSeconds(invincibilityTime);
        gameObject.layer = 8; // Invincibility ends
        Debug.Log("Invincibility period ended");
    }
}
