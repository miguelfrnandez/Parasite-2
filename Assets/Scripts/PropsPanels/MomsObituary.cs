using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomsObituary : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(11).gameObject.SetActive(true);
    }
}
