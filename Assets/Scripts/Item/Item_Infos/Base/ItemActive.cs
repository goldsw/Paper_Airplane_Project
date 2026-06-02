using UnityEngine;

public abstract class ItemActive : ScriptableObject, Iitem_Active_interface
{
    protected Item_Information Item_info;
    protected GameObject Player;
    protected Player_Physics player_Physics;

    public void Initialize(Item_Information info) //이러면 안됨 구조체로 분할 필요. 가상 메서드 선언
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
        SkillManager.onPhysicsUpdateInvoke += Manager_Physics_Update;
        SkillManager.onUpdateInvoke += Manager_Update;
    }

    virtual public void Manager_Exit()
    {
        SkillManager.onPhysicsUpdateInvoke -= Manager_Physics_Update;
        SkillManager.onUpdateInvoke -= Manager_Update;
    }

}
