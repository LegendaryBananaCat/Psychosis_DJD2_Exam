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

    //public GameObject keyD1;
    //public GameObject keyD2;
    //public GameObject pliersD2;


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
                PuzzleManag();
            }
        }
    }

    void PuzzleManag()
    {
        //if (keyD1.activeInHierarchy == true)
        //{
        //    GameObject[] key1 = GameObject.FindGameObjectsWithTag("FDoorKey");
        //    foreach (GameObject keys in key1)
        //        GameObject.Destroy(keys);

        //    PuzzleD1_1 = true;
        //}

        //else if (keyD2.activeInHierarchy == true)
        //{
        //    GameObject[] key2 = GameObject.FindGameObjectsWithTag("BDoorKey");
        //    foreach (GameObject keys in key2)
        //        GameObject.Destroy(keys);

        //    PuzzleD2_1 = true;
        //}

        //else if (pliersD2.activeInHierarchy == true)
        //{
        //    GameObject[] Ppliers = GameObject.FindGameObjectsWithTag("Plier");
        //    foreach (GameObject Pplier in Ppliers)
        //        GameObject.Destroy(Pplier);

        //    PuzzleD2_2 = true;
        //}


        if (PuzzleD1_1 == true && PuzzleD1_2 == true && PuzzleD1_3 == true)
        {
            canExit1 = true;
            newText.SetText(" ");
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
            //doorSound.Play();
            Debug.Log("Won!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (PuzzleD2_1 == true && PuzzleD2_2 == true && PuzzleD2_3 == true)
        {
            canExit2 = true;
            newText.SetText(" ");
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
            //doorSound.Play();
            Debug.Log("Won!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else
        {
            newText.SetText("We still need to find more things...");
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
            //doorSound.Play();
        }
    }

    void OnMouseExit()
    {
        indicCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}