using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    public Transform[] bgs;
    Transform lastBg;

    float Bg0 = 0f;
    
    void Start()
    {
        LastPoolingcoordinate(bgs);
    }

    // array di 4 oggetti, i: 0 1 2 3
        void LastPoolingcoordinate(Transform[] objects)
        {
            for (int i = 0; i <= objects.Length - 1; i++)
                {
            if(objects[i].position.x > Bg0)
            {
                lastBg = objects[i];
                Bg0 = objects[i].position.x;
            }
        }
     }
    // quando collida lo rimette nella posizione della camera
    void OnTriggerEnter(Collider col)
    { 
    if(col.tag == "Background")
     {
       float size = col.bounds.size.x;
    Vector3 newPosition = new Vector3(lastBg.transform.position.x + size, col.transform.position.y, col.transform.position.z);
       col.transform.position = newPosition; 
            lastBg = col.gameObject.transform;
    }
    }
    
}
