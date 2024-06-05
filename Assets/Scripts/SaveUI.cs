using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SaveUI : MonoBehaviour
{
    public static SaveUI instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Warning: too many");
            return;


        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnPointClick()
    {
        CharacterMovement.instance.OnDisable();
        Debug.Log("Clicked");
    }
}
