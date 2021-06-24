using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceClue : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(5).gameObject.SetActive(true);
    }
}
