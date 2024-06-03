using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string nextScene;
    public Animator transition;
    public float transitionTime = 1f;

    private Scene currentScene;
    private string Scene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Scene = currentScene.name;
    }

    private void Update()
    {
       
        if (DialogueManager.GetInstance().end == true && !DialogueManager.GetInstance().dialogueIsPlaying && Scene == "Bar3")
        {
            Debug.Log("Ending");
            StartCoroutine(LoadLevel(nextScene));
        }
    }


    public void OnClick()
    {
        
        StartCoroutine(LoadLevel(nextScene));

    }


    public void Restart()
    {
        StartCoroutine(LoadLevel("MainMenu"));
    }


    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
