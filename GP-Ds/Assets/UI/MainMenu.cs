using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour 
{
    //UI Screens states for Main Menu
    public GameObject ControlsUI, MainMenuUI, IntroductionUI, CreditsUI, PartyAssestsUI;

    //Button selection states for Main Menu
    public GameObject ControlsFirstButton, MainMenuFirstButton, IntroductionFirstButton, CreditsFirstButton, PartyAssestsFirstButton;

    //This will load D1234567 from the current bulid settings
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Controls UI
    public void OpenControls()
    {
        MainMenuUI.SetActive(false);
        IntroductionUI.SetActive(false);
        ControlsUI.SetActive(true);
        CreditsUI.SetActive(false);
        PartyAssestsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ControlsFirstButton);
    }

    //MainMenu UI
    public void OpenMainMenu()
    {
        MainMenuUI.SetActive(true);
        IntroductionUI.SetActive(false);
        ControlsUI.SetActive(false);
        CreditsUI.SetActive(false);
        PartyAssestsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(MainMenuFirstButton);

    }

    //Introduction UI
    public void OpenIntroduction()
    {
        MainMenuUI.SetActive(false);
        IntroductionUI.SetActive(true);
        ControlsUI.SetActive(false);
        CreditsUI.SetActive(false);
        PartyAssestsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(IntroductionFirstButton);
    }

    //Credits UI
    public void OpenCredits()
    {
        MainMenuUI.SetActive(false);
        IntroductionUI.SetActive(false);
        ControlsUI.SetActive(false);
        CreditsUI.SetActive(true);
        PartyAssestsUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(CreditsFirstButton);
    }

    //PartyAssests UI
    public void OpenPartyAssests()
    {
        MainMenuUI.SetActive(false);
        IntroductionUI.SetActive(false);
        ControlsUI.SetActive(false);
        CreditsUI.SetActive(false);
        PartyAssestsUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(PartyAssestsFirstButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
