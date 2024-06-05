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
        if (Scene == "ArthurHouse" && DialogueManager.GetInstance().Door == true && ClickClues.Instance.noteclue == true)
        {
            Debug.Log("Exit?");
       
            door.SetActive(true);

        }
        else if (Scene == "Hospital" && DialogueManager.GetInstance().Door == true && ClickClues.Instance.glassclue == true)
        {
            Debug.Log("Exit?");

            door.SetActive(true);

        }
        else if (Scene == "Day2Police" && DialogueManager.GetInstance().Door == true && ClickClues.Instance.clothclue == true)
        {
            Debug.Log("Exit?");

            door.SetActive(true);

        }
        else if (Scene == "Morgue" && DialogueManager.GetInstance().Door == true && ClickClues.Instance.veinclue == true)
        {
            Debug.Log("Exit?");

            door.SetActive(true);

        }
        else if (Scene == "ArthurDead" && DialogueManager.GetInstance().Door == true && ClickClues.Instance.receiptclue == true)
        {
            Debug.Log("Exit?");

            door.SetActive(true);

        }
        else if(Scene == "PoliceStation"  && DialogueManager.GetInstance().Door == true)
        {
            door.SetActive(true);
        }

        else if ( Scene == "Bar" && DialogueManager.GetInstance().Door == true)
        {
            door.SetActive(true);
        }
        else if ( Scene == "Day3Police" && DialogueManager.GetInstance().Door == true)
        {
            door.SetActive(true);
        }
    }
}
