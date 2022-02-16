using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [Header("Set Dynamically")]
    public GameObject halo; //переменная для ссылки на объект halo
    public bool mouseDownActive; //нажатие мыши


    private void Awake()
    {
        Transform haloTrans = transform.Find("Halo"); //Находим дочерний объект Square с именем Halo
        halo = haloTrans.gameObject; //Получаем его объект через компонент transform
        halo.SetActive(false); //Выключаем его
    }

    private void OnMouseEnter()
    {
        halo.SetActive(true); //Включить подсветку при наведении
    }

    private void OnMouseExit()
    {
        halo.SetActive(false);//Выключить подстветку при наведении
    }

    private void OnMouseDown()
    {
        mouseDownActive = true; //при нажатии не даёт сработать методу Update
    }

    private void Update()
    {
        if (!mouseDownActive) return; //Если квадрат не выбран, выход

        //Получить текущие координаты указателя мыши
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Присвоить текущие координаты
        this.transform.position = mousePos3D;

        if (Input.GetMouseButtonUp(0)) //Если кнопка отпущена
        {
            mouseDownActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Когда в область триггера попадает объект, уничтожить его
        if (other.gameObject.tag == "Circle") //Проверка на то что это был круг. На будущее)
        {
            Main.S.UpdateScoreGT();
            Destroy(other.gameObject);//Уничтожить круг
        }
    }
}
