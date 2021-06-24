using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryDaughter : MonoBehaviour
{
    public GameObject parent;

    public void DiaryAppearDaughter()
    {
        parent.transform.GetChild(2).gameObject.SetActive(true);
    }
}
