using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [Range(0, 1)] public float chanceToSpawnAdds = 1;
    
    public GameObject[] levelSectionPrefabs;
    public GameObject[] specialSectionPrefabs;

    private List<Section>currentSections;                   // The newest group of sections (can be middle, top, and bottom)
    private List<Section> lastSections;                     // The sections waiting to be destroyed
    [SerializeField] private LevelGenerator generator;

    private Vector3 nextSectionSpawnPosition;               // get the world position of the right anchor in currentSection


    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomSection() {
        DeleteLastSections();
        MoveToLastSections();
        
        // Generate Middle Section
        int randSection = (int)Random.Range(0, levelSectionPrefabs.Length);
        GameObject newGo = Instantiate(levelSectionPrefabs[randSection]);
        Section newSection = newGo.GetComponent<Section>();

        newGo.transform.position = nextSectionSpawnPosition;
        nextSectionSpawnPosition = newSection.GetRightAnchor();
        currentSections.Add(newSection);

		// Check whether or not the middle section has an available top anchor
		if(newSection.topAnchorAvailable) {

            float chanceToSpawn = Random.Range(0, 1);
		}
        
	}

    
    /// <summary>
    /// Called when we generate new sections. (we hit the mid point of the current section.)
    /// </summary>
    public void DeleteLastSections() {
        foreach(Section section in lastSections) {

            lastSections.Remove(section);
            Destroy(section.gameObject);
		}
	}

    public void MoveToLastSections() {

        foreach(Section section in currentSections) {
            lastSections.Add(section);
            currentSections.Remove(section);
        }
    }

    public void SetFirstSpawnPosition(Vector3 spawn) { nextSectionSpawnPosition = spawn; }
}
