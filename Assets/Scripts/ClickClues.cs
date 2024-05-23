using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ClickClues : MonoBehaviour
{
    private Camera _mainCamera;
    
    

    private void Awake()
    {
        _mainCamera = Camera.main;
        
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
            SaveInventory.Instance.Note.SetActive(true);
            SaveInventory.Instance.noteInfo.SetActive(true);
            //Destroy(rayHit.collider.gameObject);
        }
        if (rayHit.collider.gameObject.name == "Glass")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Glass.SetActive(true);
            SaveInventory.Instance.glassInfo.SetActive(true);
            Destroy(rayHit.collider.gameObject);
        }
        if (rayHit.collider.gameObject.name == "Cloth")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Cloth.SetActive(true);
            SaveInventory.Instance.clothInfo.SetActive(true);
            Destroy(rayHit.collider.gameObject);
        }
        if (rayHit.collider.gameObject.name == "Vein")
        {
            CharacterMovement.instance.OnDisable();
            SaveInventory.Instance.Vein.SetActive(true);
            SaveInventory.Instance.veinInfo.SetActive(true);
            Destroy(rayHit.collider.gameObject);
        }


    }

}
