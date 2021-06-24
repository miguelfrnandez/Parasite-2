using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottles : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(17).gameObject.SetActive(true);
    }
}
