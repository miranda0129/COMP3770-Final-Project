using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    struct RandomSelectionType {
        public int id;
        public float chanceToSpawn;
        public string name;

        public RandomSelectionType(int id, float chanceToSpawn, string name) {
            this.id = id;
            this.chanceToSpawn = chanceToSpawn;
            this.name = name;
        }

    }
    [Header("Empty Platforms")]
    [Tooltip("'Spawn Chance Per Platform': How likely is a platform going to be empty?")]
    [Range(0, 1)] public float emptySCPP;

    [Header("Collectibles")]
    public GameObject[] collectibles;
    [Range(0, 1)] public float[] collectibleChances;
    [Tooltip("'Spawn Chance Per Platform': Every empty platform, how likely is a collectible going to spawn here?")]
    [Range(0,1)] public float collectibleSCPP;

    [Space(10, order = 1)]
    [Header("Enemies", order = 2)]
    public GameObject[] enemies;
    [Range(0, 1)] public float[] enemyChances;
    [Tooltip("'Spawn Chance Per Platform': Every empty platform, how likely is an enemy going to spawn here?")]
    [Range(0, 1)] public float enemySCPP;


    [Header("====================================================")]
    [Space(10, order = 1)]
    [Header("Static Platforms", order = 2)]
    public GameObject[] staticPlatforms;
    [Range(0, 1)] public float staticChance;

    [Header("Moving Platforms (vertical)")]
    public GameObject[] elevators;
    [Range(0, 1)] public float elevatorChance;

    [Header("Moving Platforms (Horizontal)")]
    public GameObject[] movingPlatforms;
    [Range(0, 1)] public float movingPlatformChance;

    [Header("Rotating Platforms")]
    public GameObject[] rotators;
    [Range(0, 1)] public float rotatingChance;

    [Header("Platforms with a gap that you can fall down")]
    public GameObject[] gaps;
    [Range(0, 1)] public float gapChance;

    [Header("Death zones that kill the player")]
    public GameObject[] deathzones;
    [Range(0, 1)] public float deathChance;

    [Header("Platform Customization Limits")]
    public float minTime = 0.5f;
    public float maxTime = 5.0f;
    public float minPause = 0.0f;
    public float maxPause = 2.0f;
    [Header("====================================================")]

   
    public  Material[] sectionMaterials;

    private bool chancesNormalized = false;
    private float totalChance = 0f;

    private RandomSelectionType[] platformList;
    private RandomSelectionType[] enemyList;
    private RandomSelectionType[] collectibleList;
    private RandomSelectionType[] platformFill;


    private Vector3 anchorPoint;
    private List<GameObject> activePlatforms;
    private int platformCount = 0;
    private int sectionID;

    public bool followsSpawn = false;
    public bool normalizeDebug = false;


    // Start is called before the first frame update
    void Start()
    {
        anchorPoint = transform.position;
        NormalizeChances();
    }

    #region Fill_Platforms
    public GameObject GenerateRandomAddition() {

        GameObject newObject = null;
        float rand = Random.value;


        if(!chancesNormalized) NormalizeChances();
        for(int i = 0; i < platformFill.Length; i++) {

            if(rand <= platformFill[i].chanceToSpawn) {


                switch(platformFill[i].id) {

                    case 0: newObject = null;
                    break;

                    case 1: newObject = GenerateRandomCollectible();
                    break;

                    case 2: newObject = GenerateRandomEnemy();
                    break;

                }

                break;
            } else {
                rand -= platformFill[i].chanceToSpawn;
            }

        }

        return newObject;
    }

    private GameObject GenerateRandomCollectible() {
        GameObject newCollectible = null;
        float rand = Random.value;

       
        for(int i = 0; i < collectibleList.Length; i++) {

            if(rand <= collectibleList[i].chanceToSpawn) {


                newCollectible = Instantiate(collectibles[i]);

                break;
            } else {
                rand -= collectibleList[i].chanceToSpawn;
            }

        }

        return newCollectible;
    }

    private GameObject GenerateRandomEnemy() {
        GameObject newEnemy = null;
        float rand = Random.value;


        for(int i = 0; i < enemyList.Length; i++) {

            if(rand <= enemyList[i].chanceToSpawn) {


                newEnemy = Instantiate(enemies[i]);

                break;
            } else {
                rand -= enemyList[i].chanceToSpawn;
            }

        }

        return newEnemy;
    }

    #endregion

    #region Generate_Platforms
    public GameObject GenerateRandomPlatform() {

        GameObject newPlatform = null;
        float rand = Random.value;
        

        if(!chancesNormalized) NormalizeChances();
       
        for(int i = 0; i < platformList.Length; i++) {
           // Debug.Log(platformList[i].name + " platform: " + platformList[i].chanceToSpawn);

            if(rand <= platformList[i].chanceToSpawn) {


				switch(platformList[i].id) {

                    case 0:
                    newPlatform = GenerateRandomStaticPlatform();
                    break;

                    case 1:
                    newPlatform = GenerateRandomMover();
                    break;

                    case 2:
                    newPlatform = GenerateRandomElevator();
                    break;

                    case 3:
                    newPlatform = GenerateRandomRotator();
                    break;

                    case 4:
                    newPlatform = GenerateRandomGap();
                    break;

                    case 5:
                    if(!followsSpawn) newPlatform = GenerateRandomDeathzone();
                    else newPlatform = GenerateRandomStaticPlatform();
                    break;

                    default:
                    Debug.Log("Invalid Platform Type");
                    break;
                }

          

                break;
			} else {
                rand -= platformList[i].chanceToSpawn;
			}

            
        }

        if(newPlatform == null) Debug.Log("platform is null!");
        return newPlatform;
	}
	
	public GameObject GenerateRandomStaticPlatform() {
        int rand = Random.Range(0, staticPlatforms.Length);

        GameObject newPlatform = Instantiate(staticPlatforms[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.SetParent(transform);
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));
        SetRandomColor(newPlatform);           
        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomElevator() {
        int rand = Random.Range(0, elevators.Length);

        /* Variables:
         * timeToDestination 
         * pauselength
         * lefttoright  ->start at the end?
         */
        float timeToDestination = Random.Range(minTime, maxTime);
        float pauseLength = Random.Range(minPause, maxPause);
        bool leftToRight = (Random.value > 0.5f);

        GameObject newPlatform = Instantiate(elevators[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        MovingPlatform moveScript = newPlatform.GetComponent<MovingPlatform>();

        // Moving platform Randomization
        moveScript.timeToDestination = timeToDestination;
        moveScript.pauseLength = pauseLength;
        moveScript.leftToRight = leftToRight;

        newPlatform.transform.SetParent(transform);
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));
        SetRandomColor(newPlatform);
        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomMover() {
        int rand = Random.Range(0, movingPlatforms.Length);

        /* Variables:
         * timeToDestination 
         * pauselength
         * lefttoright  ->start at the end?
         */
        float timeToDestination = Random.Range(minTime, maxTime);
        float pauseLength = Random.Range(minPause, maxPause);
        bool leftToRight = (Random.value > 0.5f);


        GameObject newPlatform = Instantiate(movingPlatforms[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        MovingPlatform moveScript = newPlatform.GetComponent<MovingPlatform>();

        // Moving platform Randomization
        moveScript.timeToDestination = timeToDestination;
        moveScript.pauseLength = pauseLength;
        moveScript.leftToRight = leftToRight;
        
        newPlatform.transform.SetParent(transform);
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));
        SetRandomColor(newPlatform);
        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomRotator() {
        int rand = Random.Range(0, rotators.Length);


        GameObject newPlatform = Instantiate(rotators[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        Rotate rotScript = newPlatform.GetComponent<Rotate>();

        // Rotating platform Randomization
        if(Random.value > 0.5f) rotScript.SwitchDirection();
        rotScript.timeToRotate = Random.Range(0.5f, 2f);


        newPlatform.transform.SetParent(transform);
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));
        SetRandomColor(newPlatform);
        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomGap() {
        int rand = Random.Range(0, gaps.Length);

        GameObject newPlatform = Instantiate(gaps[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.SetParent(transform);
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));
        SetRandomColor(newPlatform);
        platformCount++;
        return newPlatform;
	}

    public GameObject GenerateRandomDeathzone() {
        int rand = Random.Range(0, deathzones.Length);

        GameObject newPlatform = Instantiate(deathzones[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.SetParent(transform);
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
	}

    #endregion


    private void NormalizeChances() {

        // Normalize platforms
        totalChance = staticChance + elevatorChance + movingPlatformChance + rotatingChance + gapChance + deathChance;
        staticChance /= totalChance;
        elevatorChance /= totalChance;
        movingPlatformChance /= totalChance;
        rotatingChance /= totalChance;
        gapChance /= totalChance;
        deathChance /= totalChance;

        platformList = new[] {
            new RandomSelectionType(0, staticChance, "static"),
            new RandomSelectionType(1, movingPlatformChance, "moving"),
            new RandomSelectionType(2, elevatorChance, "elevator"),
            new RandomSelectionType(3, rotatingChance, "rotating"),
            new RandomSelectionType(4, gapChance, "gap"),
            new RandomSelectionType(5, deathChance, "deathzone")
        };

        // Normalize platform additions
        totalChance = emptySCPP + collectibleSCPP + enemySCPP;
        emptySCPP /= totalChance;
        collectibleSCPP /= totalChance;
        enemySCPP /= totalChance;

        platformFill = new[] {
            new RandomSelectionType(0, emptySCPP, "empty"),
            new RandomSelectionType(1, collectibleSCPP, "collectible"),
            new RandomSelectionType(2, enemySCPP, "enemy")
        };

        // Normalize enemy Chances
        totalChance = 0;
        for(int i = 0; i < enemyChances.Length; i++) totalChance += enemyChances[i];
        for(int i = 0; i < enemyChances.Length; i++) enemyChances[i] /= totalChance;

        enemyList = new[] {
            new RandomSelectionType(0, enemyChances[0], "Placeholder")
        };

        // Normalize Collectible Chances
        totalChance = 0;
        for(int i = 0; i < collectibleChances.Length; i++) totalChance += collectibleChances[i];
        for(int i = 0; i < collectibleChances.Length; i++) collectibleChances[i] /= totalChance;
		

        collectibleList = new[] {
            new RandomSelectionType(0, collectibleChances[0], "Coin")
        };

        // sort the arrays from largest to smallest chance
        System.Array.Sort<RandomSelectionType>(platformList, (x, y) => y.chanceToSpawn.CompareTo(x.chanceToSpawn));
        System.Array.Sort<RandomSelectionType>(enemyList, (x, y) => y.chanceToSpawn.CompareTo(x.chanceToSpawn));
        System.Array.Sort<RandomSelectionType>(collectibleList, (x, y) => y.chanceToSpawn.CompareTo(x.chanceToSpawn));
        System.Array.Sort<RandomSelectionType>(platformFill, (x, y) => y.chanceToSpawn.CompareTo(x.chanceToSpawn));
        chancesNormalized = true;
        
       
    }

    private void SetRandomColor(GameObject platform) {

        // Randomize color of material
        Platform script = platform.GetComponent<Platform>();
        Material mat = sectionMaterials[sectionID];
        float randHue = Random.Range(-(20/360), 20/360f);
        float H, S, V;
        Color.RGBToHSV(mat.color, out H, out S, out V);
        script.platformRenderer.material = sectionMaterials[sectionID];
        script.platformRenderer.material.color = Color.HSVToRGB(H + randHue, S, V);

        if(script.optionalRenderer != null) {
            script.optionalRenderer.material = sectionMaterials[sectionID];
            script.optionalRenderer.material.color = Color.HSVToRGB(H + randHue, S, V);
		}
    }
    public void SetID(int id) { sectionID = id; }
    public Vector3 GetAnchorPoint() { return anchorPoint; }
    public void SetAnchorPoint(Vector3 newAnchor) { anchorPoint = newAnchor; }

    #region DEBUG
    public void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(anchorPoint, 0.2f);
    }

    public void OnValidate() {

		if(normalizeDebug) {
            NormalizeChances();
            normalizeDebug = false;
		}
	}
    #endregion
}
