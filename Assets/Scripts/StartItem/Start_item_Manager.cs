using UnityEngine;

public class Start_item_Manager : MonoBehaviour
{
    [SerializeField] private Transform start_Item_Pos;

    private Start_Item current_Start_Item;

    public delegate void OnItemActiveInvoke();
    public static OnItemActiveInvoke onUpdateInvokeDelegate;
    public static OnItemActiveInvoke onPhysicsUpdateInvokeDelegate;

    private void Start()
    {
        onUpdateInvokeDelegate += () => { };
        onPhysicsUpdateInvokeDelegate += () => { };
        GameManager.Start_Item_Physics_Delegate += Item_Active_Physics_Update;
        GameManager.Start_Item_Update_Delegate += Item_Active_Update;
    }

    public void InstanceStartPos(GameObject start_Item)
    {
        current_Start_Item = start_Item.GetComponentInChildren<Start_Item>();
        Instantiate(start_Item, start_Item_Pos.position, Quaternion.identity);
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
