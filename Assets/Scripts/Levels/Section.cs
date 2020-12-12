using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour {

    [Serializable]
    public struct EnemySpawn {
        [SerializeField] public GameObject enemyPrefab;
        [SerializeField] public Vector3 spawnPosition;
    }

    [Serializable]
    public struct CollectableSpawn {
        [SerializeField] public GameObject collectablePrefab;
        [SerializeField] public Vector3 spawnPosition;

    }

    //public enum SectionType { TOP, MIDDLE, BOTTOM };
    //public SectionType type;

    [Header("SpawnLocations")]
    public Vector3 playerSpawn;
    public CollectableSpawn[] collectables;
    public EnemySpawn[] enemies;


    [Header("Attachment Points")]
    public Vector3 leftAnchor;
    public Vector3 rightAnchor;
    public Vector3 toptionalAnchor = Vector3.negativeInfinity;
    public Vector3 botionalAnchor = Vector3.negativeInfinity;
    public Vector3 midpoint = Vector3.negativeInfinity;
    public bool topAnchorAvailable = false;
    public bool bottomAnchorAvailable = false;

    [Header("Platform settings")]
    public int platformsPerSection = 10;
    private PlatformGenerator generator;                    // Randomly spawns the platforms in a given section.
    private List<GameObject> platforms;
    private int ID = -1;

    void OnEnable() {
        if(toptionalAnchor != Vector3.negativeInfinity) topAnchorAvailable = true;
        if(botionalAnchor != Vector3.negativeInfinity) bottomAnchorAvailable = true;
        generator = gameObject.GetComponentInChildren<PlatformGenerator>();

        platforms = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {

    }

    // Determine where to place Section based on Specified Anchor
    public Vector3 GetRelativeAnchorPositon(Vector3 attachedAnchor) {
        return Vector3.zero;
    }

    /// <summary>
    /// The furthest active section will have the active midpoint.
    /// </summary>
    public void ActivateMidPoint() { }

    // Accessors / Mutators
    public Vector3 GetRightAnchor() { return rightAnchor; }
    public Vector3 GetLeftAnchor() { return leftAnchor; }
    public Vector3 GetBottomAnchor() { return botionalAnchor; }
    public Vector3 GetTopAnchor() { return toptionalAnchor; }


    /// <summary>
    /// Use platform generator to populate this section.
    /// </summary>
    /// <param name="id">section group</param>
    /// <param name="attachPoint">Where the platforms attach to the rest of the level</param>
    public void InitializePlatforms(int id, Vector3 attachPoint) {
        ID = id;
        leftAnchor = attachPoint;
        int midPointIndex = platformsPerSection / 2;                                        // Cache it to save from recalculating in the for loop.

        generator.SetAnchorPoint(leftAnchor);
        generator.SetID(id);
        // randomly generate a safe static platform, assign the player spawn here.          Note: It really aught to be a static platform so the player doesn't fall off the level.
        GameObject newPlatform = generator.GenerateRandomStaticPlatform();
        Platform platformScript = newPlatform.GetComponent<Platform>();
        
        playerSpawn = platformScript.GetSpawnPoint();                                       // Set the spawn position of the player to the first platform in this section
        platforms.Add(newPlatform);                                                         // keep track of the platform in this section
                                         // make the generated platform a child of this section.

        // randomly generate the other 'platformsPerSection', picking randomly from the different types of platforms.
        for(int i = 1; i < platformsPerSection; i++) {

            // Generate Random platform.
            newPlatform = generator.GenerateRandomPlatform();
            platformScript = newPlatform.GetComponent<Platform>();
            platforms.Add(newPlatform);
            

            // set midpoint
            if(i == midPointIndex) {
                midpoint = newPlatform.transform.TransformPoint(platformScript.GetCenterPoint());
            }

            // set rightmost anchor
            rightAnchor = platformScript.transform.TransformPoint(platformScript.GetRightAnchor());
            
        }

        
        // TODO (If we want stackable sections)
        // elevator platforms going up generate a top anchor point. -> going down generate a bottom anchor (as do gap platforms)
        // if (gapPlatform -> vec3 bottomAnchor = platform.CalculateBottomAnchor(); boptionalAnchor = true;
      

   
	}




    // In scene view, display the position of various things to make it quicker/easier to iterate.
    void OnDrawGizmosSelected() {

        // Draw Player Spawn
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(playerSpawn, 0.5f);

        // Draw Enemy Spawn
        Gizmos.color = Color.red;
        foreach(EnemySpawn enemy in enemies) {
            Gizmos.DrawSphere(enemy.spawnPosition, 0.5f);
		}

        // Draw Collectable Spawn
        Gizmos.color = Color.yellow;
        foreach(CollectableSpawn c in collectables) {
            Gizmos.DrawSphere(c.spawnPosition, 0.5f);
		}

        // Draw connection points
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(leftAnchor, 0.5f);
        Gizmos.DrawSphere(rightAnchor, 0.5f);
        if(topAnchorAvailable) Gizmos.DrawSphere(toptionalAnchor, 0.5f);
        if(topAnchorAvailable) Gizmos.DrawSphere(botionalAnchor, 0.5f);
        
    }
}
