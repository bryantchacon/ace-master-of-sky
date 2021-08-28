using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; //Punto de acceso al singleton de la clase

    private AudioSource audioSource;
    public AudioClip shoot;

    private void Awake()
    {
        //Creacion del singleton de la clase, siempre sera en Awake
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); //Evita que el singleton se destruya al cambiar de escena

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioShoot()
    {
        audioSource.PlayOneShot(shoot);
    }
}