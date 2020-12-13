using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
        public GameObject playerPrefab;
        public Vector3 playerStart;

    void Awake() {
          
    }

    void OnTriggerStay(Collider col) {

            if (col.gameObject.name == "Player") {

		        //if (!col.gameObject.GetComponent<MovePlayer>().isSafe) {          // O.G
		        if(!col.gameObject.GetComponent<Player>().isSafe) {                 // For Final playground

			
                        Debug.Log("Player is dead!");
                        GameObject.Destroy(col.gameObject);
                        GameObject newPlayer = GameObject.Instantiate<GameObject>(playerPrefab);
                        newPlayer.name = "Player";
                        newPlayer.transform.position = playerStart;

                } else {
                    Debug.Log("Can't kill player, they are safe!");
                }

            }

    }
}
