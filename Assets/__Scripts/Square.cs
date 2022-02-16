using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [Header("Set Dynamically")]
    public GameObject halo; //���������� ��� ������ �� ������ halo
    public bool mouseDownActive; //������� ����


    private void Awake()
    {
        Transform haloTrans = transform.Find("Halo"); //������� �������� ������ Square � ������ Halo
        halo = haloTrans.gameObject; //�������� ��� ������ ����� ��������� transform
        halo.SetActive(false); //��������� ���
    }

    private void OnMouseEnter()
    {
        halo.SetActive(true); //�������� ��������� ��� ���������
    }

    private void OnMouseExit()
    {
        halo.SetActive(false);//��������� ���������� ��� ���������
    }

    private void OnMouseDown()
    {
        mouseDownActive = true; //��� ������� �� ��� ��������� ������ Update
    }

    private void Update()
    {
        if (!mouseDownActive) return; //���� ������� �� ������, �����

        //�������� ������� ���������� ��������� ����
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //��������� ������� ����������
        this.transform.position = mousePos3D;

        if (Input.GetMouseButtonUp(0)) //���� ������ ��������
        {
            mouseDownActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //����� � ������� �������� �������� ������, ���������� ���
        if (other.gameObject.tag == "Circle") //�������� �� �� ��� ��� ��� ����. �� �������)
        {
            Main.S.UpdateScoreGT();
            Destroy(other.gameObject);//���������� ����
        }
    }
}
