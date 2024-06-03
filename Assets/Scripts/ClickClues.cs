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

    private void Awake()
    {
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

        if (rayHit.collider.gameObject.name == "Note")
        {
            
            _source.PlayOneShot(noteAudio);

            SaveInventory.Instance.Receipt.SetActive(true);
            SaveInventory.Instance.receiptInfo.SetActive(true);
            Destroy(rayHit.collider.gameObject);
        }

    }

}
