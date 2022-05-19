////////////////////////////////////////////////////////////////////////
//Name:Breanna Henriquez 
//Purpose: to enable the joints and lines for the harpoon
////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonGrapple : MonoBehaviour
{
    //Line
    public LineRenderer line;

    //Joint
    public DistanceJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        //joint should be set to false to begin with
        joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the joint is enabled set the line position 
        //this makes it look like it's always connected to the player
        if (joint.enabled) { line.SetPosition(1, transform.position); }
    }
}
