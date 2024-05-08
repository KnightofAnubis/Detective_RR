using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickBoard : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private GameObject board;

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


        if (rayHit.collider.gameObject.name == "Board")
        {
            board.SetActive(true);
        }
    }
}
