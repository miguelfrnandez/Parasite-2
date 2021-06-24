using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterHousekeeper : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(13).gameObject.SetActive(true);
    }
}
