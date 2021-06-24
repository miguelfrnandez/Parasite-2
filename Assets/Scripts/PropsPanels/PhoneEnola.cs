using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneEnola : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(22).gameObject.SetActive(true);
    }
}
