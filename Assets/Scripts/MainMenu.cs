using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlMenu;
    public GameObject pagesMenu;

    public Animator camAnim;
    public Animator doorAnim;

    public void StartGame()
    {
        mainMenu.SetActive(false);
        camAnim.SetTrigger("Play");
        doorAnim.SetTrigger("Open");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Controls()
    {
        mainMenu.SetActive(false);
        camAnim.SetBool("Change", true);
        camAnim.SetBool("Controls", true);

        controlMenu.SetActive(true);
    }

    public void Pages()
    {
        mainMenu.SetActive(false);
        camAnim.SetBool("Change", true);
        camAnim.SetBool("Pages", true);

        pagesMenu.SetActive(true);
    }

    public void Exit()
    {
        mainMenu.SetActive(false);
        camAnim.SetBool("Change", true);
        camAnim.SetBool("Exit", true);

        Debug.Log("Exit");
        Application.Quit();
    } 

    public void Menu()
    {
        camAnim.SetBool("Change", false);
        camAnim.SetBool("Controls", false);
        camAnim.SetBool("Pages", false);
        controlMenu.SetActive(false);
        pagesMenu.SetActive(false);

        mainMenu.SetActive(true);
    }
}
