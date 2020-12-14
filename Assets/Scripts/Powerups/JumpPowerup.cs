using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPowerup : Powerup
{

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        inputManager.SwitchCurrentActionMap("ExtraJumpMode");
        
        player.maxJumps = 5;//change max jumps
        StartCoroutine(Timer(30));
        
    }

    //powerup timer will destory powerup after set time
    public new IEnumerator Timer(float time)
    {
        Debug.Log("timer started");
        yield return new WaitForSeconds(30);
        Debug.Log("timer finished");

        player.maxJumps = 2;//revert max jumps
        RemovePowerup(gameObject.GetComponent<Powerup>());
    }

}
