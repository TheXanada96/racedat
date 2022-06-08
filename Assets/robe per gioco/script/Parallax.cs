using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float cameraX;
    float currentCameraX;

    [SerializeField]
    float parallaxSpeed = 3f;

    Transform cam;

    void Start()
    {
        cam = Camera.main.transform; // creo una variabile che controlla la camera
        cameraX = cam.position.x; // ottiene la posizione x della camera
        currentCameraX = cameraX;

    }

    
    void Update()
    {
        currentCameraX = cam.position.x;
        float delta = currentCameraX - cameraX;

        if (Mathf.Abs(delta) > 0) // se il valore assoluto di delta è maggiore di 0 (cioè se si muove)
        {
            Vector3 newPosition = new Vector3(transform.position.x - delta, transform.position.y, transform.position.z); // l'immagine cambia posizione ogni volta che delta cambia valore
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * parallaxSpeed);  // calcola il movimento dei frame al secondo per il parallaxSpeed dato
            cameraX = currentCameraX;
        }
    }
}
