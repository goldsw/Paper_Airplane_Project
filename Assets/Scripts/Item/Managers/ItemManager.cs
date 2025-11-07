using System;
using UnityEditor.Build;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    

    public delegate void OnItemActiveInvoke();
    public static OnItemActiveInvoke onUpdateInvoke;
    public static OnItemActiveInvoke onPhysicsUpdateInvoke;

    private void Start()
    {
        onUpdateInvoke += () => { };
        onPhysicsUpdateInvoke += () => { };
    }

    private void FixedUpdate()
    {
        Item_Active_Physics_Update();
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
