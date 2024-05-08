using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Clue 1")]
    [SerializeField] public GameObject Note;
    [SerializeField] public GameObject noteInfo;

    public static SaveInventory Instance;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

   


}
