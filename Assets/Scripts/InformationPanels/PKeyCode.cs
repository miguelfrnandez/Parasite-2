using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PKeyCode : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(26).gameObject.SetActive(true);
    }
}
