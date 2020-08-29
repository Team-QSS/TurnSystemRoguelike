using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpViewer : MonoBehaviour
{
    public Image[] Lifes; // 1당 반칸
    public const int MaxLifeCount = 5;

    private Sprite _heart;
    private Sprite _halfHeart;
    private Sprite _emptyHeart;
    
    public void ChangeHp()
    {
        int hp = Player.Instance.Hp;

        foreach (var life in Lifes)
        {
            life.sprite = hp >= 2 ? _heart : hp == 1 ? _halfHeart : _emptyHeart;
            hp -= 2;
        }
    }

    private void Awake()
    {
        _heart = ResourceExtension.LoadHeartSprite("Heart");
        _halfHeart = ResourceExtension.LoadHeartSprite("HalfHeart");
        _emptyHeart = ResourceExtension.LoadHeartSprite("EmptyHeart");
    }
}
