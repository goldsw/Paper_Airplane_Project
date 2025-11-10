using System.Net;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemActive itemActive;
    public Item_Information item_Info;
    bool isClicked = false;


    //Å×½ºÆ®--
    private void Start()
    {
        itemActive.Initialize(item_Info);
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if(isClicked == false)
        //    {
        //        OnClick();
        //        isClicked = true;
        //        return;
        //    }
        //    if (isClicked == true)
        //    {
        //        OnEnd();
        //        isClicked= false;
        //        return;
        //    }
        //}

    }
    //-----------

    public void OnClick()
    {
        itemActive.Manager_Start();
    }

    public void OnEnd()
    {
        itemActive.Manager_Exit();
    }






}
