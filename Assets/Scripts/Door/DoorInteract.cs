using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteract : MonoBehaviour
{
    public Animator _animator;

    private bool _isInsideTrigger = false;

    public GameObject OpenPanel = null;
    public string OpenText = "E";
    public string CloseText = "E";

    public bool OpenedFromOutside_OutScript = false;
    public bool OpenedFromInside_OutScript = false;

    [Header("DoorInsideScript")]
    [SerializeField] private DoorInteractIn DoorInScript;
    [SerializeField] public GameObject insideSide;

    private bool pauseInteraction = false;
    private int waitTimer = 1;

    [Header("AnimationNames")]
    [SerializeField] public string openOutsideAnimationName = "DoorOpen";
    [SerializeField] public string closeOutsideAnimationName = "DoorClose";
    [SerializeField] public string closeInsideAnimationName = "DoorClose";


    // Start is called before the first frame update
    void Start()
    {
        DoorInScript = insideSide.gameObject.GetComponent<DoorInteractIn>();
        //_animator = transform.Find("door04").GetComponent<Animator>();
        //textobj = OpenPanel.gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(textobj.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
            UpdatePanelText();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            UpdatePanelText();
        }
        else
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    private void UpdatePanelText()
    {
        //TextMeshPro mText = OpenPanel.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        TextMeshProUGUI mText = OpenPanel.gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if (mText != null)
        {
            if(!OpenedFromOutside_OutScript && !OpenedFromInside_OutScript)
            {
                mText.text = OpenText;
            }
            else if (OpenedFromOutside_OutScript && !OpenedFromInside_OutScript)
            {
                mText.text = CloseText;
            }
            else if (!OpenedFromOutside_OutScript && OpenedFromInside_OutScript)
            {
                mText.text = CloseText;
            }
            //mText.text = OpenedFromOutside ? CloseText : OpenText;
        }
        //TextMeshPro panelText = OpenPanel.transform.GetChild(1).GetComponent<TextMeshPro>().text;
        //if(panelText != null)
        //{
        //  panelText.SetText = _isOpen ? CloseText : OpenText;
        //}
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!OpenedFromOutside_OutScript && !pauseInteraction && !OpenedFromInside_OutScript)
                {
                    _animator.Play(openOutsideAnimationName, 0, 0.0f);
                    OpenedFromOutside_OutScript = true;
                    DoorInScript.OpenedFromOutside_InScript = true;
                    Invoke("UpdatePanelText", 1.0f);
                    StartCoroutine(PauseDoorInteraction());
                    FindObjectOfType<AudioManager>().Play("Door_Open");
                }
                else if (OpenedFromOutside_OutScript && !pauseInteraction && !OpenedFromInside_OutScript)
                {
                    _animator.Play(closeOutsideAnimationName, 0, 0.0f);
                    OpenedFromOutside_OutScript = false;
                    DoorInScript.OpenedFromOutside_InScript = false;
                    Invoke("UpdatePanelText", 1.0f);
                    StartCoroutine(PauseDoorInteraction());
                    FindObjectOfType<AudioManager>().Play("Door_Close");
                }
                else if (!OpenedFromOutside_OutScript && !pauseInteraction && OpenedFromInside_OutScript)
                {
                    _animator.Play(closeInsideAnimationName, 0, 0.0f);
                    OpenedFromInside_OutScript = false;
                    DoorInScript.OpenedFromInside_InScript = false;
                    Invoke("UpdatePanelText", 1.0f);
                    StartCoroutine(PauseDoorInteraction());
                    FindObjectOfType<AudioManager>().Play("Door_Close");
                }
            }
        }
    }
}
