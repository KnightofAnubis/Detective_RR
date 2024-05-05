using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SecretaryEnterance : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] private GameObject Arthur;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
       
    }
    private void Update()
    {
         if(DialogueManager.GetInstance().secretary == false)
        {
            //Debug.Log("Exit?");
            mAnimator.SetTrigger("Exit");
            Arthur.SetActive(true);
        }   
    }

}
