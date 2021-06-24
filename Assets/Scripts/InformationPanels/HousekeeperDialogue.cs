using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousekeeperDialogue : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(24).gameObject.SetActive(true);
    }
}
