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
        player_Physics.Add_Max_Speed(100f);
    }
    public override void Manager_Update()
    {
        base.Manager_Update();
        Vector2 dir = finger_first_pos - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = Vector2.ClampMagnitude(dir, item_info.max_magnitude);
        Debug.DrawLine((Vector2)my_start_item.transform.position, (Vector2)my_start_item.transform.position - dir);

        player.transform.position = (Vector2)my_start_item.transform.position + new Vector2(0, 2f) - dir;
    }
    public override void Manager_Start()
    {
        base.Manager_Start();
    }
    public override void Manager_Exit()
    {
        base.Manager_Exit();
    }

    public override void testin(Vector2 vec)
    {
        base.testin(vec);
        finger_first_pos = vec;
    }

    public override void testout(Vector2 vec)
    {
        base.testout(vec);

        finger_last_pos = vec;
        Vector2 dir = finger_first_pos - finger_last_pos;

        if(dir.magnitude > item_info.max_magnitude)
            player_Physics.Add_Force(item_info.max_magnitude * item_info.speed * dir.normalized);
        else
            player_Physics.Add_Force(dir.magnitude * item_info.speed * dir.normalized);

        base.Manager_Exit();

    }


}
