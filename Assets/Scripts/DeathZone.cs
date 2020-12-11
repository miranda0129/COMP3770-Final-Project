using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject playerPrefab;
    public Level levelScript;

    void OnTriggerStay(Collider col) {


        if(levelScript == null) levelScript = GameObject.Find("Level").GetComponent<Level>();

		if(!col.gameObject.GetComponent<Player>().isSafe) {

            Debug.Log("Player is dead!");
            Destroy(col.gameObject);
            levelScript.RespawnPlayer();

        } else {
            Debug.Log("Can't kill player, they are safe!");
        }

        

    }
}
