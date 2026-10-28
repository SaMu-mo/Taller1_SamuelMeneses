using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip musicaFondo;
    public AudioClip sfxSalto;
    public AudioClip sfxAtaque;
    public AudioClip sfxDanio;
    public AudioClip sfxMoneda;

    private AudioSource musicaSource;
    private AudioSource sfxSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        AudioSource[] sources = GetComponents<AudioSource>();
        musicaSource = sources[0];
        sfxSource = sources[1];
    }

    void Start()
    {
        if (musicaFondo != null)
        {
            musicaSource.clip = musicaFondo;
            musicaSource.loop = true;
            musicaSource.Play();
        }
    }

    public void ReproducirSfx(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}