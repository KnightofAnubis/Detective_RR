using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class BuildingTriggers : MonoBehaviour
{


    public Animator transition;
    public float transitionTime = 1f;

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
            
            StartCoroutine(LoadLevel("ArthurHouse"));

        }
        if (rayHit.collider.gameObject.name == "ArthurDead")
        {
            
            StartCoroutine(LoadLevel("ArthurDead"));

        }

        if (rayHit.collider.gameObject.name == "PoliceStation")
        {
            
            StartCoroutine(LoadLevel("NightPolice"));

        }
        if (rayHit.collider.gameObject.name == "Hospital")
        {
            
            StartCoroutine(LoadLevel("Hospital"));

        }
        if (rayHit.collider.gameObject.name == "Morgue")
        {
            SceneManager.LoadScene("Morgue");
            StartCoroutine(LoadLevel("Morgue"));

        }
        if (rayHit.collider.gameObject.name == "Bar")
        {
            SceneManager.LoadScene("Bar");
            StartCoroutine(LoadLevel("Bar"));

        }
        if (rayHit.collider.gameObject.name == "BarFinal")
        {
            SceneManager.LoadScene("Bar3");
            StartCoroutine(LoadLevel("Bar3"));

        }



    }

    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
