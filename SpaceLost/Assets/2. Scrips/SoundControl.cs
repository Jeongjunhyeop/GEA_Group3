using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    AudioSource audioSource;


    public AudioClip audioExplosion;
    public AudioClip audioPunch;
    public AudioClip audioMissionUp;
    

    // Start is called before the first frame update
    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MissionUp()
    {
        audioSource.clip = audioMissionUp;
        audioSource.Play();
    }
    public void Explosion()
    {
        audioSource.clip = audioExplosion;
        audioSource.Play();
    }

    public void Punch()
    {
        audioSource.clip = audioPunch;
        audioSource.Play();
    }

    
}
