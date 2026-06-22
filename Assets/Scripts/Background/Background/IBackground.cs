using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

interface IBackground
{
    void Initialize(Camera camera, Sprite sprite, float parallax_scale);


    void OnEnter();


    void Frame_Update();


    void Physics_Update();


    void OnExit();


}
