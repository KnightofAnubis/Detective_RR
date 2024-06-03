using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private float typingSpeed = 0.03f;

    [Header("Choices UI")]
    [SerializeField]
    private VerticalLayoutGroup _choiceButtonContainer;
    [SerializeField]
    private Button _choiceButtonPrefab;
    [SerializeField]
    private Button _bigchoiceButtonPrefab;

    [Header("Characters")]
    public bool secretary = true;
    public bool ArthurEnter = false;
    public bool ArthurExit = false;
    public bool Detective = false;
    public bool Door = false;
    public bool end = false;
    //dialogue boxes
    [SerializeField] Sprite secretaryBox;
    [SerializeField] Sprite ArthurBox;
    [SerializeField] Sprite DetectiveBox;
    [SerializeField] Sprite HoratioBox;
    [SerializeField] Sprite PeterBox;
    [SerializeField] Sprite RandomBox;
    [SerializeField] Sprite NurseBox;
    [SerializeField] Sprite MorticianBox;
    [SerializeField] Sprite JackBox;
    [SerializeField] Sprite ScottBox;
    [SerializeField] Sprite BarBox;
    [SerializeField] Sprite Civilian1Box;
    [SerializeField] Sprite Civilian2Box;
    [SerializeField] Sprite Civilian3Box;

    //audio clips
    AudioSource audioSource;
    [SerializeField] AudioClip DetectiveAudio;
    [SerializeField] AudioClip SecretaryAudio;
    [SerializeField] AudioClip ArthurAudio;
    [SerializeField] AudioClip HoratioAudio;
    [SerializeField] AudioClip PeterAudio;
    [SerializeField] AudioClip NurseAudio;
    [SerializeField] AudioClip BarAudio;
    [SerializeField] AudioClip MorticianAudio;
    [SerializeField] AudioClip JackAudio;
    [SerializeField] AudioClip Civilian1Audio;
    [SerializeField] AudioClip Civilian2Audio;
    [SerializeField] AudioClip Civilian3Audio;

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
            Destroy(gameObject);
            Debug.Log("Warning: too many");
            return;
            
            
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
       
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
        audioSource = GetComponent<AudioSource>();
        
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
            // check for rich text tag, if found, add it without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _textField.maxVisibleCharacters++;
                isAddingRichTextTag = false;
            }*/
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
        audioSource.Stop();
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
        if (currentStory.currentTags.Contains("Big"))
        {
            var choiceButton = Instantiate(_bigchoiceButtonPrefab);
            choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

            var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = text;

            return choiceButton;
        }
        else
        {
            var choiceButton = Instantiate(_choiceButtonPrefab);
            choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

            var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = text;

            return choiceButton;
        }
       
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
            audioSource.PlayOneShot(SecretaryAudio);
        }

        if (currentStory.currentTags.Contains("Arthur"))
        {
           
            m_image.sprite = ArthurBox;
            audioSource.PlayOneShot(ArthurAudio);
        }

        if (currentStory.currentTags.Contains("Detective"))
        {
            
            m_image.sprite = DetectiveBox;
            audioSource.PlayOneShot(DetectiveAudio);
        }

        if (currentStory.currentTags.Contains("Horatio"))
        {

            m_image.sprite = HoratioBox;
            audioSource.PlayOneShot(HoratioAudio);
        }

        if (currentStory.currentTags.Contains("Peter"))
        {

            m_image.sprite = PeterBox;
            audioSource.PlayOneShot(PeterAudio);
        }
        if (currentStory.currentTags.Contains("Random"))
        {

            m_image.sprite = RandomBox;
        }
        if (currentStory.currentTags.Contains("Nurse"))
        {

            m_image.sprite = NurseBox;
            audioSource.PlayOneShot(NurseAudio);
        }
        if (currentStory.currentTags.Contains("Mortician"))
        {

            m_image.sprite = MorticianBox;
            audioSource.PlayOneShot(MorticianAudio);
        }
        if (currentStory.currentTags.Contains("Scott"))
        {

            m_image.sprite = ScottBox;
        }
        if (currentStory.currentTags.Contains("Jack"))
        {

            m_image.sprite = JackBox;
            audioSource.PlayOneShot(JackAudio);
        }
        if (currentStory.currentTags.Contains("Bar"))
        {

            m_image.sprite = BarBox;
            audioSource.PlayOneShot(BarAudio);
        }
        if (currentStory.currentTags.Contains("Civilian1"))
        {

            m_image.sprite = Civilian1Box;
            audioSource.PlayOneShot(Civilian1Audio);
        }
        if (currentStory.currentTags.Contains("Civilian2"))
        {

            m_image.sprite = Civilian2Box;
            audioSource.PlayOneShot(Civilian2Audio);
        }
        if (currentStory.currentTags.Contains("Civilian3"))
        {

            m_image.sprite = Civilian3Box;
            audioSource.PlayOneShot(Civilian3Audio);
        }
        if (currentStory.currentTags.Contains("Door"))
        {

            Door = true;
        }
        if (currentStory.currentTags.Contains("End"))
        {

            end = true;
        }
    }
}

