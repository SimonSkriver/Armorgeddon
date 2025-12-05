using UnityEngine;
using System;

public class SimpleAudio : MonoBehaviour
{
    // Singleton - allows you to call it from anywhere
    public static SimpleAudio Instance;

    [System.Serializable]
    public class SoundItem
    {
        public string name;      // Type the name of the sound here
        public AudioClip clip;   // Drag the sound file here
        
        [Range(0f, 1f)] 
        public float volume = 1f;
        
        [Range(0.1f, 3f)] 
        public float pitch = 1f;
    }

    // The list you fill in the Inspector window
    public SoundItem[] soundList;

    private AudioSource source;

    void Awake()
    {
        // Singleton Setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Add the audio source component when the game starts boi
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        // Find sound by name boi
        SoundItem s = Array.Find(soundList, item => item.name == soundName);

        if (s == null)
        {
            Debug.LogWarning("Audio Missing: " + soundName);
            return;
        }

        // Play that sound boi
        source.volume = s.volume;
        source.pitch = s.pitch;
        source.PlayOneShot(s.clip);
    }
}