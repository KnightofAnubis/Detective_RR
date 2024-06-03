using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
   
    [Header("Sources")]
    [SerializeField] AudioSource audioSource;
    

    [Header("Music Clips")]
    [SerializeField] private AudioClip audioclip;
   



    
    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
       audioSource.PlayOneShot(audioclip); 
       
    }

    
   
    

}
