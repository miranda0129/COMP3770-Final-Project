using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Platform))]
public class RotatePlatform : Rotate
{
    private Platform platform;

    // Start is called before the first frame update
    public void Awake()
    {

        platform = gameObject.GetComponent<Platform>();

        // Slide the prefab over so that it is centered around the rotating pivot.
        Vector3 rightAnchor = platform.GetRightAnchor();
        rightAnchor.x += platform.GetWidth();
        platform.SetRightAnchor(rightAnchor);

    }

    public new void Start() {
        base.Start();
        transform.Translate(Vector3.right * platform.GetWidth());
        platform.SetRightAnchor(platform.GetRightAnchor() - (Vector3.right * platform.GetWidth()));
    }

    
}
