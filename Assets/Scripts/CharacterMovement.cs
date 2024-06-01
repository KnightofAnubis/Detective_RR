using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
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
    private Vector3 last;

   

    public static CharacterMovement instance;
    private bool canPlay;

   
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning: too many");

        }
        instance = this;
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
        anim = GetComponent<Animator>();
        

    }

    private void MouseClick()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
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
        
        last = transform.position;
        CheckUI();
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            OnDisable();
        }
        if (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            canPlay = true;
            if (canPlay)
            {
                 if(destination.x > last.x && destination.y > last.y)
                 {
                    //northeast
                    anim.ResetTrigger("NorthWest");
                    anim.ResetTrigger("SouthWest");
                    anim.ResetTrigger("SouthEast");
              
                    anim.SetTrigger("NorthEast");
                
                 }
                else if (destination.x < last.x && destination.y > last.y)
                {
                    //northwest
                    anim.ResetTrigger("NorthEast");
                    anim.ResetTrigger("SouthWest");
                    anim.ResetTrigger("SouthEast");
                    anim.SetTrigger("NorthWest");
                }
                else if (destination.x > last.x && destination.y < last.y)
                {
                    //southeast
                    anim.ResetTrigger("NorthWest");
                    anim.ResetTrigger("SouthWest");
                    anim.ResetTrigger("NorthEast");
                    anim.SetTrigger("SouthEast");
                }
                else if (destination.x < last.x && destination.y < last.y)
                {
                    //southwest
                    anim.ResetTrigger("NorthWest");
                    anim.ResetTrigger("NorthEast");
                    anim.ResetTrigger("SouthEast");
                    anim.SetTrigger("SouthWest");
                }
                         
            }
            
            //reset
            
            
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            
        }
        if(!canPlay)
        {
            anim.SetTrigger("idol");
        }
        canPlay = false; 
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



