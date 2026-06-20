using UnityEngine;

public abstract class Start_item_Active : ScriptableObject, Iitem_Active_interface
{
    protected Start_Item_Information item_info;
    protected GameObject player;
    protected Start_Item my_start_item;
    protected Player_Physics player_Physics;

    virtual public void Initialize(Start_Item_Information info, Start_Item item)
    {
        this.item_info = info;
        player = GameObject.FindGameObjectWithTag("Player");
        player_Physics = player.GetComponent<Player_Physics>();
        my_start_item = item;
        player_Physics.isStart = false;
    }


    virtual public void Manager_Physics_Update()
    {

    }
    virtual public void Manager_Update()
    {

    }
    virtual public void Manager_Start()
    {
        Start_Update();
        player_Physics.Manager_Start();
        //GameManager.GameStart(false);
        player_Physics.isStart = false;
    }
    virtual public void Manager_Exit()
    {
        Stop_Update();
        GameManager.GameStart(true);
        //뭔가 수정이 필요함 GameStart 함수를 직접 관리하면 구조가 복잡해짐
        player_Physics.isStart = true;
    }

    virtual public void testin(Vector2 vec) { }
    virtual public void testout(Vector2 vec) { }

    protected void Start_Update()
    {
        Start_item_Manager.onPhysicsUpdateInvokeDelegate += Manager_Physics_Update;//분리되어있어야함
        Start_item_Manager.onUpdateInvokeDelegate += Manager_Update;
    }

    protected void Stop_Update()
    {
        Start_item_Manager.onPhysicsUpdateInvokeDelegate -= Manager_Physics_Update;
        Start_item_Manager.onUpdateInvokeDelegate -= Manager_Update;
    }


}
