using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteractionInput : MonoBehaviour
{
    public Animator _animator;

    private bool _isInsideTrigger = false;

    public GameObject OpenPanel = null;

    public string OpenText = "E";

    public string CloseText = "E";

    public bool _isOpen = false;

    private PropButtonInteractionScript IntScript;

    public GameObject document;

    public bool DocisOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        IntScript = document.gameObject.GetComponent<PropButtonInteractionScript>();
        //_animator = transform.Find("door04").GetComponent<Animator>();
        //textobj = OpenPanel.gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(textobj.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
            UpdatePanelText();
        }     
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && DocisOpen == true)
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);        
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
            mText.text = _isOpen ? CloseText : OpenText;
        }
        //TextMeshPro panelText = OpenPanel.transform.GetChild(1).GetComponent<TextMeshPro>().text;
        //if(panelText != null)
        //{
        //  panelText.SetText = _isOpen ? CloseText : OpenText;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpen = !_isOpen;

                Invoke("UpdatePanelText", 1.0f);

                _animator.SetBool("open", _isOpen);
                 
                if(_isOpen == true)
                {
                    IntScript.DrawerisOpen = true;
                }
                else
                {
                    IntScript.DrawerisOpen = false;
                }
            }
        }
    }
}
