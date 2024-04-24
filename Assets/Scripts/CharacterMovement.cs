using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

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

        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }
}
