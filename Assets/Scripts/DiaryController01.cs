using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryController01 : MonoBehaviour
{
    public Image image;

    void Start()
    {
        // Turns the image off.
        image.enabled = false;
    }

    public void Diaryappear()
    {
        // Turns the image on if it is off, and off if it is on.
        image.enabled = !image.enabled;
    }
}
