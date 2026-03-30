using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        float savedMusic = PlayerPrefs.GetFloat("MusicVol", 0.3f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVol", 1f);

        _musicSource.volume = savedMusic;
        _sfxSource.volume = savedSFX;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        _sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        _musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        _musicSource?.Stop();
    }

    public void SetMusicVolume(float value)
    {
        _musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVol", value);
    }

    // Funzione per gli SFX (da collegare allo Slider)
    public void SetSFXVolume(float value)
    {
        _sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVol", value);
    }
}
