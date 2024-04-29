using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Tilemap groundMap;
    [SerializeField] private Tilemap collisionMap;
    MouseInput mouseInput;
    [SerializeField] private float moveSpeed;
    
    private Animator anim;
    private Vector3 destination;

    private void Awake()
    {
        mouseInput = new MouseInput();

    }

    public void OnEnable()
    {
           mouseInput.Enable();
    }

    public void OnDisable()
    {
        mouseInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPostion = groundMap.WorldToCell(mousePosition);
        if(groundMap.HasTile(gridPostion)) 
        {
            
            destination = mousePosition;
           
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckUI();
        if (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        destination = transform.position;
    }

    private void CheckUI()
    {
        if (MainManager.Instance.canvas.activeInHierarchy == true)
        {
            OnDisable();
        }
        else
        {
            OnEnable();
        }
    }
}
