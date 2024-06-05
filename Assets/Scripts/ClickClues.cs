using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ClickClues : MonoBehaviour
{
    private Camera _mainCamera;

    AudioSource _source;
    [SerializeField] AudioClip noteAudio;
    [SerializeField] AudioClip glassAudio;
    [SerializeField] AudioClip handAudio;
    [SerializeField] AudioClip veinAudio;

    public bool noteclue = false;
    public bool glassclue = false;
    public bool clothclue = false;
    public bool veinclue = false;
    public bool receiptclue = false;

    private Scene currentScene;
    private string Scene;

    public static ClickClues Instance;
    private void Awake()
    {
        
        Instance = this;
        _mainCamera = Camera.main;
        _source = GetComponent<AudioSource>();
       
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if(!rayHit.collider ) return;

        //Debug.Log(rayHit.collider.gameObject.name);

        if(rayHit.collider.gameObject.name == "Note")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Empty.SetActive(false);
            SaveInventory.Instance.notEmpty.SetActive(true);

            _source.PlayOneShot(noteAudio);

            SaveInventory.Instance.Note.SetActive(true);
            SaveInventory.Instance.noteInfo.SetActive(true);
            //Destroy(rayHit.collider.gameObject);
        }
        if (rayHit.collider.gameObject.name == "Glass")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Glass.SetActive(true);
            SaveInventory.Instance.glassInfo.SetActive(true);
            _source.PlayOneShot(glassAudio);

            Destroy(rayHit.collider.gameObject);
        }
        if (rayHit.collider.gameObject.name == "Cloth")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Cloth.SetActive(true);
            SaveInventory.Instance.clothInfo.SetActive(true);
            _source.PlayOneShot(handAudio);

            Destroy(rayHit.collider.gameObject);
        }
        if (rayHit.collider.gameObject.name == "Vein")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Vein.SetActive(true);
            SaveInventory.Instance.veinInfo.SetActive(true);
            _source.PlayOneShot(veinAudio);

            Destroy(rayHit.collider.gameObject);
        }

        if (rayHit.collider.gameObject.name == "receipt")
        {
             CharacterMovement.instance.OnDisable();

           
            SaveInventory.Instance.Receipt.SetActive(true);
            SaveInventory.Instance.receiptInfo.SetActive(true);
            _source.PlayOneShot(noteAudio);
            Destroy(rayHit.collider.gameObject);           
        }

    }

    public void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        Scene = currentScene.name;
        if (Scene == "ArthurHouse" && SaveInventory.Instance.Note.activeSelf == true)
        {
            noteclue = true;
        }
        if (Scene == "Hospital" && SaveInventory.Instance.Glass.activeSelf == true)
        {
            glassclue = true;
        }
        if (Scene == "Day2Police" && SaveInventory.Instance.Cloth.activeSelf == true)
        {
            clothclue = true;
        }
        if (Scene == "Morgue" && SaveInventory.Instance.Vein.activeSelf == true)
        {
            veinclue = true;
        }
        if (Scene == "ArthurDead" && SaveInventory.Instance.Receipt.activeSelf == true)
        {
            receiptclue = true;
        }
    }

}
