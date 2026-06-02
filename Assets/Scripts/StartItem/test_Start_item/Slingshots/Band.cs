using UnityEngine;

public class Band : MonoBehaviour
{
    Start_Item_Information ItemInfo;
    BenchMark benchmark = null;
    Player_Physics target;
    Vector2 dir;
    bool isExit = false;

    public void Setting(Start_Item_Information _ItemInfo, BenchMark _benchmark, Player_Physics _target)
    {
        ItemInfo = _ItemInfo;
        benchmark = _benchmark;
        target = _target;
    }

    public void Exit(bool _isExit)
    {
        isExit = _isExit;
    }

    void Update()
    {
        dir = benchmark.transform.position - transform.position;
        if(isExit)
        {
            if (dir.magnitude <= 0.5f) return;

            transform.position = (Vector2)transform.position + dir.normalized * 10f * Time.deltaTime;

        }
        else
        {
            transform.position = (Vector2)target.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }




    }



}
