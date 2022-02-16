using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void Restart()
    {
        //Перезагрузить _Scene_0, чтобы перезапустить игру
        SceneManager.LoadScene("_Scene_0");
    }
}
