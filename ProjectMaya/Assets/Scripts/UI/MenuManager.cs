using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance = null;
    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuManager>();
                if (instance == null)
                {
                    GameObject managerMenuObject = new GameObject("MenuManager", typeof(MenuManager));
                    instance = managerMenuObject.GetComponent<MenuManager>();
                }
            }
            return instance;
        }

    }

    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public PlayerInput playerInput;
    public SceneTransitionManager sceneManager;
    public string playSceneName;
    private GameObject selectedMenu;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(this.gameObject);
        }

        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        Debug.Log("Play");
        sceneManager.SwitchToScene(playSceneName);
    }

    public void GoToOptions()
    {   
        selectedMenu = optionsMenu;
        optionsMenu.SetActive(true);
    }

    public void GoToCredits()
    {
        selectedMenu = creditsMenu;
        creditsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackMenu()
    {
        selectedMenu.SetActive(false);
        selectedMenu = null;
    }
}
