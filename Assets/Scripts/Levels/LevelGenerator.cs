using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [Range(0, 1)] public float chanceToSpawnAdds = 1;

    [SerializeField] private GameObject sectionParent;      // GameObject acts as parent in the heirarchy.
    public GameObject emptySectionPrefab;                   // Prefab for spawning the section
    public GameObject[] specialSectionPrefabs;              // Ending and boss sections

    public List<Section>currentSections;                   // The newest group of sections (can be middle, top, and bottom)
    public List<Section> lastSections;                     // The sections waiting to be destroyed
    private Section activeSection;                          // The section that the player is currently on
    public Section nextSection;
    private bool nextSectionGenerated;

    public Vector3 nextSectionSpawnPosition = Vector3.zero; // get the world position of the right anchor in currentSection
    private Vector3 lastSectionSpawnPosition;               // world position of the last section -> want to make sure the sections are still moving along postive x-axis
    private Vector3 playerSpawn;                            // spawnpoint located on the first platform of a section.
    public int sectionCount = 0;                           // total active sections: 10 sections then final section.
    

    // Start is called before the first frame update
    void Start()
    {
        currentSections = new List<Section>();
        lastSections = new List<Section>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewSection() {

        GameObject newObject = Instantiate(emptySectionPrefab);
        Section newSection = newObject.GetComponent<Section>();

        newObject.transform.SetParent(sectionParent.transform);
        newObject.transform.position = nextSectionSpawnPosition;

        // Initialize the platforms, then get the next (even if it's not needed.) spawn positions
        newSection.InitializePlatforms(sectionCount, nextSectionSpawnPosition);
        nextSectionSpawnPosition = newSection.GetRightAnchor();

        if(sectionCount == 0) {
            activeSection = newSection;
            playerSpawn = newSection.playerSpawn;
        }

        nextSection = newSection;
        currentSections.Add(newSection);
        sectionCount++;
        
    }

    public void SpawnEndingSection() {
        GameObject newObject = Instantiate(specialSectionPrefabs[0]);
        newObject.transform.SetParent(sectionParent.transform);
        newObject.transform.position = nextSectionSpawnPosition;

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

        // Delete old section.
        currentSections.Remove(activeSection);
        Destroy(activeSection.gameObject);
       

        // Set the active section to the next section in line
        activeSection = nextSection;
        nextSection = null;
        
    }

    public void PlayerHitCheckpoint() {
        if(nextSection != null) playerSpawn = nextSection.playerSpawn;
        else playerSpawn = nextSectionSpawnPosition + Vector3.right * 1 + Vector3.up * 2;
    }

    public void SetFirstSpawnPosition(Vector3 spawn) { nextSectionSpawnPosition = spawn; }

    // World Coordinates
    public void SetPlayerSpawnPosition(Vector3 spawn) { playerSpawn = spawn; }
    public Vector3 GetPlayerSpawnPosition() {
        return playerSpawn;
	}

    public Vector2 GetCurrentMidpoint() {
        if(nextSection != null) return nextSection.midpoint;
        else if(activeSection != null) return activeSection.midpoint;
        else return Vector3.zero;
    }

    public int GetSectionCount() { return sectionCount; }
    public Section GetActiveSection() { return activeSection; }
}
