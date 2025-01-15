using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    
    [SerializeField] private Text distancescore,gameoverscoretext, highscore, totalcoinGameover,totalcoinMenu;
    [SerializeField] private GameObject pausePanal,gameoverpanal,destancepanel, menupanal,pausebutten, 
                                                resumeicoobj, homeicoobj, returnicoobj,
                                            Gogameovericoobj, Gohighscoreicoobj, Goscoreicoobj, Gohomeicoobj, Goretrygameicoobj,parametericonobj,timer;
    [Header("characters")]
    [SerializeField] private GameObject[] Characters;
    [SerializeField] private GameObject[] Maps;
    static int  destanceunite;
    public bool gamebegin;
    private int characterSelect;
    private int MapsSelect;


    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private GameObject playermove;
    private Vector3 playerrespawn;
    private bool loos = false;



    int in_gameover = 0;
    private void Awake()
    {
        gamebegin = false;

        string shopDataString = SimpelDb.read("SaveDataShop");
        string shopMapDataString = SimpelDb.read("SaveMapDataShop");
        characterSelect = shopDataString.Contains(":") ? int.Parse(shopDataString.Split(':', ',')[1]) : 0;
        MapsSelect = shopMapDataString.Contains(":") ? int.Parse(shopMapDataString.Split(':', ',')[1]) : 0;
        //Debug.Log("MapsSelect" + MapsSelect);
        //Debug.Log("characterSelect" + characterSelect);

        Characters[characterSelect].SetActive(true);
        Maps[MapsSelect].SetActive(true);
        for (int i = 0; i < Maps.Length; i++)
        {
            if (i != MapsSelect)
                Destroy(Maps[i]);
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (i != characterSelect)
                Destroy(Characters[i]);
        }
        //playermove = GameObject.FindGameObjectWithTag("Player");
        //playerrespawn = playermove.transform.position;
        //playerscore//
       
        //InvokeRepeating("setscore", 0, (charactercontrool.speed ) / (charactercontrool.speed * 1.2f));

        makeinstance();

        StartCoroutine(call_return_loop());
    }
    IEnumerator call_return_loop()
    {
        yield return new WaitForEndOfFrame();
        if (loop_of_return_canva.loop_berig_script == true)
        {
            menupanal.SetActive(false);
            Beginthegame();
        }
        else
            menupanal.SetActive(true);
    }
    
    void makeinstance()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        totalcoinGameover.text = "" + int.Parse(SimpelDb.read("TotalCoin"));
        totalcoinMenu.text = "" + int.Parse(SimpelDb.read("TotalCoin"));
    }
    //////////////////////////////////////////playerscore//////////////////////////////
    public void setscore()
    {
            destanceunite++;
            distancescore.text = destanceunite.ToString();
       
    }
    //////////////////////////////////////////pause//////////////////////////////
    public void pauseThegame()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        UiAnimation.butten_haver(pausebutten);
        Time.timeScale = 0f;
        pausePanal.SetActive(true);
        UiAnimation.PausePaneleEAffects(resumeicoobj, homeicoobj, returnicoobj);
    }
    public void RusumeThegame()
    {
        FindObjectOfType<AudioManager> ().PlaySound("click");
        UiAnimation.butten_haver(resumeicoobj);
        UiAnimation.closePausePaneleEAffects(resumeicoobj, homeicoobj, returnicoobj);
        StartCoroutine(RusumeThegame_Deley());
    }

    IEnumerator RusumeThegame_Deley()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        pausePanal.SetActive(false);
    }

    public void menuhome()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        destanceunite = 0;
        if (in_gameover == 1)
        {
            UiAnimation.close_gameovereffect(Gogameovericoobj, Gohighscoreicoobj, Goscoreicoobj, Gohomeicoobj, Goretrygameicoobj);
            in_gameover = 0;
        }
        else
            UiAnimation.closePausePaneleEAffects(resumeicoobj, homeicoobj, returnicoobj);
        StartCoroutine(deley_menuhome());
    }
    IEnumerator deley_menuhome()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
    //////////////////////////////////////////Game over//////////////////////////////
    public void gameover()
    {
        in_gameover = 1;
        gamebegin = false;
        if (loos == false)
        {
            timer.SetActive(false);
            loos = true;
            FindObjectOfType<AudioManager>().PlaySound("loos");
            if (int.Parse(SimpelDb.read("score")) <= destanceunite)
                SimpelDb.update(destanceunite.ToString(),"score");
            StartCoroutine(waitgameover());
        }
       
    }
    IEnumerator waitgameover()
    {
        yield return new WaitForSeconds(2);
        gameoverpanal.SetActive(true);
        UiAnimation.gameovereffect(Gogameovericoobj, Gohighscoreicoobj, Goscoreicoobj, Gohomeicoobj, Goretrygameicoobj);
        gameoverscoretext.text = destanceunite.ToString();
        highscore.text = SimpelDb.read("score");
        destancepanel.SetActive(false);
        pausebutten.SetActive(false);
        StartCoroutine(waitgAwatch());
    }
    IEnumerator waitgAwatch()
    {
        yield return new WaitForSeconds(0.5f);
    }


    public void GameOver_Adwatch()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        loop_of_return_canva.loop_berig_script = true;
        UiAnimation.close_gameovereffect(Gogameovericoobj, Gohighscoreicoobj, Goscoreicoobj, Gohomeicoobj, Goretrygameicoobj);
        StartCoroutine(deley_rGameOver_Adwatch());
    }

    IEnumerator deley_rGameOver_Adwatch()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Enable_Scripts.enable_scripte();
    }

    //////////////////////////////////////////returne//////////////////////////////
    [Obsolete]
    public void returnegame()
    {
        destanceunite = 0;
        loop_of_return_canva.loop_berig_script = true;
        if (in_gameover == 1)
        {
            UiAnimation.close_gameovereffect(Gogameovericoobj, Gohighscoreicoobj, Goscoreicoobj, Gohomeicoobj, Goretrygameicoobj);
            in_gameover = 0;
        }
        else
            UiAnimation.closePausePaneleEAffects(resumeicoobj, homeicoobj, returnicoobj);
        StartCoroutine(deley_returnegame());
    }

    IEnumerator deley_returnegame()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Enable_Scripts.enable_scripte();
    }

    public void Beginthegame()
    {
        timer.SetActive(true);
        pausebutten.SetActive(true);
        menupanal.SetActive(false);
        destancepanel.SetActive(true);
        FindObjectOfType<AudioManager>().PlaySound("click");
        loop_of_return_canva.loop_berig_script = false;
        gamebegin = true;
    }
    IEnumerator delay_tutor()
    {
        yield return new WaitForSeconds(15f);
        gameover();

    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        destancepanel.SetActive(true);
        pausebutten.SetActive(true);
        menupanal.SetActive(false);
    }

    public void Shop()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        UiAnimation.ui.betwen_scines();
        UiAnimation.butten_haver(parametericonobj);
        StartCoroutine(delay2());
    }
    IEnumerator delay2()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(2);
    }

    public void OnUserClickRatMe()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.voon.runlikecrazy"); //your privacy url
    }

    public void OnUserClickInsta()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        Application.OpenURL("https://www.instagram.com/voon.games/"); //your privacy url
    }

    public void Addcoins()
    {
        SimpelDb.update(0.ToString(), "gamestart");
        FindObjectOfType<AudioManager>().PlaySound("click");
        int totalcoin = int.Parse(SimpelDb.read("TotalCoin"));
        print("total coin : " + totalcoin);
        totalcoin = 200;
        SimpelDb.update(totalcoin.ToString(), "TotalCoin");
        print("total coin : " + totalcoin);
        SimpelDb.update(200.ToString(), "score");
    }

    public void Addcoin()
    {
        int totalcoin = int.Parse(SimpelDb.read("TotalCoin"));
        totalcoin++;
        SimpelDb.update(totalcoin.ToString(), "TotalCoin");

    }

    public void CloseGame()
    {
        AudioManager.instance.PlaySound("click");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
