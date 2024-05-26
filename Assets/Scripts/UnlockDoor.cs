using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
   
    [SerializeField] private GameObject door;

    // Start is called before the first frame update
   
    private void Update()
    {
       
        if (DialogueManager.GetInstance().Door == true)
        {
            //Debug.Log("Exit?");
       
            door.SetActive(true);

        }
    }
}
