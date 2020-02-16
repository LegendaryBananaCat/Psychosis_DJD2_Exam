using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class OpeningSeq : MonoBehaviour
{

    public GameObject thePlayer;
    public GameObject fadeScreen;
    public TMP_Text textBox;


    void Start()
    {
        thePlayer.GetComponent<PlayerMov>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        fadeScreen.SetActive(false);
        textBox.GetComponent<TMP_Text>().text = "I need to get out of here, I don't know what they'll do to me if I stay here any longer.";
        yield return new WaitForSeconds(4);
        thePlayer.GetComponent<PlayerMov>().enabled = true;
        textBox.GetComponent<TMP_Text>().text = "There's an old Map and a Pen on the table. I should take it with me. It might come in handy later.";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<TMP_Text>().text = "For now. Checking the doors first is seems the best course of action.";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<TMP_Text>().text = "";
    }
}
