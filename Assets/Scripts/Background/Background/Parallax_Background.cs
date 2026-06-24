using System;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax_Background : MonoBehaviour, IBackground
{
    //public struct Background_Positioning_Values
    //{
    //    public float _parallax_scale;
    //    public float _next_background_x;
    //    public float _next_background_y;
    //    public float _tp_area_x_range;
    //    public float _tp_area_y_range;
    //}



    [Header("test values")]
    public Camera test_cam;
    public Sprite test_sprite;
    public float test_parallax_scale;

    public int offset_index_y;

    [Header("in game values")]
    private Camera _camera;
    private Player _player;
    private Sprite _background_sprite;

    [Header("positioning values")]
    private float _parallax_scale;
    private float _background_size_x;
    private float _background_size_y;

    private float _sum_of_background = 3;
    private float _background_zone_range_y;



    private void Start()
    {
        
        Initialize(test_cam, test_sprite, 1.5f, 1.5f, test_parallax_scale);
    }

    public void Initialize(Camera camera, Sprite background_sprite, float scale_x, float scale_y, float parallax_scale)
    {
        float background_size_x = background_sprite.bounds.size.x * scale_x;
        float background_size_y = background_sprite.bounds.size.y * scale_y;

        _background_size_x = background_size_x;
        _background_size_y = background_size_y;
        _background_zone_range_y = _background_size_y * _sum_of_background;

        _background_sprite = background_sprite;
        _camera = camera;
        //_player = GameManager.Get_Player_Ref();

        _parallax_scale = parallax_scale;


    }

    public void OnEnter()
    {
        // 허~접 내꺼
    }

    private void Update()//test Update
    {
        Frame_Update();
    }

    public void Frame_Update()
    {
        Idkthisfuncname();
        //패럴렉스 
    }

    public void Physics_Update()
    {

    }

    public void OnExit()
    {

    }


    private void Idkthisfuncname()
    {
        float cam_x_index = Mathf.Floor(_camera.transform.position.x / _background_size_x);
        //float cam_y_index = Mathf.Floor(_camera.transform.position.y / _background_size_y);

        float my_x_index = Mathf.Round(transform.position.x / _background_size_x);
        //float my_y_index = Mathf.Round(transform.position.y / _background_size_y);

        if (Mathf.Abs(cam_x_index - my_x_index) > 1)
        {
            // 하 열받네

            float sign = MathF.Sign(cam_x_index - my_x_index);
            float next_index_x = my_x_index + 3 * sign;
            
            Vector3 next_backgorund_pos = new Vector3(
                next_index_x * _background_size_x,
                0,
                0
            );

            Move_Pos(next_backgorund_pos);
        }




        //float stride = MathF.Abs(_camera.transform.position.y - transform.position.y);

        float background_tile_y = _camera.transform.position.y / _background_size_y;

        int background_tile_index_y = (int)background_tile_y;

        Move_Pos(new Vector3(transform.position.x, background_tile_index_y * _background_size_y + offset_index_y * _background_size_y));


    }

    private void Move_Pos(Vector3 pos)
    {
        transform.position = pos;
    }

}
