using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    private AudioSource _zombieSFX;

    void Awake()
    {
        _zombieSFX = GetComponentInChildren<AudioSource>();

        _zombieSFX.volume = PlayerPrefs.GetFloat("SFXVol", 0.5f);
    }

    public void PlayGrowl()
    {
        if (!_zombieSFX.isPlaying)
        {
            _zombieSFX.Play();
        }
    }
}
