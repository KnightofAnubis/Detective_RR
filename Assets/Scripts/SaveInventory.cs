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

    [Header("Clue 2")]
    [SerializeField] public GameObject Glass;
    [SerializeField] public GameObject glassInfo;
    public static SaveInventory Instance;

    [Header("Clue 3")]
    [SerializeField] public GameObject Cloth;
    [SerializeField] public GameObject clothInfo;

    [Header("Clue 4")]
    [SerializeField] public GameObject Vein;
    [SerializeField] public GameObject veinInfo;

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
