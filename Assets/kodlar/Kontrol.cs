using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kontrol : MonoBehaviour
{
    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    bool ilerigeriKontrol = true;
    int kussayac = 0;
    float KusAnimasyonZamani = 0;

    Rigidbody2D fizik;
    int puan = 0;
    public Text puantext;
    bool oyunbitti = true;
    oyunkontrol oyunKontrol;
    AudioSource []sesler;
    int bestSkor = 0;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontroltag").GetComponent<oyunkontrol>();
        sesler = GetComponents<AudioSource>();
        bestSkor = PlayerPrefs.GetInt("BestSkorKayit");
        Debug.Log("BEST SKOR= "+ bestSkor);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& oyunbitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 200));
            sesler[0].Play();
        }
        if(fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        Animasyon();
    }
    void Animasyon()
    {
            KusAnimasyonZamani += Time.deltaTime;
            if (KusAnimasyonZamani > 0.2f)
            {
                KusAnimasyonZamani = 0;
                if (ilerigeriKontrol)
                {
                    spriteRenderer.sprite = kusSprite[kussayac];
                    kussayac++;
                    if (kussayac == kusSprite.Length)
                    {
                        kussayac--;
                        ilerigeriKontrol = false;
                    }
                }
                else
                {
                    kussayac--;
                    spriteRenderer.sprite = kusSprite[kussayac];
                    if (kussayac == 0)
                    {
                        kussayac++;
                        ilerigeriKontrol = true;
                    }
                }
            }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="puantag")
        {
            puan++;
            puantext.text = "puan= " + puan;
            sesler[2].Play();
            Debug.Log(puan);
        }
        if (col.gameObject.tag=="engeltag")
        {
            oyunbitti = false;
            sesler[1].Play();
            oyunKontrol.Oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false;
            if (puan>bestSkor)
            {
                bestSkor = puan;
                PlayerPrefs.SetInt("BestSkorKayit", bestSkor);
            }
            Invoke("anaMenuyeDon",2);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puankayit", puan);
        SceneManager.LoadScene("anamenu");
        
    }
}

