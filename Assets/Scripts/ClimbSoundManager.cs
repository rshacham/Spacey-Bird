using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbSoundManager : MonoBehaviour
{
    public static ClimbSoundManager _climb;
    public AudioClip climbSound;
    private AudioSource mySource;
    // Start is called before the first frame update
    void Start()
    {
        _climb = this;
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void PlaySound()
    {
        mySource.PlayOneShot(climbSound);
    }

    public void StopSound()
    {
        mySource.Stop();
    }
}