using UnityEngine.InputSystem;
using UnityEngine;

public class LazerBeamPowerup : Powerup
{
    public Vector3 clickPosition;
    public AudioClip pew;

    private LineRenderer lineRenderer;
    private Vector3 direction;
    private float maxDistance;
    private Vector3 mousePosition;
    private Level levelManager;

    new void Start()
    {
        base.Start();
        pew = Resources.Load<AudioClip>("Audio Clips/laser_pew"); //load audio clip
        player.SetMaterial(player.powerupMats[1]);

        //line renderer prep
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        inputManager.SwitchCurrentActionMap("LazerMode");
        StartCoroutine(Timer(30, this));
        
    }

    //click input handled for laser mode - shoot laser when clicked
    public void OnLazer(InputValue input)
    {
        Debug.Log("lazer shot");
        if (input.isPressed)
        {
            lineRenderer.enabled = true;
            mousePosition = Mouse.current.position.ReadValue();
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 10)); //get click position
            clickPosition = new Vector3(clickPosition.x, clickPosition.y, 0);
            Vector3 direction = clickPosition - transform.position; //calculate ray direction from player to click point
            float maxDistance = direction.magnitude; // distance from player to click for raycast maxDistance

            //render laser 
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, clickPosition);
            lineRenderer.enabled = true;

            //play audio clip if available
            if(pew != null) { AudioSource.PlayClipAtPoint(pew, transform.position); }

            //stores all hit objects
            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, maxDistance); //cast ray

            //destory every enemy hit in between player & max distance
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                //destory only if tagged as enemy
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Weak Point")) Destroy(hit.collider.gameObject);
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("HeadHitbox")) Destroy(hit.collider.transform.parent.gameObject);

            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

}
