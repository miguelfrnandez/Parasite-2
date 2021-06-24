using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentSon : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(12).gameObject.SetActive(true);
    }
}
