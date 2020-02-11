using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoiceControlPuzzle : MonoBehaviour
{
    public TMP_InputField inputF;

    public GameObject PmonologueObj;
    public TMP_Text Pmonologue;

    private GameObject Exitdoors;
    private ExitDoors EDS;


    bool truePassW;
    bool fakePassW;
    bool wrongPassW;


    // Start is called before the first frame update
    void Start()
    {
        PmonologueObj.SetActive(false);
        Pmonologue.text = " ";
        truePassW = false;
        fakePassW = false;
        wrongPassW = false;

        Exitdoors = GameObject.FindGameObjectWithTag("ExitDoor");
        EDS = Exitdoors.GetComponent<ExitDoors>();
    }


    void PlayerInput()
    {
        if(inputF.text == "no" || inputF.text == "no")
        {
            truePassW = true;
            StartCoroutine(MonologueManage());
            EDS.PuzzleD1_2 = true;
        }

        else if(inputF.text == "Open sesame" || inputF.text == "Open sesame!" ||inputF.text == "You shall not pass" || inputF.text == "You shall not pass!")
        {
            fakePassW = true;
            StartCoroutine(MonologueManage());
        }

        else
        {
            fakePassW = true;
            StartCoroutine(MonologueManage());
        }
    }

    IEnumerator MonologueManage()
    {
        if(truePassW == true)
        {
            PmonologueObj.SetActive(true);
            Pmonologue.text = "Yes! That was the right one! One more down!";

            yield return new WaitForSeconds(1);

            PmonologueObj.SetActive(false);
            Pmonologue.text = " ";
        }

        else if (truePassW == true)
        {
            PmonologueObj.SetActive(true);
            Pmonologue.text = "Meh. It was worth the try!";

            yield return new WaitForSeconds(1);

            PmonologueObj.SetActive(false);
            Pmonologue.text = " ";
        }

        else if (truePassW == true)
        {
            PmonologueObj.SetActive(true);
            Pmonologue.text = "Wrong one. I bet it's some cheesy line or something. Yuck!";

            yield return new WaitForSeconds(1);

            PmonologueObj.SetActive(false);
            Pmonologue.text = " ";
        }
    }
}
