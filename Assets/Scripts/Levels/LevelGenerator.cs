using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [Range(0, 1)] public float chanceToSpawnAdds = 1;

    [SerializeField] private GameObject sectionParent;      // GameObject acts as parent in the heirarchy.
    public GameObject emptySectionPrefab;                   // Prefab for spawning the section
    public GameObject[] specialSectionPrefabs;              // Ending and boss sections

    private List<Section>currentSections;                   // The newest group of sections (can be middle, top, and bottom)
    private List<Section> lastSections;                     // The sections waiting to be destroyed
    private Section activeSection;                          // The section that the player is currently on
    private bool nextSectionGenerated;

    private Vector3 nextSectionSpawnPosition;               // get the world position of the right anchor in currentSection
    private Vector3 lastSectionSpawnPosition;               // world position of the last section -> want to make sure the sections are still moving along postive x-axis
    private Vector3 playerSpawn;                            // spawnpoint located on the first platform of a section.
    private int sectionCount = 0;                           // total active sections: 10 sections then final section.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewSection() {

        GameObject newObject = Instantiate(emptySectionPrefab);
        Section newSection = newObject.GetComponent<Section>();

        newObject.transform.parent = sectionParent.transform;


        if(sectionCount == 0) {
            nextSectionSpawnPosition = Vector3.zero;
		}

        // Initialize the platforms, then get the next (even if it's not needed.) spawn positions
        newSection.InitializePlatforms(sectionCount, nextSectionSpawnPosition);
        playerSpawn = newSection.playerSpawn;
        nextSectionSpawnPosition = newSection.GetRightAnchor();

        activeSection = newSection;
        sectionCount++;
    }


    // TODO: Stackable Section Spawn
    /*
    public void SpawnNewSection(Section.SectionType type) {

        GameObject newObject = Instantiate(emptySectionPrefab);
        Section newSection = newObject.GetComponent<Section>();

        // TODO:
        // Get the anchor of the section the player is currently on and feed it to the new section.
        newSection.InitializePlatforms(sectionCount, nextSectionSpawnPosition);

		switch(type) {

            case Section.SectionType.TOP:

            break;

            case Section.SectionType.MIDDLE:

                // if new section has Top anchor available and section count < 9
                // generate top section point
                if(newSection.topAnchorAvailable && sectionCount < 9)                         // Hard code since this is a project requirement
                    SpawnNewSection(Section.SectionType.TOP);

                // if new section has bottom anchor available and section count < 9
                // generate bottom section point.
                if(newSection.bottomAnchorAvailable && sectionCount < 9) 
                    SpawnNewSection(Section.SectionType.BOTTOM);

                sectionCount++;                                                               // as the top and lower sections are optional, only increment on the middle section.
            break;

            case Section.SectionType.BOTTOM:


            break;
		}
        
        // NEED TO SELECT THE NEW MIDDLE SECTION BASED ON WHERE THE PLAYER 

        

	}
    */
    
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

    // World Coordinates
    public void SetPlayerSpawnPosition(Vector3 spawn) { playerSpawn = spawn; }
    public Vector3 GetPlayerSpawnPosition() {
        return playerSpawn;
	}

    public Vector2 GetCurrentMidpoint() {
        if (activeSection != null)  return activeSection.midpoint;
        else                        return Vector3.zero;
    }
}
