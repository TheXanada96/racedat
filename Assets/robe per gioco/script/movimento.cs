using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movimento : MonoBehaviour
{
    Rigidbody2D corpo;
    Animator animazione; 

    [SerializeField] // serializza ogni variabile data e le rende pubbliche
    float vel = 3f; // dichiaro una variabile vel di valore 3
    [SerializeField]
    float forzadisalto= 1.5f;

    bool stasaltando = false;
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>(); // la variabile corpo ottiene il componente dell' oggetto a cui ho affidato lo script
        animazione = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimentosexy(); // richiamo la funzione che viene eseguita ogni frame
        salto();
    }
    void movimentosexy() // creo una funizione personalizzata 
    {
        float h = Input.GetAxis("Horizontal"); // ottiene gli input orizzontali
        Vector2 velocity = new Vector2(Vector2.right.x * vel * h, corpo.velocity.y);
        /* la variabile velocity ottiene un nuovo valore Vector2 quando viene moltiplicato il suo valore x per vel e l'input orizzontale
        mentre nel frattempo ottiene la velocità Y del Rigidbody2D */
        corpo.velocity = velocity; // il valore della velocità del corpo è richiamata dalla variabile velocity richiamata in precedenza 

        if (velocity.x < 0) // se la velociy è minore di 0
        {
            corpo.transform.localScale = new Vector3(-2, 2, 1); // capovolge orizzontalmente lo sprite 

        }
        else
            corpo.transform.localScale = new Vector3(2, 2, 1); // lo fa ritornare come prima
        {
        }
        animazione.SetFloat("simuove", Mathf.Abs(h)); // imposta l'animazione fatta su animaotor, ritornande il valore assoluto di h
    }
    void salto() {

        if (stasaltando)
        {
            if (corpo.velocity.y == 0) // se il velocity-y(il giocatore non salta) è 0 la variabile sta saltando rimane false
            {
                stasaltando = false; // finchè rimane false, conferma che il personaggio è a terra
                animazione.SetBool("sta saltando", false);
            }
        }
        else
        {
            if (Input.GetAxis("Jump") > 0) // se premo un tasto per salvate
            {
                corpo.AddForce(Vector2.up * forzadisalto, ForceMode2D.Impulse); // aggiunge una forza verticale al vettore moltiplicando per una variabile data. 
                // il ForceMode.Impulse aggiunge un impulso di forza istantaneo al corpo rigido, rendendo rapido il salto
                stasaltando = true; // stasaltando è true ed evita di far saltare ancora il personaggio
                animazione.SetBool("sta saltando", true);
            }

        }

    }
 }

