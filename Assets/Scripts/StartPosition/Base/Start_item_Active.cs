using UnityEngine;

public abstract class Start_item_Active : ScriptableObject, Iitem_Active_interface
{
    protected Start_Item_Information Item_info;
    protected GameObject Player;
    protected Player_Physics player_Physics;

    virtual public void Initialize(Start_Item_Information info)
    {
        this.Item_info = info;
        Player = GameObject.FindGameObjectWithTag("Player");
        player_Physics = Player.GetComponent<Player_Physics>();
    }


    virtual public void Manager_Physics_Update()
    {

    }
    virtual public void Manager_Update()
    {

    }
    virtual public void Manager_Start()
    {
        Start_item_Manager.onPhysicsUpdateInvokeDelegate += Manager_Physics_Update;
        Start_item_Manager.onUpdateInvokeDelegate += Manager_Update;
    }
    virtual public void Manager_Exit()
    {
        Start_item_Manager.onPhysicsUpdateInvokeDelegate -= Manager_Physics_Update;
        Start_item_Manager.onUpdateInvokeDelegate -= Manager_Update;
    }

    virtual public void testin(Vector2 vec) { }
    virtual public void testout(Vector2 vec) { }



}
