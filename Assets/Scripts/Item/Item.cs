using System.Net;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemActive ItemActive;
    public Item_Information Item_Info;
    bool isClicked = false;


    //Å×½ºÆ®--
    private void Awake()
    {
        ItemActive.Initialize(Item_Info);
        
    }

    private void Start()
    {
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
        ItemActive.Manager_Start();
    }

    public void OnEnd()
    {
        ItemActive.Manager_Exit();
    }






}
