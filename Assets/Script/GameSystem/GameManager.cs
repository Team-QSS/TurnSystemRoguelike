using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<Enemy> Enemies { get; private set; }

    private void Awake()
    {
        
    }
    
    private void SetMap()
    {
        // TODO 맵 생성 함수 호출과 몬스터 받아오고 상자배치
    }

    public int[] GetIsWithinAttackRanges(byte rotation, int[] range)
    {
        bool[] rotationFlag =
        {
            (rotation & (byte)Rotation.Up) > 0, 
            (rotation & (byte)Rotation.Right) > 0,
            (rotation & (byte)Rotation.Down) > 0,
            (rotation & (byte)Rotation.Left) > 0
        };
        foreach (Enemy enemy in Enemies)
        {
            enemy._transform.X;
            enemy._transform.Y;
        }
        
        return null;
    }
    
    public int[] GetIsWithinSkillRanges(byte[] range)
    {
        return null;
    }
    
}
