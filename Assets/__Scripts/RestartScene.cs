using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void Restart()
    {
        //������������� _Scene_0, ����� ������������� ����
        SceneManager.LoadScene("_Scene_0");
    }
}
