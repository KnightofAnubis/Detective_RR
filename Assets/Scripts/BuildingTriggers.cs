using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingTriggers : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;

    [Header("Scene")]
    [SerializeField] private string nextScene;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualcue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualcue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(nextScene);

            }
        }
        else
        {
            visualcue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
