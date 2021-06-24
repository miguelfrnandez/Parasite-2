using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedDrawing1 : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(15).gameObject.SetActive(true);
    }
}
