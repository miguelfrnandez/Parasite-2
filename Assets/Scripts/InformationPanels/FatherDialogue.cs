using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherDialogue : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(23).gameObject.SetActive(true);
    }
}
