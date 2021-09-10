using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunkontrol : MonoBehaviour
{
    public GameObject Gokyuzu;
    public GameObject Gokyuzu2;
    Rigidbody2D fizikbir;
    Rigidbody2D fizikIki;
    float uzunluk = 0;
    public float arkaplanınHızı;

    public GameObject engel;
    public int KacAdetEngel=5;
    GameObject[] engeller;

    float degisimZaman = 0;
    int sayac = 0;
    bool oyunbitti = true;
    void Start()
    {
        fizikbir = Gokyuzu.GetComponent<Rigidbody2D>();
        fizikIki = Gokyuzu2.GetComponent<Rigidbody2D>();
        fizikbir.velocity = new Vector2(-arkaplanınHızı, 0);
        fizikIki.velocity = new Vector2(-arkaplanınHızı, 0);

        uzunluk=Gokyuzu.GetComponent<BoxCollider2D>().size.x;
        engeller = new GameObject[KacAdetEngel];
        for (int i=0; i<engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel,new Vector2(9.52f,9.52f),Quaternion.identity);
            Rigidbody2D fizikEngel= engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(-arkaplanınHızı, 0);
        }

    }

    
    void Update()
    {
        if (oyunbitti)
        {
            if (Gokyuzu.transform.position.x <= -uzunluk)
            {
                Gokyuzu.transform.position += new Vector3(uzunluk * 2, 0);

            }
            if (Gokyuzu2.transform.position.x <= -uzunluk)
            {
                Gokyuzu2.transform.position += new Vector3(uzunluk * 2, 0);

            }
            /////////----------------------------------------------
            degisimZaman += Time.deltaTime;
            if (degisimZaman > 2f)
            {
                degisimZaman = 0;
                float Yeksenim = Random.Range(2.50f, 3.25f);
                engeller[sayac].transform.position = new Vector3(18, Yeksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }
            }
        }
        else
        {
            
        }
    }
    public void Oyunbitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikbir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
        oyunbitti = false;
    }
}
