using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryDad : MonoBehaviour
{
    public GameObject parent;

    public void DiaryAppearDad()
    {
        parent.transform.GetChild(3).gameObject.SetActive(true);
    }
}
