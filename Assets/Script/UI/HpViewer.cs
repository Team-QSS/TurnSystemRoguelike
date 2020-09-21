using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpViewer : MonoBehaviour
{
    public Image[] Lifes; // 1당 반칸
    public const int MaxLifeCount = 5;

    public void ChangeHp()
    {
        int hp = Player.Instance.Hp;

        foreach (var life in Lifes)
        {
            life.fillAmount = hp >= 2 ? 1 : hp == 1 ? 0.5f : 0;
            hp -= 2;
        }
    }
    
}
