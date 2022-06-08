using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daggerforce : MonoBehaviour
{
    [SerializeField]
    float bulletspeed = 30f;
    [SerializeField]
    float bulletlife = 3f;
    
    float timesincebullet = 0f;

    
    void Update()
    {
        movimento();
        death();
    }

    void movimento()
    {
        transform.position += transform.up * Time.deltaTime * bulletspeed; 
    }

    void death()
    {
        timesincebullet += Time.deltaTime;
        if(timesincebullet >= bulletlife)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
