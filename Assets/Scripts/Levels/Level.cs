using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator))]
public class Level : MonoBehaviour
{

    /*
      Contains relevant data for a level: score, how many enemies defeated, how many sections are completed..

    10 sections before level complete section. (Level 3 must have boss section first)
     */

    // keeps track of players collectable score
    public Color midPointShow;
    private SmoothFollowCam cam;
    public GameObject playerPrefab;
    public Player player;
    public static int score;

    private LevelGenerator levelGenerator;
    public GameObject floorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = gameObject.GetComponent<LevelGenerator>();
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelGenerator.GetActiveSection() != null) {

            // Delete old sections and update playerSpawn
            
            if(levelGenerator.GetActiveSection().GetRightAnchor().x < player.transform.position.x) {

                if(levelGenerator.GetActiveSection().GetRightAnchor().x + 10 < cam.transform.position.x) 
                    levelGenerator.DeleteLastSections();

                else levelGenerator.PlayerHitCheckpoint();

            }

            // Spawn new section when passing the midpoint
            if(player.transform.position.x > levelGenerator.GetCurrentMidpoint().x) {

                // Spawn special section (levelcomplete)
                if(levelGenerator.GetSectionCount() == 9) {
                    levelGenerator.SpawnEndingSection();

                // Regular section spawn everywhere else 
                } else if(levelGenerator.GetSectionCount() < 10) {

                    levelGenerator.SpawnNewSection();

                }
            }
        }
        
    }

	private void LoadLevel() {

        // Initialize camera
        cam = Camera.main.gameObject.GetComponent<SmoothFollowCam>();
        cam.gameObject.SetActive(false);

        
        
        // Initialize the first section and load the player into the scene:
        levelGenerator.SpawnNewSection();
        RespawnPlayer();
        cam.gameObject.SetActive(true);

        Vector3 floorPos = transform.position;
        floorPos.y -= 50;
        GameObject levelFloor = Instantiate(floorPrefab);
        levelFloor.transform.position = floorPos;
	}

    public void RespawnPlayer() {

        GameObject newObj = Instantiate(playerPrefab);
        player = newObj.GetComponent<Player>();
        newObj.transform.position = levelGenerator.GetPlayerSpawnPosition();
        cam.SetTarget(player.transform);
	}

	public void OnDrawGizmos() {

        Gizmos.color = midPointShow;

        Gizmos.DrawSphere((Vector3)levelGenerator.GetCurrentMidpoint(), 1f);
        
	}

	private void OnValidate() {
        levelGenerator = gameObject.GetComponent<LevelGenerator>();
	}

}
