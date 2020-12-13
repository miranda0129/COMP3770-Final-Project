using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPowerup : MonoBehaviour
{
    public static int count = 5;
    public Vector3 clickPosition;
    public AudioClip pop;

    void Start()
    {
        pop = Resources.Load<AudioClip>("Audio Clips/teleport_pop");
    }

    void Update()
    {
        if (gameObject.name == "Player")
        {
            //telport onclick
            if (Input.GetMouseButtonDown(0))
            {
                //play audio clip if available
                if (pop != null) { AudioSource.PlayClipAtPoint(pop, transform.position);
                    Debug.Log("played sound"); }

                //get mouse position and set transform there
                clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)); //get click position
                gameObject.GetComponent<Transform>().position = clickPosition;
                count--;
            }
            if(count <= 0) {
                Destroy(gameObject.GetComponent<TeleportPowerup>());
                Debug.Log("Teleport power disabled, count 0");
            }
        }
    }
}
