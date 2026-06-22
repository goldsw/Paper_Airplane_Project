using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

interface IBackground
{
    void Initialize(Camera camera, Sprite sprite, Vector2 maxVelocity);


    void OnEnter();


    void Frame_Update();


    void Physics_Update();


    void OnExit();

    bool SetStride(float bg_width_size, float bg_height_size);


}
