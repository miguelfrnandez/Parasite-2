using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PropButtonInteractionScript : MonoBehaviour
{
    public Animator _animator;

    private bool _isInsideTrigger = false;

    public GameObject OpenPanel = null;

    public string OpenText = "E";

    public string CloseText = "E";

    public bool _isOpenDoc = false;

    public bool DrawerisOpen = false;

    public GameObject Drawer = null;

    private DoorInteractionInput DoorIntInp;

    // Start is called before the first frame update
    void Start()
    {
        DoorIntInp = Drawer.gameObject.GetComponent<DoorInteractionInput>();
        //_animator = transform.Find("door04").GetComponent<Animator>();
        //textobj = OpenPanel.gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(textobj.name);
    }

    void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Player")
            {
              //  _isInsideTrigger = true;
                //OpenPanel.SetActive(true);
                //UpdatePanelText();
            }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && DrawerisOpen == true)
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
            UpdatePanelText();
        }
        else if (other.tag == "Player" && DrawerisOpen == false)
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
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
            mText.text = _isOpenDoc ? CloseText : OpenText;
        }
        //TextMeshPro panelText = OpenPanel.transform.GetChild(1).GetComponent<TextMeshPro>().text;
        //if(panelText != null)
        //{
        //  panelText.SetText = _isOpen ? CloseText : OpenText;
        //}
    }

    public void Appear()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _isOpenDoc = !_isOpenDoc;

                Invoke("UpdatePanelText", 1.0f);

                _animator.SetBool("open", _isOpenDoc);

            }
        }
        if (_isOpenDoc == true)
        {
            DoorIntInp.DocisOpen = true;
        }
        else
        {
            DoorIntInp.DocisOpen = false;
        }
    }
}
