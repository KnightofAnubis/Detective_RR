using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private float typingSpeed = 0.01f;

    [Header("Choices UI")]
    [SerializeField]
    private VerticalLayoutGroup _choiceButtonContainer;
    [SerializeField]
    private Button _choiceButtonPrefab;

    [Header("Characters")]
    public bool secretary = true;
    public bool ArthurEnter = false;
    public bool ArthurExit = false;
    public bool Detective = false;
    [SerializeField] Sprite secretaryBox;
    [SerializeField] Sprite ArthurBox;
    [SerializeField] Sprite DetectiveBox;
    [SerializeField] Sprite HoratioBox;
    [SerializeField] Sprite PeterBox;


    private Story currentStory;

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    public bool dialogueIsPlaying { get; private set; }

    Image m_image;

    private bool isAddingRichTextTag = false;
   

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning: too many");
            
        }
        instance = this; 
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        m_image = dialoguePanel.GetComponent<Image>();

    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        
    }

    public void OnClick()
    {
        if (canContinueToNextLine)
        {
            DisplayNextLine();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        DisplayNextLine();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        _textField.text = "";
        if(ArthurEnter == true)
        {
            ArthurExit = true;
            ArthurEnter = false;
        }
        secretary = false;
        if(secretary == false)
        {
            ArthurEnter = true;
        }
        
       
    }

    private IEnumerator DisplayLine(string line)
    {
        // set the text to the full line, but set the visible characters to 0
        _textField.text = line;
        _textField.maxVisibleCharacters = 0;
        // hide items while text is typing
        continueIcon.SetActive(false);


        canContinueToNextLine = false;

        

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
             if (Input.GetKeyDown(KeyCode.Space))
             {
                _textField.maxVisibleCharacters++;

             }
            // check for rich text tag, if found, add it without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            
            // if not rich text, add the next letter and wait a small time
            else
            {

                _textField.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // actions to take after the entire line has finished displaying

        isAddingRichTextTag = false;
        canContinueToNextLine = true;
        continueIcon.SetActive(true);
    }

    public void DisplayNextLine()
    {


        if (currentStory.canContinue)
        {

            string text = currentStory.Continue();
            text = text?.Trim();
            displayLineCoroutine = StartCoroutine(DisplayLine(text));
            CharacterPannel();
            _textField.text = text;

        }
        else if (currentStory.currentChoices.Count > 0)
        {
            DisplayChoices();

        }

        else
        {
            ExitDialogueMode();
        }


    }

    private void DisplayChoices()
    {
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < currentStory.currentChoices.Count; i++)
        {
            var choice = currentStory.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;

        return choiceButton;
    }



    void OnClickChoiceButton(Choice choice)
    {
        currentStory.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
        DisplayNextLine();


    }


    void RefreshChoiceView()
    {
        foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
    }

    void CharacterPannel()
    {
        if (currentStory.currentTags.Contains("Secretary"))
        {
            
            m_image.sprite = secretaryBox;
        }

        if (currentStory.currentTags.Contains("Arthur"))
        {
           
            m_image.sprite = ArthurBox;
        }

        if (currentStory.currentTags.Contains("Detective"))
        {
            
            m_image.sprite = DetectiveBox;
        }

        if (currentStory.currentTags.Contains("Horatio"))
        {

            m_image.sprite = HoratioBox;
        }

        if (currentStory.currentTags.Contains("Peter"))
        {

            m_image.sprite = PeterBox;
        }

    }
}

