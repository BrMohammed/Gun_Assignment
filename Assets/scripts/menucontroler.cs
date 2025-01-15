using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroler : MonoBehaviour
{
    public void Beginthegame()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }
}
