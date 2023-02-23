using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHero : MonoBehaviour
{
    public BoundsCheck boundsCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!boundsCheck.isOnScreen)
        {
            Destroy(this.gameObject);
        }
    }
}
