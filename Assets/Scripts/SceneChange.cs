using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string nextScene;
    public Animator transition;
    public float transitionTime = 1f;

    private void Update()
    {
        if (DialogueManager.GetInstance().end == true)
        {
            StartCoroutine(LoadLevel("End"));
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
