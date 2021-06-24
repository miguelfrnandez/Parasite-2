using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationOfficer : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(10).gameObject.SetActive(true);
    }
}
