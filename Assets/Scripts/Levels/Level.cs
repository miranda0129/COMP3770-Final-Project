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


    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = gameObject.GetComponent<LevelGenerator>();
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if(player.transform.position.x > levelGenerator.GetCurrentMidpoint().x) {
            levelGenerator.DeleteLastSections();
            // levelGenerator.SpawnNewSection(Section.SectionType.MIDDLE);                  TODO: Stackable Sections
            levelGenerator.SpawnNewSection();
		}

        */
    }

	private void LoadLevel() {

        // Initialize camera
        cam = Camera.main.gameObject.GetComponent<SmoothFollowCam>();
        cam.gameObject.SetActive(false);

        
        
        // Initialize the first section and load the player into the scene:
        levelGenerator.SpawnNewSection();
        RespawnPlayer();
        cam.SetTarget(player.transform);
        cam.gameObject.SetActive(true);
	}

    public void RespawnPlayer() {

        GameObject newObj = Instantiate(playerPrefab);
        player = newObj.GetComponent<Player>();
        cam.SetTarget(player.transform);
        newObj.transform.position = levelGenerator.GetPlayerSpawnPosition();
	}

	public void OnDrawGizmosSelected() {

        Gizmos.color = midPointShow;

        Gizmos.DrawSphere((Vector3)levelGenerator.GetCurrentMidpoint(), 1f);
        Debug.Log(levelGenerator.GetCurrentMidpoint());
	}

	private void OnValidate() {
        levelGenerator = gameObject.GetComponent<LevelGenerator>();
	}

}
