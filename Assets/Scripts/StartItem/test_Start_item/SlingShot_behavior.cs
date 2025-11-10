using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Start_Item/Start_Item_Active/Sling_Shot", order = 1)]
public class SlingShot_behavior : Start_item_Active
{
    GameObject handle;
    Vector2 finger_first_pos;
    Vector2 finger_last_pos;
    //private void Awake()
    //{
    //    handle = Item_info.GetComponentInChildren<GameObject>();
    //}
    public override void Manager_Physics_Update()
    {
        base.Manager_Physics_Update();
    }
    public override void Manager_Update()
    {
        base.Manager_Update();
        //player.transform.position = handle.transform.position;
    }
    public override void Manager_Start()
    {
        base.Manager_Start();
        player_Physics.Add_Max_Speed(100f);
    }
    public override void Manager_Exit()
    {
        base.Manager_Exit();
    }

    public override void testin(Vector2 vec)
    {
        base.testin(vec);
        Debug.DrawLine(new Vector3(vec.x, vec.y), new Vector3(vec.x - 1, vec.y + 1), Color.red, 100f);
        finger_first_pos = vec;
    }

    public override void testout(Vector2 vec)
    {
        base.testout(vec);
        Debug.DrawLine(new Vector3(vec.x, vec.y), new Vector3(vec.x - 1, vec.y + 1), Color.blue, 100f);
        base.Manager_Exit();
        Vector2 dir = finger_first_pos - finger_last_pos;
        Debug.Log("hi");
        player_Physics.Add_Force(dir.magnitude * item_info.speed * dir.normalized);
        finger_last_pos = vec;
    }


}
