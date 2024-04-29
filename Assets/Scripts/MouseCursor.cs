using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MouseCursor : MonoBehaviour
{
    // Attach this script to a GameObject with a Collider, then mouse over the object to see your cursor change.
    
        [SerializeField] private Texture2D cursorTexture;
        
        private Vector2 hotSpot = Vector2.zero;
    
    void OnMouseEnter()
        {
            // mouse over items and it turns cursor different and disbles player movement
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
           
            //mouse.OnDisable();
        }

    void OnMouseExit()
    {
            // Pass 'null' to the texture parameter to use the default system cursor.
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            //mouse.OnEnable();
    }
    
}
