using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    private Animator _animator;

    public bool door1;

    public GameObject WrongPanel;
    public GameObject RightPanel;

    private GameObject Exitdoors;
    private ExitDoors EDS;


    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        codeLength = code.Length;

        Exitdoors = GameObject.FindGameObjectWithTag("ExitDoor");
        EDS = Exitdoors.GetComponent<ExitDoors>();
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            StartCoroutine(ShowRightInputMessage());

            _animator.SetBool("Open", true);
        }

        else
        {
            StartCoroutine(ShowWrongInputMessage());
        }
    }

    IEnumerator ShowWrongInputMessage()
    {
        WrongPanel.SetActive(true);

        yield return new WaitForSeconds(1);

        WrongPanel.SetActive(false); ;
    }

    IEnumerator ShowRightInputMessage()
    {
        RightPanel.SetActive(true);

        yield return new WaitForSeconds(1);

        RightPanel.SetActive(false);

        if(door1 == true)
        {
            EDS.PuzzleD1_3 = true;
        }
        else
            EDS.PuzzleD2_3 = true;
    }

    public void SetValue(string value)
    {
        placeInCode++;

        if(placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
