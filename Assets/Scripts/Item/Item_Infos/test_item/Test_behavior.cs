using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Item_Active/Test_BeHavior", order = 1)]

public class Test_behavior : ItemActive
{

    public override void Manager_Exit()
    {
        base.Manager_Exit();
    }

    public override void Manager_Physics_Update()
    {
        player_Physics.Add_Force(Item_info.direction.normalized * Item_info.speed);
        base.Manager_Physics_Update();
    }

    public override void Manager_Start()
    {
        base.Manager_Start();
    }

    public override void Manager_Update()
    {
        base.Manager_Update();
    }
}
