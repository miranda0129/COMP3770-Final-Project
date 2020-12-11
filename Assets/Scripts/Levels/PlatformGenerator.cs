using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    [Header("Static Platforms")]
    public GameObject[] staticPlatforms;

    [Header("Moving Platforms (vertical)")]
    public GameObject[] elevators;

    [Header("Moving Platforms (Horizontal)")]
    public GameObject[] movingPlatforms;

    [Header("Rotating Platforms")]
    public GameObject[] rotators;

    [Header("Platforms with a gap that you can fall down")]
    public GameObject[] gaps;


    private Vector3 anchorPoint;
    private List<GameObject> activePlatforms;
    private int platformCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GenerateRandomStaticPlatform(int sectionID) {
        int rand = Random.Range(0, staticPlatforms.Length - 1);

        GameObject newPlatform = Instantiate(staticPlatforms[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(script.GetRightAnchor());

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomElevator(int sectionID) {
        int rand = Random.Range(0, elevators.Length - 1);

        GameObject newPlatform = Instantiate(elevators[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(script.GetRightAnchor());

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomMover(int sectionID) {
        int rand = Random.Range(0, movingPlatforms.Length - 1);

        GameObject newPlatform = Instantiate(movingPlatforms[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(script.GetRightAnchor());

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomRotator(int sectionID) {
        int rand = Random.Range(0, rotators.Length - 1);

        GameObject newPlatform = Instantiate(rotators[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(script.GetRightAnchor());

        platformCount++;
        return newPlatform;
    }

    public GameObject GenerateRandomGap(int sectionID) {
        int rand = Random.Range(0, gaps.Length - 1);

        GameObject newPlatform = Instantiate(gaps[rand]);
        Platform script = newPlatform.GetComponent<Platform>();
        newPlatform.transform.position = GetAnchorPoint();
        SetAnchorPoint(script.GetRightAnchor());

        platformCount++;
        return newPlatform;
	}

    public Vector3 GetAnchorPoint() { return anchorPoint; }
    public void SetAnchorPoint(Vector3 newAnchor) { anchorPoint = newAnchor; }

	public void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(anchorPoint, 0.2f);
	}
}
