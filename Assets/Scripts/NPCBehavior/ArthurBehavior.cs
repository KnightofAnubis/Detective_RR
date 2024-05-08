using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurBehavior : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] private GameObject door;
   
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (DialogueManager.GetInstance().ArthurEnter == true)
        {
            
            mAnimator.SetTrigger("Enter");
        }

        if (DialogueManager.GetInstance().ArthurExit == true)
        {
            //Debug.Log("Exit?");
            mAnimator.SetTrigger("Exit");
            door.SetActive(true);

        }
    }
}
