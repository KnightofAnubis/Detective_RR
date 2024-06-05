using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDialogue : MonoBehaviour
{
    public static SaveDialogue instance;
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
}
