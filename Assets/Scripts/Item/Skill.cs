using System.Net;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public ItemActive SkillActive;
    public Item_Information Skill_Info;
    bool isClicked = false;


    //Å×½ºÆ®--
    private void Awake()
    {
        SkillActive.Initialize(Skill_Info);
    }
    //-----------

    public void OnClick()
    {
        SkillActive.Manager_Start();
    }

    public void OnEnd()
    {
        SkillActive.Manager_Exit();
    }






}
