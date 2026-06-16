using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip sfxJump;
    public AudioClip sfxDeath;
    public AudioClip sfxGem;
    public AudioClip sfxVictory;
    public AudioClip musicCave;

    private AudioSource sfxSource;
    private AudioSource musicSource;

    void Awake()
    {
        Instance = this;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 0.5f;
        musicSource.playOnAwake = false;
    }

    void Start()
    {
        if (musicCave != null)
        {
            musicSource.clip = musicCave;
            musicSource.Play();
        }
    }

    public void PlayJump()
    {
        if (sfxJump != null) sfxSource.PlayOneShot(sfxJump);
    }

    public void PlayDeath()
    {
        if (sfxDeath != null) sfxSource.PlayOneShot(sfxDeath);
    }

    public void PlayGem()
    {
        if (sfxGem != null) sfxSource.PlayOneShot(sfxGem);
    }

    public void PlayVictory()
    {
        if (musicSource.isPlaying) musicSource.Pause();
        if (sfxVictory != null) sfxSource.PlayOneShot(sfxVictory);
    }
}