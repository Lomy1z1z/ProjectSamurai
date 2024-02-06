using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip[] stepsSound;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySteps()
    {
        AudioClip clip = stepsSound[(int)Random.Range(0,stepsSound.Length)];
        source.clip = clip;
        source.Play();

    }
}
