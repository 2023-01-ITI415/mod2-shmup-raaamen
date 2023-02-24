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
    private float _shieldLevel = 1;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float shieldLevel{
        get{
            return _shieldLevel;
        }
        set{
            _shieldLevel = Mathf.Min(value, 4);
            if (value <= 0)
            {
                GameManager.HERO_DIED();
                Destroy(this.gameObject);
            }
        }
    }



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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);   
            bullet.gameObject.GetComponent<Rigidbody>().velocity = bulletSpeed*Vector3.up;
        }
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.tag)
        {
            case "Enemy":
                shieldLevel--;
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }

    

    
}
