using UnityEngine;

public class SoundFXHandler : MonoBehaviour
{
    public static SoundFXHandler Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public AudioClip jumpSFX;
    public AudioClip swingSFX;
    public AudioClip hitSFX;
    public AudioClip impactSFX;

    void Awake()
    {
        // Make sure only one instance exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }
}