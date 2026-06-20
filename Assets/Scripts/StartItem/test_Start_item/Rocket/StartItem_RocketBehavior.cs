using UnityEngine;

public class StartItem_RocketBehavior : Start_item_Active
{


    public override void Manager_Start()
    {
        base.Manager_Start();
        base.Stop_Update();

        //버튼 UI 생성
    }

    public override void Manager_Update()
    {
        base.Manager_Update();

        //버튼 눌렀는지 검사
    }

    public override void Manager_Physics_Update()
    {
        base.Manager_Physics_Update();
    }
    public override void Manager_Exit()
    {
        base.Manager_Exit();
    }
}
