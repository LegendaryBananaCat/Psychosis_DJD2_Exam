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

    public bool doneCLk1 = false;
    public bool doneCLk2 = false;

    public ExitDoors ED;


    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            StartCoroutine(ShowRightInputMessage());

            if (door1 == true)
            {
                doneCLk1 = true;
                ED.padlockPuzzle.PD = true;
                ED.padlockPuzzle.firstInteraction = true;
            }
            else
            {
                doneCLk2 = true;
                ED.padlockPuzzle.PD = true;
                ED.padlockPuzzle.firstInteraction = true;
            }
        }

        else
        {
            StartCoroutine(ShowWrongInputMessage());
        }
    }

    IEnumerator ShowWrongInputMessage()
    {
        FindObjectOfType<SoundManager>().Play("PassW_Comb_Wrong");
        WrongPanel.SetActive(true);

        yield return new WaitForSeconds(2);

        WrongPanel.SetActive(false); ;
    }

    IEnumerator ShowRightInputMessage()
    {
        FindObjectOfType<SoundManager>().Play("PassW_Comb_Right");
        RightPanel.SetActive(true);

        yield return new WaitForSeconds(2);

        RightPanel.SetActive(false);

        Destroy(this);
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
