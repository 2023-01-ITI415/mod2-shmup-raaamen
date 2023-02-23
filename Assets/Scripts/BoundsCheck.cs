using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public float camWidth;
    public float camHeight;
    public float radius = -1f;
    public bool keepOnScreen;
    public bool isOnScreen;

    private void Awake() {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight *Camera.main.aspect;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        Vector3 pos = transform.position;
        isOnScreen=true;
        if (pos.x > camWidth + radius)
        {
            pos.x = camWidth + radius;
        }
        if (pos.x < -camWidth -radius) {
            pos.x = -camWidth-radius;
        }
        if (pos.y > camHeight + radius)
        {
            pos.y = camHeight + radius;
        }
        if (pos.y < -camHeight-radius) {
            pos.y = -camHeight-radius;
        }

        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos; 
            isOnScreen = true;
        }
    }
}
