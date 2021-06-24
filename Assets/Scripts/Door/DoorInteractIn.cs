using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteractIn : MonoBehaviour
{
    public Animator _animator;

    private bool _isInsideTrigger = false;

    public GameObject OpenPanel = null;
    public string OpenText = "E";
    public string CloseText = "E";

    public bool OpenedFromInside_InScript = false;
    public bool OpenedFromOutside_InScript = false;

    [Header("DoorOutsideScript")]
    [SerializeField] private DoorInteract DoorOutScript;
    [SerializeField] public GameObject outsideSide;

    private bool pauseInteraction = false;
    private int waitTimer = 1;

    [Header("AnimationNames")]
    [SerializeField] public string openInsideAnimationName = "DoorOpen";
    [SerializeField] public string closeInsideAnimationName = "DoorClose";
    [SerializeField] public string closeOutsideAnimationName = "DoorCloseOut";

    // Start is called before the first frame update
    void Start()
    {
        DoorOutScript = outsideSide.gameObject.GetComponent<DoorInteract>();
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
            if (!OpenedFromInside_InScript && !OpenedFromOutside_InScript)
            {
                mText.text = OpenText;
            }
            else if (OpenedFromInside_InScript && !OpenedFromOutside_InScript)
            {
                mText.text = CloseText;
            }
            else if (!OpenedFromInside_InScript && OpenedFromOutside_InScript)
            {
                mText.text = CloseText;
            }
            //mText.text = OpenedFromInside ? CloseText : OpenText;
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
                if (!OpenedFromInside_InScript && !pauseInteraction && !OpenedFromOutside_InScript)
                {
                    _animator.Play(openInsideAnimationName, 0, 0.0f);
                    OpenedFromInside_InScript = true;
                    DoorOutScript.OpenedFromInside_OutScript = true;
                    Invoke("UpdatePanelText", 1.0f);
                    StartCoroutine(PauseDoorInteraction());
                    FindObjectOfType<AudioManager>().Play("Door_Open");
                }
                else if (OpenedFromInside_InScript && !pauseInteraction && !OpenedFromOutside_InScript)
                {
                    _animator.Play(closeInsideAnimationName, 0, 0.0f);
                    OpenedFromInside_InScript = false;
                    DoorOutScript.OpenedFromInside_OutScript = false;
                    Invoke("UpdatePanelText", 1.0f);
                    StartCoroutine(PauseDoorInteraction());
                    FindObjectOfType<AudioManager>().Play("Door_Close");
                }
                else if (!OpenedFromInside_InScript && !pauseInteraction && OpenedFromOutside_InScript)
                {
                    _animator.Play(closeOutsideAnimationName, 0, 0.0f);
                    OpenedFromOutside_InScript = false;
                    DoorOutScript.OpenedFromOutside_OutScript = false;
                    Invoke("UpdatePanelText", 1.0f);
                    StartCoroutine(PauseDoorInteraction());
                    FindObjectOfType<AudioManager>().Play("Door_Close");
                }
            }
        }
    }
}
