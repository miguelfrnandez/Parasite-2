using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationHousekeeper : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(14).gameObject.SetActive(true);
    }
}
