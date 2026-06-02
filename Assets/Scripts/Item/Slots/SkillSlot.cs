using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] Image cool_time_image;
    [SerializeField] Image current_Skill_image;
    public Skill testSkill;
    Skill current_skill;
    Button button;
    float current_Cooltime = 0f;
    float timer = 0f;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.enabled = false;
    }

    private void Start() // 아이템이 없다고 가정
    {
        cool_time_image.fillAmount = 0;
        Initialize_Item(testSkill);
        if(current_skill == null) return;

        //TODO 사진 = 기본 사진으로 설정
        //TODO 버튼 끄기;
    }

    public void Initialize_Item(Skill _skill)
    {
        current_skill = _skill;

        Sprite _skill_sprite = current_skill.Skill_Info.item_sprite;
        float _skill_cooltime = current_skill.Skill_Info.cooltime;

        //TODO 사진 Skill_Info의 사진으로 install
        current_Skill_image.sprite = _skill_sprite;
        //TODO 쿨타임 세팅
        current_Cooltime = _skill_cooltime;
        //TODO 버튼 키기
        button.enabled = true;
        
    }

    public void On_Click()
    {
        current_skill.OnClick();
        Let_CoolTime();
    }

    public void Set_CoolTime(float _coolTime)
    {
        current_Cooltime = _coolTime;
    }

    public void Let_CoolTime()
    {
        StartCoroutine(CoolTime());
        //코루틴
    }

    IEnumerator CoolTime()
    {
        button.enabled = false;

        while(true)
        {
            timer += Time.deltaTime;

            cool_time_image.fillAmount = 1 - timer / current_Cooltime;

            if(timer >= current_Cooltime)
            {
                button.enabled = true;
                break;
            }
            yield return null;
        }

        timer = 0f;
        yield break;
    }
}