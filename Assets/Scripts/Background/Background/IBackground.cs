using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

interface IBackground
{
    void Initialize(Camera camera, Sprite background_sprite, float scale_x, float scale_y, float parallax_scale);



    void OnEnter();


    void Frame_Update();


    void Physics_Update();


    void OnExit();


}
