using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    static public Main S; //������ ��������

    [Header("Set In Inspector")]
    public GameObject prefabCircles; //������ �����
    public int quantityOfCircles = 5; //���������� ������
    public float circleDefaultPadding = 2f; //������ ��� ����������������
    public int scoreF� = 1; //���� �� ����

    [Header("Set Dynamically")]
    public Text scoreGT; //������� �����

    private BoundsCheck bndCheck;
    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        SpawnCircles();
    }

    private void Start()
    {
        //�������� ������ �� ������� ������ Score
        GameObject scoreGO = GameObject.Find("Score");
        //�������� ��������� Text ����� �������� �������
        scoreGT = scoreGO.GetComponent<Text>();
        //���������� ��������� �������� 0
        scoreGT.text = "0";
    }

    public void UpdateScoreGT()
    {
        int score = int.Parse(scoreGT.text); //�������� ����� �����
        score += scoreF�; // ���������� ���� �� ����
        scoreGT.text = score.ToString();// ����������� � ������

        if (score == quantityOfCircles)
        {
            Invoke("SceneRestart", 1f); //�������� ����� � ������� ����� �������
        }
    }

    void SceneRestart() //�������� ����� � �������
    {
        SceneManager.LoadScene("_Scene_1");
    }
    void SpawnCircles()
    {
        for (int i = 0; i < quantityOfCircles; i++)
        {
            //���������� ���� 
            GameObject go = Instantiate<GameObject>(prefabCircles);
            //��������� ����������� ������ � ������
            float circlePadding = circleDefaultPadding;
            if (go.GetComponent<BoundsCheck>() != null) //���� boundscheck ���������, ��������� ������
            {
                circlePadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
            }

            //���������� ��������� ����������
            Vector3 pos = Vector3.zero;
            float xMin = -bndCheck.camWidth + circlePadding;
            float xMax = bndCheck.camWidth - circlePadding;
            pos.x = Random.Range(xMin, xMax);

            float yMin = -bndCheck.camHeight + circlePadding;
            float yMax = bndCheck.camHeight - circlePadding;
            pos.y = Random.Range(yMin, yMax);

            go.transform.position = pos;
        }
    }
}
