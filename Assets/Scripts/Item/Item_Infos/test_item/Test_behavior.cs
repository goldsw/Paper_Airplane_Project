using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Item_Active/Test_BeHavior", order = 1)]

public class Test_behavior : ItemActive
{

    float timer = 0f;
    public override void Manager_Update()
    {
        if (timer > Item_info.duration) Manager_Exit();

        base.Manager_Update();

        timer += Time.deltaTime;
    }
    public override void Manager_Physics_Update()
    {
        base.Manager_Physics_Update();
        player_Physics.Add_Force(Item_info.direction.normalized * Item_info.force);
        player_Physics.Add_Max_Speed(Item_info.max_speed);
    }
    public override void Manager_Start()
    {
        base.Manager_Start();
        //패시브 활성화
        // UI 활성화 후 UI 대기
    }
    public override void Manager_Exit()
    {
        base.Manager_Exit();
        timer = 0f;
    }
}

