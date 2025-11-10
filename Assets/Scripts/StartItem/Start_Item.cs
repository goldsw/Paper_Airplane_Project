using Unity.VisualScripting;
using UnityEngine;

public class Start_Item : MonoBehaviour
{
    public Start_item_Active Start_item_Active;
    public Start_Item_Information Start_item_Info;

    //test
    bool isClicked = false;

    //Å×½ºÆ®--
    private void Start()
    {
        Start_item_Active.Initialize(Start_item_Info);

        switch (Start_item_Info.item_type) {
            case (Start_Item_Information.Item_type.»õÃÑ):{
                    //±¸Çö
                break;
            }

        }
        if (Start_item_Info.item_type == Start_Item_Information.Item_type.»õÃÑ)
        {
            //ÀÎÇ² ¸Å´ÏÀú¿¡ µå·¡±× ¿£ µå·ÓÀ» ³ö¾ß°Ú´Ù..
        }
        else if (Start_item_Info.item_type == Start_Item_Information.Item_type.·ÎÄÏ)
        {
            //ÀÎÇ²
        }
        else if(Start_item_Info.item_type == Start_Item_Information.Item_type.ÆÈ)
        {
            //ÀÎÇ²
        }
    }
    private void Update()
    {
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
