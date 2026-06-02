using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool isGameStart = true;

    public delegate void Start_item_Manager_Invoke();
    public delegate void Item_Manager_Invoke();
    public static Start_item_Manager_Invoke Start_Item_Update_Delegate;
    public static Start_item_Manager_Invoke Start_Item_Physics_Delegate;
    public static Item_Manager_Invoke Game_Update_Delegate;
    public static Item_Manager_Invoke Game_Physics_Delegate;

    [SerializeField] SkillManager itemManager;
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
        if (isGameStart == false) return;


        Start_Item_Update_Delegate.Invoke();
        Game_Update_Delegate.Invoke();
    }
    private void FixedUpdate()
    {
        if (isGameStart == false) return;



        Start_Item_Physics_Delegate.Invoke();
        Game_Physics_Delegate.Invoke();
    }

    public static void GameStart(bool _gameStart)
    {
        isGameStart = _gameStart;
        Debug.Log(isGameStart);
    }

}
