using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour {

    public GameObject obB;
    public GameObject obM;
    public GameObject obS;
    public void ClickB()
    {
        obB.SetActive(true);
        obM.SetActive(false);
        obS.SetActive(false);
    }
    public void ClickM()
    {
        obB.SetActive(false);
        obM.SetActive(true);
        obS.SetActive(false);
    }

    public void ClickS()
    {
        obB.SetActive(false);
        obM.SetActive(false);
        obS.SetActive(true);
    }

    public void ClickReplay()
    {
        SceneManager.LoadScene("PlayScenes");
    }

}