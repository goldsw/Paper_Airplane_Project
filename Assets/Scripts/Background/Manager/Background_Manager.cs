using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Background_Manager : MonoBehaviour
{
    private struct background_info//2차원 맵... 청크??
    {
        public 
    }

    [SerializeField] private Parallax_Background backgrounds
    private Player_Physics _player_physics;
    private Camera _main_camera;

    public void Initialize(Player_Physics player_physics, Camera camera)
    {
        _player_physics = player_physics;
        _main_camera = camera;
    }

    private void Update()
    {
        //TODO: 여기에는 고도 확인 시스템
        
    }

    private 



}
