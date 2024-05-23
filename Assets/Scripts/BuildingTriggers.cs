using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BuildingTriggers : MonoBehaviour
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
        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);

        if (rayHit.collider.gameObject.name == "Arthur")
        {
            SceneManager.LoadScene("ArthurHouse");

        }

        if (rayHit.collider.gameObject.name == "PoliceStation")
        {
            SceneManager.LoadScene("NightPolice");

        }
        if (rayHit.collider.gameObject.name == "Hospital")
        {
            SceneManager.LoadScene("Hospital");

        }
        if (rayHit.collider.gameObject.name == "Morgue")
        {
            SceneManager.LoadScene("Morgue");

        }
        if (rayHit.collider.gameObject.name == "Bar")
        {
            SceneManager.LoadScene("Bar");

        }


    }

}
