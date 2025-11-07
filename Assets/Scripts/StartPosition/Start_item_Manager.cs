using UnityEngine;

public class Start_item_Manager : MonoBehaviour
{

    public delegate void OnItemActiveInvoke();
    public static OnItemActiveInvoke onUpdateInvokeDelegate;
    public static OnItemActiveInvoke onPhysicsUpdateInvokeDelegate;

    private void Start()
    {
        onUpdateInvokeDelegate += () => { };
        onPhysicsUpdateInvokeDelegate += () => { };
    }

    private void FixedUpdate()
    {
        Item_Active_Physics_Update();
    }


    public void Item_Active_Update()
    {
        onUpdateInvokeDelegate.Invoke();
    }
    public void Item_Active_Physics_Update()
    {
        onPhysicsUpdateInvokeDelegate.Invoke();
    }

}
