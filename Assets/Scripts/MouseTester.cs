using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTester : MonoBehaviour
{
    Vector3 startPos = new Vector3();
    Vector3 endPos = new Vector3();

    GameObject tempDrag;
    public GameObject dummy;
    // Update is called once per frame
    void Update()
    {
        //���콺 ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            //���콺 ���� ��ġ ����
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            //������ġ�� ������ ���� 
            tempDrag = Instantiate(dummy, startPos, Quaternion.Euler(90,0,0)) as GameObject;
            //���� ��ġ ���
        }

        //���콺 ������ ������ ������ ��
        if (Input.GetMouseButton(0))
        {
            //���� ���콺�� ��ġ
            endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            //�巡�� �̹����� ��ġ�� ���콺 ��ġ��
            tempDrag.transform.position = endPos;
            //�̺κ��� �����ؾ� �ɰ� ������ Scale ������ ��� �ؾߵ��� ���� �ȿͿ� ;
            tempDrag.transform.localScale = new Vector3(endPos.x - startPos.x, endPos.y - startPos.y, 1);

        }

        //���콺 ��ư�� ���� ��
        if (Input.GetMouseButtonUp(0))
        {
           Destroy(tempDrag);
        }
    }
}
