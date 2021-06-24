using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseClue : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject son;
    public GameObject daughter;
    public GameObject dad;
    public GameObject housekeeper;
    public GameObject image;
    public GameObject ending;
    public GameObject information;
    public GameObject MomsObituary;
    public GameObject AssessmentSon;
    public GameObject LetterHousekeeper;
    public GameObject RegistrationHousekeeper;
    public GameObject TedDrawing1;
    public GameObject TedDrawing2;
    public GameObject Bottles;
    public GameObject Gun;
    public GameObject Hammer;
    public GameObject Knife;
    public GameObject Cutter;
    public GameObject PhoneEnola;
    public GameObject DadDialogue;
    public GameObject HousekeeperDialogue;
    public GameObject SonDialogue;
    public GameObject necklace;
    public GameObject PoliceDialogue;


    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (son.activeInHierarchy)
            {
                son.SetActive(false);
            }
            else if (daughter.activeInHierarchy)
            {
                daughter.SetActive(false);
            }
            else if (dad.activeInHierarchy)
            {
                dad.SetActive(false);
            }
            else if (housekeeper.activeInHierarchy)
            {
                housekeeper.SetActive(false);
            }
            else if (ending.activeInHierarchy)
            {
                ending.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (information.activeInHierarchy)
            {
                information.SetActive(false);
            }
            else if (MomsObituary.activeInHierarchy)
            {
                MomsObituary.SetActive(false);
            }
            else if (AssessmentSon.activeInHierarchy)
            {
                AssessmentSon.SetActive(false);
            }
            else if (LetterHousekeeper.activeInHierarchy)
            {
                LetterHousekeeper.SetActive(false);
            }
            else if (RegistrationHousekeeper.activeInHierarchy)
            {
                RegistrationHousekeeper.SetActive(false);
            }
            else if (TedDrawing1.activeInHierarchy)
            {
                TedDrawing1.SetActive(false);
            }
            else if (TedDrawing2.activeInHierarchy)
            {
                TedDrawing2.SetActive(false);
            }
            else if (Bottles.activeInHierarchy)
            {
                Bottles.SetActive(false);
            }
            else if (Gun.activeInHierarchy)
            {
                Gun.SetActive(false);
            }
            else if (Hammer.activeInHierarchy)
            {
                Hammer.SetActive(false);
            }
            else if (Knife.activeInHierarchy)
            {
                Knife.SetActive(false);
            }
            else if (Cutter.activeInHierarchy)
            {
                Cutter.SetActive(false);
            }
            else if (DadDialogue.activeInHierarchy)
            {
                DadDialogue.SetActive(false);
            }
            else if (HousekeeperDialogue.activeInHierarchy)
            {
                HousekeeperDialogue.SetActive(false);
            }
            else if (SonDialogue.activeInHierarchy)
            {
                SonDialogue.SetActive(false);
            }
            else if (PhoneEnola.activeInHierarchy)
            {
                PhoneEnola.SetActive(false);
            }
            else if (necklace.activeInHierarchy)
            {
                necklace.SetActive(false);
            }
            else if (PoliceDialogue.activeInHierarchy)
            {
                PoliceDialogue.SetActive(false);
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        image.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        image.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
