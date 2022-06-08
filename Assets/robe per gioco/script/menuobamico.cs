using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class menuobamico : MonoBehaviour
{

   
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }
    public void options()
    {
        
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(GameObject.Find("Opzioni"));
        

    }


    public void quit()
    {
        Application.Quit();
    }
}
