using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoundsCheck boundsCheck;
    public float speed = 10;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;
    public Vector3 pos {
        get{
            return this.transform.position;
        }
        set{
            this.transform.position = value;
        }
    }

    private void Awake() {
        boundsCheck = GetComponent<BoundsCheck>();
    }

    void Update()
    {
        Move();
        if (!boundsCheck.isOnScreen)
        {
            if (pos.y < boundsCheck.camHeight - boundsCheck.radius)
            {
                Debug.Log("enemy destroyed");
                Destroy(this.gameObject);
            }
        }
    }
    public virtual void Move(){
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "HeroProjectile":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
