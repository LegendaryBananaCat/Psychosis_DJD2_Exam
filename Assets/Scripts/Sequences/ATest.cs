using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ATest : MonoBehaviour
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
        textBox.GetComponent<TMP_Text>().text = "I need to get out of here.";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<TMP_Text>().text = "";
        thePlayer.GetComponent<PlayerMov>().enabled = true;
    }
}
