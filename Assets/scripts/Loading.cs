using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using ShopSystem;

public class Loading : MonoBehaviour
{
	[SerializeField] [Range(2f, 8f)] float loadingDelay = 2f;
	[SerializeField] private Text t;
	
	void OnEnable()
	{
		string test = Application.persistentDataPath + "/mydatabase.db";
		if (File.Exists(test))
			t.text = test;
		Time.timeScale = 1;
        Invoke("StartGame", loadingDelay);
    }


	void StartGame()
	{
        //SimpelDb.update(1.ToString(), "gamestart");

        if (int.Parse(SimpelDb.read("Sound")) == 0)
			M_Sound();
		if (int.Parse(SimpelDb.read("Music")) == 0)
			M_Music();
		FindObjectOfType<AudioManager>().PlaySound("background");
		SceneManager.LoadSceneAsync(1);
	}


	public void M_Sound()
	{
		FindObjectOfType<AudioManager>().MuteSound("cancel");
		FindObjectOfType<AudioManager>().MuteSound("loos");
		FindObjectOfType<AudioManager>().MuteSound("femal jump");
		FindObjectOfType<AudioManager>().MuteSound("man jump");
		FindObjectOfType<AudioManager>().MuteSound("run");
		FindObjectOfType<AudioManager>().MuteSound("coin");
		FindObjectOfType<AudioManager>().MuteSound("slide");
		FindObjectOfType<AudioManager>().MuteSound("click");
	}
	public void M_Music()
	{
		FindObjectOfType<AudioManager>().MuteSound("background");
	}

}
