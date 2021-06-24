using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryHousekeeper : MonoBehaviour
{
    public GameObject parent;

    public void DiaryAppearHousekeeper()
    {
        parent.transform.GetChild(4).gameObject.SetActive(true);
    }
}
