using Unity.VisualScripting;
using UnityEngine;

public class Start_Item : MonoBehaviour
{
    public Start_item_Active Start_item_Active; //이게 꼭 스크립타블?
    public Start_Item_Information Start_item_Info;

    //test
    bool isClicked = false;

    //테스트--

    bool test = true;

    private void Start()
    {
        Start_item_Active.Initialize(Start_item_Info, this);

        switch (Start_item_Info.item_type) {
            case (Start_Item_Information.Item_type.SlingShot):{
                    //구현
                break;
            }

        }
    }
    private void Update()
    {

        //TODO : 테스트 다 하고 연결 끊어!
        if (Input.GetMouseButtonDown(0) && test == true)
        {
            Start_item_Active.testin(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            OnClick();
        }
        if (Input.GetMouseButtonUp(0) && test == true)
        {
            Start_item_Active.testout(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            OnEnd();
            test = true;
        }

    }
    //-----------

    public void OnClick()
    {
        Start_item_Active.Manager_Start();
    }

    public void OnEnd()
    {
        Start_item_Active.Manager_Exit();
    }


}
