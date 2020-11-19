using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip[] tracks;
    AudioSource audioSource;

    int prevIndex = 1000;

    void Update()
    {
        if (!audioSource.isPlaying && shouldPlay)
        {
            int randomIndex = Random.Range(0, tracks.Length);

            while (randomIndex == prevIndex)
            {
                randomIndex = Random.Range(0, tracks.Length);
            }

            prevIndex = randomIndex;
            audioSource.clip = tracks[randomIndex];
            audioSource.Play();
        }
    }

    bool shouldPlay = true;

    public void StopPlay()
    {
        shouldPlay = false;
        audioSource.Stop();
    }

    public void StartPlay()
    {
        shouldPlay = true;
    }
}
