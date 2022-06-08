using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrollo : MonoBehaviour
{
    Transform player;
    [SerializeField]
    float cord_z = -10f;
    [SerializeField]
    float cord_y = 3f;
    [SerializeField]
    float smooth = 3f;



    Vector3 velocity = Vector3.zero; // il vettore ha valore (0,0,0)
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // cerca l'oggetto col tag "Player" nel nostro caso il nostro omino
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) // se il giocatore non ha valore lo segue sempre
        {
            Vector3 targetposition = new Vector3(player.position.x, player.position.y + cord_y, player.position.z + cord_z); // segue lo spostamento del giocatore
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smooth); // regola la camera
        }
    }
}
