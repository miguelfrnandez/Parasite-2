using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDrawerController : MonoBehaviour
{
    private Animator drawerAnim;
    private bool drawerOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DrawerOpen";
    [SerializeField] private string closeAnimationName = "DrawerClose";

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        drawerAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
    {
        if (!drawerOpen && !pauseInteraction)
        {
            drawerAnim.Play(openAnimationName, 0, 0.0f);
            drawerOpen = true;
            StartCoroutine(PauseDoorInteraction());
            FindObjectOfType<AudioManager>().Play("new_drawer");
        }

        else if (drawerOpen && !pauseInteraction)
        {
            drawerAnim.Play(closeAnimationName, 0, 0.0f);
            drawerOpen = false;
            StartCoroutine(PauseDoorInteraction());
            FindObjectOfType<AudioManager>().Play("new_drawer");
        }
    }
}
