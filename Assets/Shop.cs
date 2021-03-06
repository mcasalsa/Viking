﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public GameObject shop;
    public Text QuiverArrowText;
    public Text QuiverFireText;
    public Text AxeStatus;
    private float num;
    public Text coinsText;
    private int sumPositiveCoins;
    public Text potionsCount;
    public Text shieldStatus;

    public AudioClip itemShopSound;
    public AudioClip noitemShopSound;
    private Animator anim;
    private GameObject pausated;

    public bool pauseGame;
    public AudioClip clickSound;
    // public AudioClip ambientSound;

    AudioSource soundSource;




    // Use this for initialization
    void Start()
    {
        shop.SetActive(false);
        //shieldStatus.text = "Activat";
        
        soundSource = GetComponent<AudioSource>();
        pausated = GameObject.Find("Pause");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

    void OnTriggerEnter2D(Collider2D collider)
    {

        shop.SetActive(true);

        //Invoke("Pausated", 0.1f);
        shop.SetActive(true);
        pauseGame = true;

        Time.timeScale = (pauseGame) ? 0f : 1f;
    }

    // compra de fletxes.
    public void ArrowsArticle()
    {
        sumPositiveCoins = System.Int32.Parse(coinsText.text);
        if (sumPositiveCoins >= 25)
        {
            num = System.Int32.Parse(QuiverArrowText.text);
            num = num + 10;
            QuiverArrowText.text = (num).ToString();

            // hem comprat 10 fletxes restem 10 monedes.
            sumPositiveCoins = sumPositiveCoins - 26;
            if (sumPositiveCoins < 0)
            {
                sumPositiveCoins = 0;
            }
            coinsText.text = (++sumPositiveCoins).ToString();

        }
    }

    public void FireArticle()
    {
        sumPositiveCoins = System.Int32.Parse(coinsText.text);
        if (sumPositiveCoins >= 25)
        {
            num = System.Int32.Parse(QuiverFireText.text);
            num = num + 10;
            QuiverFireText.text = (num).ToString();

            // hem comprat 10 fletxes restem 10 monedes.
            sumPositiveCoins = sumPositiveCoins - 26;
            if (sumPositiveCoins < 0)
            {
                sumPositiveCoins = 0;
            }
            coinsText.text = (++sumPositiveCoins).ToString();

        }
    }


    // compra de pocions.
    public void PotionsArticle()
    {
        sumPositiveCoins = System.Int32.Parse(coinsText.text);

        if (sumPositiveCoins >= 15)
        {

            //Actualitzem el contador de posions i monendes.

            num = System.Int32.Parse(coinsText.text);
            num = num - 16;
            if (num < 0)
            {
                num = 0;
            }
            coinsText.text = (num).ToString();

            num = System.Int32.Parse(potionsCount.text);
            num = num + 1;
            potionsCount.text = (num).ToString();
            soundSource.clip = itemShopSound;
            soundSource.Play();
        }
        else
        {
            soundSource.clip = noitemShopSound;
            soundSource.Play();
        }
     }



    // compra de escut.
    public void ShieldArticle()
    {
        sumPositiveCoins = System.Int32.Parse(coinsText.text);

        if (sumPositiveCoins >= 2)
        {
            sumPositiveCoins = sumPositiveCoins - 25;
            if (sumPositiveCoins < 0)
            {
                sumPositiveCoins = 0;
            }
                coinsText.text = (sumPositiveCoins).ToString();
            shieldStatus.text = "Activat";
            //anim.SetBool("ShieldAtack", true);

        }
    }

    // compra de escut.
    public void AxeArticle()
    {
        sumPositiveCoins = System.Int32.Parse(coinsText.text);

        if (sumPositiveCoins >= 25)
        {
            sumPositiveCoins = sumPositiveCoins - 25;
            if (sumPositiveCoins < 0)
            {
                sumPositiveCoins = 0;
            }
            coinsText.text = (sumPositiveCoins).ToString();

            
            AxeStatus.text = "Activat";

        }
    }

    public void ExitShop()
    {
        shop.SetActive(false);
        pauseGame = false;
        
        Time.timeScale = (pauseGame) ? 0f : 1f;
        
    }

    public void Pausated()
    {
        pauseGame = !pauseGame;
        pauseGame = true; ;
        //canvasPause.enabled = pauseGame;
        // Time.timeScale regula la velocitat del joc, si es zero llavorsel joc està en pausa.
        // operador ternari ?, si val 0 la pausa esta desactivada i posarem 1 per activar-la i a la inversa.
        Time.timeScale = (pauseGame) ? 0f : 1f;
        Time.timeScale=0f;
    }

    void playClickSound()
    {
        //AudioClip clipToPlay = menuTheme;
        //clipToPlay = menuTheme;
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = clickSound;
        soundSource.Play();
        // AudioClip clipToPlay;


        //clipToPlay = "menuTheme";
        //AudioManager.instance.PlayMusic(clickSound, 1);


   }
}
