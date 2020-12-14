using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportPowerup : Powerup
{
    public static int count = 5;
    public Vector3 clickPosition;
    public AudioClip pop;
    private PlayerInput inputManager;

    void Start()
    {
        pop = Resources.Load<AudioClip>("Audio Clips/teleport_pop");

        if (gameObject.name == "Player")
        {
            inputManager = gameObject.GetComponent<PlayerInput>();
            inputManager.SwitchCurrentActionMap("TeleportMode");
        }
    }

    public void OnTeleport()
    {
        //play audio clip if available
        if (pop != null) { AudioSource.PlayClipAtPoint(pop, transform.position); }

        //get mouse position and set transform there
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)); //get click position
        gameObject.GetComponent<Transform>().position = clickPosition;

        iFrames(2); //2 second invisability after teleporting
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.nJumps = 0;//reset double jump
        count--;
    
            if(count <= 0) {
                RemovePowerup(gameObject.GetComponent<TeleportPowerup>());
                Debug.Log("Teleport power disabled, count 0");
            }
    }
}
