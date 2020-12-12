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

    public bool normalizeDebug = false;
    private bool chancesNormalized = false;
    private float totalChance = 0f;

    private PlatformType[] platformList;

    private Vector3 anchorPoint;
    private List<GameObject> activePlatforms;
    private int platformCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        NormalizeChances();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GenerateRandomPlatform(int sectionID) {

        GameObject newPlatform = null;
        float rand = Random.value;

        if(!chancesNormalized) NormalizeChances();
        // DEBUG:
        for(int i = 0; i < platformList.Length; i++) {
            Debug.Log(platformList[i].name + " platform: " + platformList[i].chanceToSpawn);

            if(rand <= platformList[i].chanceToSpawn) {


				switch(platformList[i].id) {
                    case 0:
                    newPlatform = GenerateRandomStaticPlatform(sectionID);
                    break;
                    case 1:
                    newPlatform = GenerateRandomMover(sectionID);
                    break;
                    case 2:
                    newPlatform = GenerateRandomElevator(sectionID);
                    break;
                    case 3:
                    newPlatform = GenerateRandomRotator(sectionID);
                    break;
                    case 4:
                    newPlatform = GenerateRandomGap(sectionID);
                    break;
                    case 5:
                    newPlatform = GenerateRandomDeathzone(sectionID);
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

    public GameObject GenerateRandomStaticPlatform(int sectionID) {
        int rand = Random.Range(0, staticPlatforms.Length);

        GameObject newPlatform = Instantiate(staticPlatforms[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomElevator(int sectionID) {
        int rand = Random.Range(0, elevators.Length);

        GameObject newPlatform = Instantiate(elevators[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomMover(int sectionID) {
        int rand = Random.Range(0, movingPlatforms.Length);

        GameObject newPlatform = Instantiate(movingPlatforms[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomRotator(int sectionID) {
        int rand = Random.Range(0, rotators.Length);

        GameObject newPlatform = Instantiate(rotators[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomGap(int sectionID) {
        int rand = Random.Range(0, gaps.Length);

        GameObject newPlatform = Instantiate(gaps[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
	}

    public GameObject GenerateRandomDeathzone(int sectionID) {
        int rand = Random.Range(0, deathzones.Length);

        GameObject newPlatform = Instantiate(deathzones[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(newPlatform.transform.TransformPoint(script.GetRightAnchor()));

        platformCount++;
        return newPlatform;
	}

    public Vector3 GetAnchorPoint() { return anchorPoint; }
    public void SetAnchorPoint(Vector3 newAnchor) { anchorPoint = newAnchor; }

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

        System.Array.Sort<PlatformType>(platformList, (x, y) => y.chanceToSpawn.CompareTo(x.chanceToSpawn));
        chancesNormalized = true;
        
       
    }

    public void OnValidate() {

		if(normalizeDebug) {
            NormalizeChances();
            normalizeDebug = false;
		}
	}
}
