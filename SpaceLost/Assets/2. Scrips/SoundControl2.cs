using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl2 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioMissionUp;
    public AudioClip audioOpenDoor;
    public AudioClip audioSwitchOn;
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
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

    public void OpenDoor()
    {
        audioSource.clip = audioOpenDoor;
        audioSource.Play();
    }

    public void SwitchOn()
    {
        audioSource.clip = audioSwitchOn;
        audioSource.Play();
    }
}
