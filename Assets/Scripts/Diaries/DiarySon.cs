using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarySon : MonoBehaviour
{
    public GameObject parent;

    public void DiaryAppearSon()
    {
        parent.transform.GetChild(1).gameObject.SetActive(true);
    }
}
