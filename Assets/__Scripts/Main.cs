using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    static public Main S; //Объект одиночка

    [Header("Set In Inspector")]
    public GameObject prefabCircles; //Шаблон круга
    public int quantityOfCircles = 5; //Количество кругов
    public float circleDefaultPadding = 2f; //Отступ для позиционирования
    public int scoreFС = 1; //Очки за круг

    [Header("Set Dynamically")]
    public Text scoreGT; //Счётчик очков

    private BoundsCheck bndCheck;
    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        SpawnCircles();
    }

    private void Start()
    {
        //Получить ссылку на игровой объект Score
        GameObject scoreGO = GameObject.Find("Score");
        //Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        //Установить начальное значение 0
        scoreGT.text = "0";
    }

    public void UpdateScoreGT()
    {
        int score = int.Parse(scoreGT.text); //Получаем целое число
        score += scoreFС; // прибавляем очки за круг
        scoreGT.text = score.ToString();// преобразуем в строку

        if (score == quantityOfCircles)
        {
            Invoke("SceneRestart", 1f); //Загрузка сцены с кнопкой через секунду
        }
    }

    void SceneRestart() //Загрузка сцены с кнопкой
    {
        SceneManager.LoadScene("_Scene_1");
    }
    void SpawnCircles()
    {
        for (int i = 0; i < quantityOfCircles; i++)
        {
            //Разместить круг 
            GameObject go = Instantiate<GameObject>(prefabCircles);
            //присвоить стандартный отступ в отступ
            float circlePadding = circleDefaultPadding;
            if (go.GetComponent<BoundsCheck>() != null) //если boundscheck подключен, присвоить радиус
            {
                circlePadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
            }

            //Установить начальные координаты
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
