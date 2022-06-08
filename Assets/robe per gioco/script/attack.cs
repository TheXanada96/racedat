using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField]
    float delaybetweenshots = 0.4f;

    float timepassedsincelast = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timepassedsincelast = delaybetweenshots; // appena inizia il gioco avranno lo stesso valore
    }

    // Update is called once per frame
    void Update()
    {
        mira();
        shooting();
    }

    void mira()
    {
        var objectposition = Camera.main.WorldToScreenPoint(transform.position); // objectposition tiene il valore di una coordinata della posizione che da 3D diventa 2D
        var dir = Input.mousePosition - objectposition; // registra il valore 

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
    }
    void shooting()
    {
        if(Input.GetMouseButton(0) && timepassedsincelast >= delaybetweenshots)
        {
            GameObject dagger = (GameObject)Instantiate(Resources.Load("dagger"), transform.position, transform.rotation);
            timepassedsincelast = 0f;
        }

        else
        {
            timepassedsincelast += Time.deltaTime;
        }
    }
}

