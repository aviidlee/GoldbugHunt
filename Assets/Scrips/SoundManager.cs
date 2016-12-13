using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip background;
    public AudioClip gameoverClip;

    AudioSource fxSource;
    public AudioClip shoot;

    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        source = sources[0];
        fxSource = sources[1];

    }

    void Update()
    {

    }

    /**
     * Play a shooting sound.
     */
    public void Shoot()
    {
        fxSource.Play();
    }


    public void GameOverSound()
    {
        Debug.Log("Playing game over sounds.");
        source.clip = gameoverClip;
        source.loop = false;
        source.Play();
    }
}
