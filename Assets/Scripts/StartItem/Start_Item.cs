using Unity.VisualScripting;
using UnityEngine;

public class Start_Item : MonoBehaviour
{
    public Start_item_Active Start_item_Active;
    public Start_Item_Information Start_item_Info;

    //test
    bool isClicked = false;

    //테스트--
    private void Start()
    {
        Start_item_Active.Initialize(Start_item_Info, this);

        switch (Start_item_Info.item_type) {
            case (Start_Item_Information.Item_type.새총):{
                    //구현
                break;
            }

        }
        if (Start_item_Info.item_type == Start_Item_Information.Item_type.새총)
        {
            //인풋 매니저에 드래그 엔 드롭을 놔야겠다..
        }
        else if (Start_item_Info.item_type == Start_Item_Information.Item_type.로켓)
        {
            //인풋
        }
        else if(Start_item_Info.item_type == Start_Item_Information.Item_type.팔)
        {
            //인풋
        }
    }
    private void Update()
    {

        //TODO : 테스트 다 하고 연결 끊어!
        if (Input.GetMouseButtonDown(0))
        {
            Start_item_Active.testin(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            OnClick();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Start_item_Active.testout(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            OnEnd();
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
