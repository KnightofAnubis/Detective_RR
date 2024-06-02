using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class Doors : MonoBehaviour
{

    private Camera _mainCamera;
    [SerializeField] private string innerScene;
    [SerializeField] private GameObject officer;

    public Animator transition;
    public float transitionTime = 1f;
    private void Awake()
    {
        _mainCamera = Camera.main;

    }

    private void Start()
    {
        if (SaveInventory.Instance.veinInfo.activeSelf == true)
        {
            officer.SetActive(false);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);

        if (rayHit.collider.gameObject.name == "Door")
        {
            StartCoroutine(LoadLevel(innerScene));
           
            
        }
        if (rayHit.collider.gameObject.name == "Clock")
        {
            if(SaveInventory.Instance.veinInfo.activeSelf == true)
            {
                StartCoroutine(LoadLevel("Day3"));
                
            }
            else
            {
                 StartCoroutine(LoadLevel("Day2Office"));
            }
            
            
        }


    }
    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
