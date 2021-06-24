using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(21).gameObject.SetActive(true);
    }
}
