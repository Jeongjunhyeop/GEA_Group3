using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    AudioSource audioSource;


    public AudioClip audioExplosion;
    public AudioClip audioPunch;
    public AudioClip audioMissionUp;
    public AudioClip audioOpenDoor;
    public AudioClip audioSwitchOn;

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
        Clear();

    }
    public void Explosion()
    {
        audioSource.clip = audioExplosion;
        audioSource.Play();
        Clear();
    }

    public void Punch()
    {
        audioSource.clip = audioPunch;
        audioSource.Play();
        Clear();
    }

    public void OpenDoor()
    {
        audioSource.clip = audioOpenDoor;
        audioSource.Play();
        Clear();
    }

    public void SwitchOn()
    {
        audioSource.clip = audioSwitchOn;
        audioSource.Play();
        Clear();
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(0.3f);
        audioSource.clip = null;
    }
}
