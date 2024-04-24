using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string nextScene;
    // Start is called before the first frame update
    public void OnClick()
    {
        SceneManager.LoadScene(nextScene);
    }


    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
