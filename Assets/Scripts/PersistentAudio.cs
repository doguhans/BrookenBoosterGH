using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    private static PersistentAudio instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            if (audioClips.Length > 0)
            {
                audioSource.clip = audioClips[currentClipIndex];
                audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && audioClips.Length > 0)
        {
            // Cycle through audio clips
            currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
            audioSource.clip = audioClips[currentClipIndex];

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}