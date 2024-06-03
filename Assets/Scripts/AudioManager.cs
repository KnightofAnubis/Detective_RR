using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [Header("Sources")]
    [SerializeField] AudioSource titleSource;
    [SerializeField] AudioSource hospitalSource;
    [SerializeField] AudioSource morgueSource;
    [SerializeField] AudioSource barSource;
    [SerializeField] AudioSource finalSource;
    [SerializeField] AudioSource defaultSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Music Clips")]
    [SerializeField] private AudioClip titleScreen;
    [SerializeField] private AudioClip Hospital;
    [SerializeField] private AudioClip Morgue;
    [SerializeField] private AudioClip Bar;
    [SerializeField] private AudioClip Final;
    [SerializeField] private AudioClip Default;

    [Header("Talking Clips")]
    [SerializeField] public AudioClip DetectiveAudio;
    [SerializeField] public AudioClip SecretaryAudio;
    [SerializeField] public AudioClip ArthurAudio;
    [SerializeField] public AudioClip HoratioAudio;
    [SerializeField] public AudioClip PeterAudio;
    [SerializeField] public AudioClip NurseAudio;
    [SerializeField] public AudioClip BarAudio;
    [SerializeField] public AudioClip MorticianAudio;
    [SerializeField] public AudioClip JackAudio;
    [SerializeField] public AudioClip Civilian1Audio;
    [SerializeField] public AudioClip Civilian2Audio;
    [SerializeField] public AudioClip Civilian3Audio;


    public Scene currentScene;
    private string sceneName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Warning: too many");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
        Songs();
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = currentScene.name;
        Songs();
    }

    private void Songs()
    {
        if (sceneName == "MainMenu")
        {
           
            titleSource.PlayOneShot(titleScreen);
        }
        else if(sceneName == "Hospital")
        {
            hospitalSource.clip = Hospital;
            hospitalSource.Play();
        }
        else if (sceneName == "Morgue")
        {
            
            morgueSource.clip = Morgue;
            morgueSource.Play();
        }
        else if (sceneName == "Bar")
        {

            barSource.clip = Bar;
            barSource.Play();
        }
        else if (sceneName == "Bar3")
        {

            finalSource.clip = Final;
            finalSource.Play();
        }
        else
        {
            titleSource.Stop();
            defaultSource.PlayOneShot(Default);
            
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        SFXSource.Stop();
    }
}
