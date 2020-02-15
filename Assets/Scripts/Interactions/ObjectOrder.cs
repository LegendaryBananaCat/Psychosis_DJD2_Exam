using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrder : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    private Animator _animator;

    public GameObject WrongPanel;
    public GameObject RightPanel;

    public bool difInput = false;

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

            _animator.SetBool("Open", true);
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

        yield return new WaitForSeconds(1);

        WrongPanel.SetActive(false); ;
    }

    IEnumerator ShowRightInputMessage()
    {
        FindObjectOfType<SoundManager>().Play("VoicePass_Comb_Right");
        RightPanel.SetActive(true);

        yield return new WaitForSeconds(1);

        RightPanel.SetActive(false); ;
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
