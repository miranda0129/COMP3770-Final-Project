using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    struct PlatformType {
        public int id;
        public float chanceToSpawn;
        public string name;

        public PlatformType(int id, float chanceToSpawn, string name) {
            this.id = id;
            this.chanceToSpawn = chanceToSpawn;
            this.name = name;
		}

	}
    [Header("Static Platforms")]
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

    [Header("Platform Customization upper limits")]
    public float minTime = 0.5f;
    public float maxTime = 5.0f;
    public float minPause = 0.0f;
    public float maxPause = 2.0f;

    public bool normalizeDebug = false;
    private bool chancesNormalized = false;
    private float totalChance = 0f;

    private PlatformType[] platformList;

    private Vector3 anchorPoint;
    private List<GameObject> activePlatforms;
    private int platformCount = 0;
    public  Material[] sectionMaterials;
    private int sectionID;

    // Start is called before the first frame update
    void Start()
    {
        anchorPoint = transform.position;
		

        NormalizeChances();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                    newPlatform = GenerateRandomDeathzone();
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
    public void SetID(int id) { sectionID = id; }
    public Vector3 GetAnchorPoint() { return anchorPoint; }
    public void SetAnchorPoint(Vector3 newAnchor) {
        Debug.Log("new anchor: " + newAnchor);
        anchorPoint = newAnchor; 
    }

	public void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(anchorPoint, 0.2f);
	}

    public void NormalizeChances() {

        totalChance = staticChance + elevatorChance + movingPlatformChance + rotatingChance + gapChance + deathChance;
        staticChance /= totalChance;
        elevatorChance /= totalChance;
        movingPlatformChance /= totalChance;
        rotatingChance /= totalChance;
        gapChance /= totalChance;
        deathChance /= totalChance;

        platformList = new[] {
            new PlatformType(0, staticChance, "static"),
            new PlatformType(1, movingPlatformChance, "moving"),
            new PlatformType(2, elevatorChance, "elevator"),
            new PlatformType(3, rotatingChance, "rotating"),
            new PlatformType(4, gapChance, "gap"),
            new PlatformType(5, deathChance, "deathzone")
        };

        // sort the array from largest to smallest
        System.Array.Sort<PlatformType>(platformList, (x, y) => y.chanceToSpawn.CompareTo(x.chanceToSpawn));
        chancesNormalized = true;
        
       
    }

    public void SetRandomColor(GameObject platform) {

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

  

    public void OnValidate() {

		if(normalizeDebug) {
            NormalizeChances();
            normalizeDebug = false;
		}
	}
}
