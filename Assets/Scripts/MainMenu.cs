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
        StartCoroutine(ControlsMenu());
    }

    public void Pages()
    {
        mainMenu.SetActive(false);
        camAnim.SetBool("Change", true);
        camAnim.SetBool("Pages", true);

        StartCoroutine(PagesMenu());
    }

    public void Exit()
    {
        mainMenu.SetActive(false);
        camAnim.SetBool("Change", true);
        camAnim.SetBool("Exit", true);

        StartCoroutine(ExitTime());
    } 

    public void Menu()
    {
        camAnim.SetBool("Change", false);
        camAnim.SetBool("Controls", false);
        camAnim.SetBool("Pages", false);
        controlMenu.SetActive(false);
        pagesMenu.SetActive(false);

        StartCoroutine(MMMenu());
    }

    IEnumerator MMMenu()
    {
        yield return new WaitForSeconds(2);
        mainMenu.SetActive(true);
    }

    IEnumerator ControlsMenu()
    {
        yield return new WaitForSeconds(2);
        controlMenu.SetActive(true);
    }

    IEnumerator PagesMenu()
    {
        yield return new WaitForSeconds(2);
        pagesMenu.SetActive(true);
    }

    IEnumerator ExitTime()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Exit");
        Application.Quit();
    }
}
