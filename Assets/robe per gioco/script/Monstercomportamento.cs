using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstercomportamento : MonoBehaviour
{
    GameObject player;
    Animator anim;
    Vector3 target;

    [SerializeField]
    float attackdelay = 3f;
    [SerializeField]
    float monsterspeed = 3f;

    float timepassed = 0f;
    bool isattacking = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        waitforattack();
        Movement();
    }
    void waitforattack() {
        if (!isattacking)
        {
            timepassed += Time.deltaTime;
                if(timepassed > attackdelay)
            {
                target = player.transform.position;
                timepassed = 0f;
                Attack();
            }
        }
    }
    void Attack()
    {
        var dir = target - transform.position;
        anim.SetBool("Attack", true);
        anim.applyRootMotion = true;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
        isattacking = true;
    }

    void Movement()
    {
        if (isattacking)
        {
            transform.position += transform.up * Time.deltaTime * monsterspeed;
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
