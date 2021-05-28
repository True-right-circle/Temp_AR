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
        //마우스 버튼을 눌렸을 때
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 시작 위치 저장
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            //시작위치에 프리팩 설정 
            tempDrag = Instantiate(dummy, startPos, Quaternion.Euler(90,0,0)) as GameObject;
            //시작 위치 출력
        }

        //마우스 버툰이 눌러진 상태일 때
        if (Input.GetMouseButton(0))
        {
            //현재 마우스의 위치
            endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            //드래그 이미지의 위치를 마우스 위치로
            tempDrag.transform.position = endPos;
            //이부분을 수정해야 될거 같은데 Scale 가지고 어떻게 해야될지 감이 안와요 ;
            tempDrag.transform.localScale = new Vector3(endPos.x - startPos.x, endPos.y - startPos.y, 1);

        }

        //마우스 버튼을 땠을 때
        if (Input.GetMouseButtonUp(0))
        {
           Destroy(tempDrag);
        }
    }
}
