using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image cool_time_image;
    [SerializeField] Image Item_Skill_image;
    public Item testitem;
    Item Item;
    Button button;
    float cooltime = 0f;
    float timer = 0f;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.enabled = false;
    }

    private void Start() // 아이템이 없다고 가정
    {
        cool_time_image.fillAmount = 0;
        Initialize_Item(testitem);
        if(Item == null) return;

        //TODO 사진 = 기본 사진으로 설정
        //TODO 버튼 끄기;
    }

    public void Initialize_Item(Item _Item)
    {
        Item = _Item;
        button.enabled = true;
        Debug.Log(Item.Item_Info.item_sprite);
        Item_Skill_image.sprite = Item.Item_Info.item_sprite;
        cooltime = Item.Item_Info.cooltime;
        //TODO 버튼 키기
        //TODO 사진 Item의 사진으로 install
        //TODO 쿨타임 세팅
        
    }

    public void On_Click()
    {
        Item.OnClick();
    }

    public void Set_CoolTime(float _coolTime)
    {
        cooltime = _coolTime;
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

            cool_time_image.fillAmount = timer / cooltime;

            if(timer >= cooltime)
            {
                button.enabled = true;

                cooltime = 0f;
                break;
            }

            yield return null;
        }
    }



}
