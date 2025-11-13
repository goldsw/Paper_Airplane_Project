using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item Item;
    Button button;

    private void Start() // 아이템이 없다고 가정
    {
        if(Item == null) return;

        button = GetComponent<Button>();
        //TODO 사진 = 기본 사진으로 설정
        //TODO 버튼 끄기;
    }

    public void Initialize(Item _Item)
    {
        Item = _Item;
        //TODO 버튼 키기
        //TODO 사진 Item의 사진으로 install
        
    }

    public void On_Click()
    {
        Item.OnClick();
    }
}
