using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _shared;
    public AudioClip  climbSound, shotSound, enemyBullet, hitSound;
    private AudioSource mySource;
    // Start is called before the first frame
    void Start()
    {
        _shared = this;
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void PlaySound(string myAudio)
    {
        switch (myAudio)
        {
            case "climbSound":
                mySource.PlayOneShot(climbSound);
                break;
            case "shotSound":
                mySource.PlayOneShot(shotSound);
                break;
            case "enemyBullet":
                mySource.PlayOneShot(enemyBullet);
                break;
            case "hitSound":
                mySource.PlayOneShot(hitSound);
                break;
        }
    }

    public void StopSound()
    {
        ;
    }
}