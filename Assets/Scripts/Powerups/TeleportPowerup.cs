using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportPowerup : Powerup
{
    public static int count = 5;
    public Vector3 clickPosition;
    public AudioClip pop;

    new void Start()
    {
        base.Start();
        pop = Resources.Load<AudioClip>("Audio Clips/teleport_pop");
        inputManager.SwitchCurrentActionMap("TeleportMode");
        player.SetMaterial(player.powerupMats[2]);
        
    }

    public void OnTeleport()
    {
        //play audio clip if available
        if (pop != null) { AudioSource.PlayClipAtPoint(pop, transform.position); }

        //get mouse position and set transform there
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)); //get click position
        transform.position = clickPosition;

        player.nJumps = 0;//reset double jump
        iFrames(2); //2 second invisability after teleporting
        count--;
    
        if(count <= 0) {
            RemovePowerup(gameObject.GetComponent<TeleportPowerup>());
            Debug.Log("Teleport power disabled, count 0");
        }
    }
}
