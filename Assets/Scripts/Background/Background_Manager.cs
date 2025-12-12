using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;

public class Background_Manager : MonoBehaviour
{
    [Header("Range of zone size")]
    public Vector2 background_zone_size;
    private float range_x;
    private float range_y;

    [Header("Test")]
    public GameObject player;


    float negative_range_in_x_zone;
    float positive_range_in_x_zone;
    float negative_range_in_y_zone;
    float positive_range_in_y_zone;
    //Func<float, float, float> Get_Correction = (axis, range) =>
    //{

    //};




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position;

        //TODO : 플레이어 포지션 지우고 필요할때 더해서 연산
        range_x = background_zone_size.x / 2;        
        range_y = background_zone_size.y / 2;

        negative_range_in_x_zone = transform.position.x + range_x - background_zone_size.x;
        positive_range_in_x_zone = transform.position.x + range_x;
        negative_range_in_y_zone = transform.position.y + range_y - background_zone_size.y;
        positive_range_in_y_zone = transform.position.y + range_y;
    }

    public void Check_out_range(Transform background_transform)
    {
        float x = background_transform.position.x;
        float y = background_transform.position.y;

        Debug.Log(range_x);
        Debug.Log(negative_range_in_x_zone);
        
        Debug.DrawLine(new Vector3(negative_range_in_x_zone, 0), new Vector3(positive_range_in_x_zone, 0));
        Debug.DrawLine(new Vector3(0, negative_range_in_y_zone), new Vector3(0, positive_range_in_y_zone));

        if (x < negative_range_in_x_zone || x > positive_range_in_x_zone)
        {
            float correction = Get_Correction(x - transform.position.x, range_x);
            Debug.Log("x : " + correction);

            background_transform.position = new Vector3(transform.position.x + correction, background_transform.position.y);
        }

        if (y < negative_range_in_y_zone || y > positive_range_in_y_zone)
        {
            float correction = Get_Correction(y - transform.position.y, range_y);
            Debug.Log("y : " + correction);

            background_transform.position = new Vector3(background_transform.position.x, transform.position.y + correction);
        }


    }
    float Get_Correction(float axis_diff, float range)
    {
        float correction = axis_diff;
        correction += (correction / Mathf.Abs(correction) * -range) * 2;
        return correction;
    }

    private void OnDrawGizmos()
    {       
        Gizmos.color = Color.red;



        //Draw Range
        Gizmos.DrawLine(new Vector2(transform.position.x + range_x, transform.position.y + range_y), new Vector2(transform.position.x + range_x, transform.position.y + range_y - background_zone_size.y));

        Gizmos.DrawLine(new Vector2(transform.position.x + range_x, transform.position.y + range_y - background_zone_size.y), new Vector2(transform.position.x+ range_x - background_zone_size.x, transform.position.y + range_y - background_zone_size.y));

        Gizmos.DrawLine(new Vector2(transform.position.x + range_x - background_zone_size.x, transform.position.y + range_y - background_zone_size.y), new Vector2(transform.position.x + range_x - background_zone_size.x, transform.position.y + range_y));

        Gizmos.DrawLine(new Vector2(transform.position.x + range_x - background_zone_size.x, transform.position.y + range_y), new Vector2(transform.position.x + range_x, transform.position.y + range_y));
    }
}
