using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool isGameStart = false;

    public delegate void Start_item_Manager_Invoke();
    public delegate void Item_Manager_Invoke();
    public static Start_item_Manager_Invoke Start_Item_Update_Delegate;
    public static Start_item_Manager_Invoke Start_Item_Physics_Delegate;
    public static Item_Manager_Invoke Game_Update_Delegate;
    public static Item_Manager_Invoke Game_Physics_Delegate;



    [SerializeField] ItemManager itemManager;
    [SerializeField] Start_item_Manager start_item_manager;
    private void Start()
    {
        Start_Item_Update_Delegate += () => { };
        Start_Item_Physics_Delegate += () => { };
        Game_Update_Delegate += () => { };
        Game_Physics_Delegate += () => { };
    }
    void Update()
    {
        Start_Item_Update_Delegate.Invoke();

        if (isGameStart == false) return;

        Game_Update_Delegate.Invoke();
    }
    private void FixedUpdate()
    {
        Start_Item_Physics_Delegate.Invoke();

        if (isGameStart == false) return;

        Game_Physics_Delegate.Invoke();
    }

    public static void GameStart(bool _gameStart)
    {
        isGameStart = _gameStart;
    }

}
