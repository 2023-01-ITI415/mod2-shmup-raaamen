using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero S {get; private set;}
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    [Range(0,4)]
    public float shieldLevel = 1;

    private void Awake() {
        if (S == null)
        {
            S = this;
        }
        else Debug.Log("Hero is already awake");
    }
    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x = x;
        pos.y=y;
        transform.position+=pos*speed*Time.deltaTime;

        transform.rotation = Quaternion.Euler(y*pitchMult, x*rollMult,0);
    }
}
