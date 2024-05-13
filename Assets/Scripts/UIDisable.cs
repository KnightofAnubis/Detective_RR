using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDisable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        // mouse over items and it turns cursor different and disbles player movement
        CharacterMovement.instance.OnDisable();
        Debug.Log("Mouse enter");

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        CharacterMovement.instance.OnEnable();
        //Debug.Log("Mouse exit");
    }
}
