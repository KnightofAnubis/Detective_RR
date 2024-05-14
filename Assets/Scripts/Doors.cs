using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{

    private Camera _mainCamera;
    [SerializeField] private string innerScene;


    private void Awake()
    {
        _mainCamera = Camera.main;

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        //Debug.Log(rayHit.collider.gameObject.name);

        if (rayHit.collider.gameObject.name == "Door")
        {
            SceneManager.LoadScene(innerScene);
            
        }
        if (rayHit.collider.gameObject.name == "Clock")
        {
            SceneManager.LoadScene(innerScene);
            
        }


    }
}
