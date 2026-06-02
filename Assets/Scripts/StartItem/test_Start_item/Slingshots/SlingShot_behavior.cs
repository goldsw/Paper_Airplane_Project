using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Start_Item/SlingShot_Behavior", order = 1)]

public class SlingShot_behavior : Start_item_Active
{
    BenchMark benchmark;
    Band band;
    Vector2 finger_first_pos;
    Vector2 finger_last_pos;

    public override void Initialize(Start_Item_Information info, Start_Item item)
    {
        base.Initialize(info, item);
        benchmark = item.transform.GetComponentInChildren<BenchMark>(); 
        band = item.transform.GetComponentInChildren<Band>();
        Debug.Log(benchmark);
        band.Setting(item_info, benchmark, player_Physics);
    }

    public override void Manager_Physics_Update()
    {
        base.Manager_Physics_Update();
        player_Physics.Add_Max_Speed(100f);
    }
    public override void Manager_Update()
    {
        base.Manager_Update();
        Vector2 mousepos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = finger_first_pos - mousepos;
        dir = Vector2.ClampMagnitude(dir, item_info.max_magnitude);

        Debug.DrawLine((Vector2)benchmark.transform.position, (Vector2)benchmark.transform.position - dir);


        band.transform.position = (Vector2)benchmark.transform.position - dir;
        player.transform.position = new Vector3(benchmark.transform.position.x - dir.x, benchmark.transform.position.y - dir.y, player.transform.position.z);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0, 0, angle);
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
        band.Exit(false);
    }

    public override void testout(Vector2 vec)
    {
        base.testout(vec);

        band.Exit(true);

        finger_last_pos = vec;
        Vector2 dir = finger_first_pos - finger_last_pos;

        float dir_mag = dir.magnitude;
        float max_mag = item_info.max_magnitude;
        if (dir_mag > max_mag)
            player_Physics.Add_Force(item_info.max_magnitude * item_info.speed * dir.normalized);
        else
            player_Physics.Add_Force(dir.magnitude * item_info.speed * dir.normalized);

        base.Manager_Exit();

    }

}
