using System;
using System.Security.Cryptography;
using TreeEditor;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class Parallax_Background_Pin : MonoBehaviour, IBackground
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

    [Header("in game values")]
    private Camera _camera;
    private Player _player;
    private Sprite _background_sprite;

    [Header("positioning values")]
    private Vector3 _Anker_Pos;
    private float _parallax_scale;
    private float _background_size_x;
    private float _background_size_y;



    private void Start()
    {
        Initialize(test_cam, test_sprite, 1.5f, 1.5f, test_parallax_scale);
        _Anker_Pos = transform.position;
    }

    public void Initialize(Camera camera, Sprite background_sprite, float scale_x, float scale_y, float parallax_scale)
    {
        _camera = camera;
        _background_sprite = background_sprite;

        float background_size_x = background_sprite.bounds.size.x * scale_x;
        float background_size_y = background_sprite.bounds.size.y * scale_y;

        _background_size_x = background_size_x;
        _background_size_y = background_size_y;

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
        Parallax_Scrolling();
        //패럴렉스 
    }

    public void Physics_Update()
    {

    }

    public void OnExit()
    {

    }

    private void Parallax_Scrolling()
    {
        Vector3 scrolling_pos = _camera.transform.position * _parallax_scale;
        Vector3 distance = _camera.transform.position - transform.position;

        Move_Pos(_Anker_Pos + scrolling_pos);


        if (Mathf.Abs(distance.x) > _background_size_x)
        {
            _Anker_Pos.x += Mathf.Sign(distance.x) * _background_size_x;
        }
        if (Mathf.Abs(distance.y) > _background_size_y)
        {
            _Anker_Pos.y += Mathf.Sign(distance.y) * _background_size_y;
        }

    }

    private void Move_Pos(Vector3 pos)
    {
        transform.position = pos;
    }

    // 레벨 바꾸는건 어디서??..

}
