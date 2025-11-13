using System;
using UnityEditor.Build;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] Item_Slots = new GameObject[3];

    public delegate void OnItemActiveInvoke();
    public static OnItemActiveInvoke onUpdateInvoke;
    public static OnItemActiveInvoke onPhysicsUpdateInvoke;

    private void Start()
    {
        onUpdateInvoke += () => { };
        onPhysicsUpdateInvoke += () => { };
        GameManager.Game_Physics_Delegate += Item_Active_Physics_Update;
        GameManager.Game_Update_Delegate += Item_Active_Update;
    }


    public void Item_Active_Update()
    {
        onUpdateInvoke.Invoke();
    }
    public void Item_Active_Physics_Update()
    {
        onPhysicsUpdateInvoke.Invoke();
    }




}
