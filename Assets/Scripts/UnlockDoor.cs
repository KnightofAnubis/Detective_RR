using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class UnlockDoor : MonoBehaviour
{
   
    [SerializeField] private GameObject door;

    private Scene currentScene;
    private string Scene;

    // Start is called before the first frame update
    private void Start()
    {
        DialogueManager.GetInstance().Door = false;

        currentScene = SceneManager.GetActiveScene();
        Scene = currentScene.name;  
    }
    private void Update()
    {
        if(Scene == "City" || Scene == "AfternoonCity" || Scene == "NightCity" || Scene == "Day2City" || Scene == "Day2Night" || Scene == "GraveYard" || Scene == "City3")
        {
            DialogueManager.GetInstance().Door = false;
        }
        if (DialogueManager.GetInstance().Door == true)
        {
            Debug.Log("Exit?");
       
            door.SetActive(true);

        }
    }
}
