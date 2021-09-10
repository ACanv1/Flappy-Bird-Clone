using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenu : MonoBehaviour
{
    public Text skortext;
    public Text skor;

    void Start()
    {
        int bestSkor = PlayerPrefs.GetInt("BestSkorKayit");
        int puan = PlayerPrefs.GetInt("puankayit");
        skortext.text = "Best Skor; " + bestSkor;
        skor.text = "skor; " + puan;
    }

    void Update()
    {
        
    }
    public void OyunaGit()
    {
        SceneManager.LoadScene("1");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}
