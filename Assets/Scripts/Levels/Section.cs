using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour {

    //public enum SectionType { TOP, MIDDLE, BOTTOM };
    //public SectionType type;

    [Header("SpawnLocations")]
    public Vector3 playerSpawn;
    public List<GameObject> collectables;
    public List<GameObject> enemies;


    [Header("Attachment Points")]
    public Vector3 leftAnchor;
    public Vector3 rightAnchor;
    public Vector3 midpoint = Vector3.negativeInfinity;
    public Vector3 lowestPoint;


    [Header("Platform settings")]
    public int platformsPerSection = 10;
    private PlatformGenerator generator;                    // Randomly spawns the platforms in a given section.
    public GameObject platformGeneratorPrefab;
    private List<GameObject> platforms;

    public GameObject floorPrefab;
    private int ID = -1;

    void OnEnable() {

        GameObject newGenerator = Instantiate(platformGeneratorPrefab);
        newGenerator.transform.SetParent(transform);
        generator = newGenerator.GetComponent<PlatformGenerator>();
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


    /// <summary>
    /// Use platform generator to populate this section.
    /// </summary>
    /// <param name="id">section group</param>
    /// <param name="attachPoint">Where the platforms attach to the rest of the level</param>
    public void InitializePlatforms(int id, Vector3 attachPoint) {
        ID = id;
        leftAnchor = attachPoint;
        lowestPoint = leftAnchor;
        int midPointIndex = platformsPerSection / 2;                                        // Cache it to save from recalculating in the for loop.
       

        generator.SetAnchorPoint(leftAnchor);
        generator.SetID(id);
        // randomly generate a safe static platform, assign the player spawn here.          Note: It really aught to be a static platform so the player doesn't fall off the level.
        GameObject newPlatform = generator.GenerateRandomStaticPlatform();
        Platform platformScript = newPlatform.GetComponent<Platform>();
        
        playerSpawn = platformScript.GetSpawnPoint();                                       // Set the spawn position of the player to the first platform in this section
        platformScript.hasSpawnedSomething = true;
        platforms.Add(newPlatform);                                                         // keep track of the platform in this section
                                                                                            
        generator.followsSpawn = true;
        // randomly generate the other 'platformsPerSection', picking randomly from the different types of platforms.
        for(int i = 1; i < platformsPerSection; i++) {

            // Generate Random platform.
            newPlatform = generator.GenerateRandomPlatform();
            platformScript = newPlatform.GetComponent<Platform>();
            platforms.Add(newPlatform);


            // set midpoint
            if(i == midPointIndex) midpoint = newPlatform.transform.TransformPoint(platformScript.GetCenterPoint());


            // set rightmost anchor
            rightAnchor = platformScript.transform.TransformPoint(platformScript.GetRightAnchor());

            // Generate Addition - Initialize Powerups / Collectibles / Enemies here
            if(platformScript.canSpawnAdd) { 
                GameObject addition = generator.GenerateRandomAddition();
                if(addition != null) {
                    addition.transform.position = platformScript.GetSpawnPoint();
                    addition.transform.SetParent(newPlatform.transform);
                }
            }

            if(i == 1) generator.followsSpawn = false;
            if(rightAnchor.y < lowestPoint.y) lowestPoint = rightAnchor;
        }

        SpawnFloor();
	}


    void SpawnFloor() {

        float width = Vector3.Distance(leftAnchor, rightAnchor);
        Vector3 floorPos = leftAnchor;
        floorPos.y =  lowestPoint.y - 2f;
        GameObject newFloor = Instantiate(floorPrefab);
        newFloor.transform.position = floorPos;
        newFloor.transform.localScale = new Vector3(width, 1, 4);
        newFloor.transform.SetParent(transform);
	}

    // In scene view, display the position of various things to make it quicker/easier to iterate.
    void OnDrawGizmosSelected() {

        // Draw Player Spawn
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(playerSpawn, 0.5f);

        // Draw connection points
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(leftAnchor, 0.5f);
        Gizmos.DrawSphere(rightAnchor, 0.5f);
        
    }
}
