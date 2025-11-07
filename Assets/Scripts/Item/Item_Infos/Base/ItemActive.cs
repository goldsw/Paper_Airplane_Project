using UnityEngine;

public abstract class ItemActive : ScriptableObject, Iitem_Active_interface
{
    protected Item_Information Item_info;
    protected GameObject Player;
    protected Player_Physics player_Physics;

    public void Initialize(Item_Information info)
    {
        this.Item_info = info;
        Player = GameObject.FindGameObjectWithTag("Player");
        player_Physics = Player.GetComponent<Player_Physics>();
    }

    virtual public void Manager_Update()
    {
        
    }

    virtual public void Manager_Physics_Update()
    {
        
    }

    virtual public void Manager_Start()
    {
        ItemManager.onPhysicsUpdateInvoke += Manager_Physics_Update;
        ItemManager.onUpdateInvoke += Manager_Update;
    }

    virtual public void Manager_Exit()
    {
        ItemManager.onPhysicsUpdateInvoke -= Manager_Physics_Update;
        ItemManager.onUpdateInvoke -= Manager_Update;
    }

}
