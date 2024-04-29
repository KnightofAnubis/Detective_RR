using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveInventory : MonoBehaviour
{
    // Start is called before the first frame update

    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

   


}
