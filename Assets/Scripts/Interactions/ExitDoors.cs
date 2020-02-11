using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitDoors : MonoBehaviour
{
    public float objDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject indicCross;
    public TMP_Text newText;
    public TMP_Text doorInfo;

    public bool door1;
    public bool firstInteraction = false;

    public bool PuzzleD1_1;
    public bool PuzzleD1_2;
    public bool PuzzleD1_3;

    public bool PuzzleD2_1;
    public bool PuzzleD2_2;
    public bool PuzzleD2_3;

    private bool canExit1;
    private bool canExit2;

    public GameObject PadLock1;
    public GameObject PadLock2;
    public GameObject VoiceRecg;
    private CodeLock CLck1;
    private CodeLock CLck2;
    private VoiceControlPuzzle VCP;

    //public AudioSource doorSound;

    private void Start()
    {
        CLck1 = PadLock1.GetComponent<CodeLock>();
        CLck2 = PadLock2.GetComponent<CodeLock>();
        VCP = VoiceRecg.GetComponent<VoiceControlPuzzle>();

        PuzzleD1_1 = false;
        PuzzleD1_2 = false;
        PuzzleD1_3 = false;

        PuzzleD2_1 = false;
        PuzzleD2_2 = false;
        PuzzleD2_3 = false;

        canExit1 = false;
        canExit2 = false;
    }

    void Update()
    {
        objDistance = PlayerInteract.TargetDistance;

        PuzzleD1_3 = CLck2.doneCLk1;
        PuzzleD2_3 = CLck1.doneCLk2;

        PuzzleD1_2 = VCP.doneVC1;
    }

    void OnMouseOver()
    {
        if (objDistance <= 2)
        {
            indicCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            newText.SetText("Go Play Outside.");

        }

        else
        {
            newText.SetText(" ");
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }


        if (Input.GetButtonDown("Action"))
        {
            if (objDistance <= 2)
            {
                if (firstInteraction == false)
                    StartCoroutine(DoorInfo());
                else
                    PuzzleManag();
            }
        }
    }

    void PuzzleManag()
    {
        if(door1 == true)
        {
            if (PuzzleD1_1 == true && PuzzleD1_2 == true && PuzzleD1_3 == true)
            {
                canExit1 = true;
                newText.SetText(" ");
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                StartCoroutine(DoorInfo());
            }
            else
            {
                StartCoroutine(NextScene());
                actionDisplay.SetActive(false);
            }
        }

        else
        {
            if (PuzzleD2_1 == true && PuzzleD2_2 == true && PuzzleD2_3 == true)
            {
                Debug.Log("Here");
                canExit2 = true;
                newText.SetText(" ");
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                StartCoroutine(NextScene());
            }
            else
            {
                StartCoroutine(DoorInfoAfter());
                actionDisplay.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        indicCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator DoorInfo()
    {
        if(firstInteraction == false)
        {
            if (door1 == true)
            {
                doorInfo.SetText("Oh! I know!Dad told me about this door!");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("Let's see...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("He said I need a Key...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...a Combination of Objects...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...and a Voice Password...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...for the Box on the Left");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("Yeah, that was it!");
                yield return new WaitForSeconds(2);
                doorInfo.SetText(" ");
                firstInteraction = true;
            }
            else
            {
                doorInfo.SetText("This door... Hum...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("I think I need a Key...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...a Plier for the Locks...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...and a 6 digt Code!");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("They should be around here...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText(" ");
                firstInteraction = true;
            }
        }
    }

    IEnumerator DoorInfoAfter()
    {
        if (firstInteraction == true)
        {
            if (door1 == true)
            {
                doorInfo.SetText("I'm still missing something...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("Remember Rose, we need a Key...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...a Combination of Objects...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("... And a Voice Password...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("... for the Box on the Left.");
                yield return new WaitForSeconds(2);
                doorInfo.SetText(" ");
            }
            else
            {
                doorInfo.SetText("I really want to go outside, but I'm missing something...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("Don't forget, a Key...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...a Plier for the Lock...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("...and a 6 digt Code.");
                yield return new WaitForSeconds(2);
                doorInfo.SetText("Better take a second look around...");
                yield return new WaitForSeconds(2);
                doorInfo.SetText(" ");
            }
        }
    }

    IEnumerator NextScene()
    {
        //FadeOut
        //doorSound.Play();
        yield return new WaitForSeconds(2);
        Debug.Log("Won!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}