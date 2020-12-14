using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPowerup : Powerup
{
    private PlayerInput inputManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player")
        { 
            Debug.Log("script attached to player");
            inputManager = gameObject.GetComponent<PlayerInput>();
            inputManager.SwitchCurrentActionMap("ExtraJumpMode");
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.maxJumps = 5;//change max jumps
            StartCoroutine(Timer(30));
        }
    }

    //powerup timer will destory powerup after set time
    public new IEnumerator Timer(float time)
    {
        Debug.Log("timer started");
        yield return new WaitForSeconds(30);
        Debug.Log("timer finished");

        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.maxJumps = 2;//revert max jumps

        RemovePowerup(gameObject.GetComponent<Powerup>());
    }

}
