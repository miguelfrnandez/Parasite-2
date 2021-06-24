using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedDrawing2 : MonoBehaviour
{
    public GameObject parent;

    public void PanelAppear()
    {
        parent.transform.GetChild(16).gameObject.SetActive(true);
    }
}
