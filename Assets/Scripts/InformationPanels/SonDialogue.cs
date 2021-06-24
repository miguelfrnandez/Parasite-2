using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonDialogue : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(25).gameObject.SetActive(true);
    }
}
