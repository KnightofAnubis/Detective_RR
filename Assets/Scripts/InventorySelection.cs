using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject slot;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // mouse over items and it turns cursor different and disbles player movement
        slot.SetActive(true);
        //Debug.Log("Mouse enter");
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        slot.SetActive(false);
        //Debug.Log("Mouse exit");
    }
}
