using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BSLibrary;

public class GameManager : MonoSingleton<GameManager>
{
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

    private void Awake()
    {
        
    }
    
    private void SetMap()
    {
        // TODO 맵 생성 함수 호출과 몬스터 받아오고 상자배치
    }
    
    public bool GetIsWithInAttackRangeAToB(Rotation rotation, (int, int) range, Entity.EntityTransform a, Entity.EntityTransform b)
    {
        /*
         * switch-case
         * up (a.x - range.x / 2 <= b.x <= a.x + range.x / 2) && (a.y < b.y <= a.y - range.y)
         * right (a.x < b.x <= a.x + range.y) && (a.y - range.x / 2 <= b.y <= a.y + range.x / 2)
         * down (a.x - range.x / 2 <= b.x <= a.x + range.x / 2) && (a.y > b.y >= a.y + range.y)
         * left (a.x > b.x >= a.x - range.y) && (a.y - range.x / 2 <= b.y <= a.y + range.x / 2)
         */
        
        switch (rotation)
        {
            case Rotation.Up: return (a.x - range.Item1 / 2 <= b.x && b.x <= a.x + range.Item1 / 2) && (a.y < b.y && b.y <= a.y - range.Item2);
            case Rotation.Right: return (a.x < b.x && b.x <= a.x + range.Item2) && (a.y - range.Item1 / 2 <= b.y && b.y <= a.y + range.Item1 / 2);
            case Rotation.Down: return (a.x - range.Item1 / 2 <= b.x && b.x <= a.x + range.Item1 / 2) && (a.y > b.y && b.y >= a.y + range.Item2);
            case Rotation.Left: return (a.x > b.x && b.x >= a.x - range.Item2) && (a.y - range.Item1 / 2 <= b.y && b.y <= a.y + range.Item1 / 2);;
            default: return false;
        }
    }

    public bool GetIsWithinSkillRangeAToB(byte[] range, Entity.EntityTransform a, Entity.EntityTransform b)
    {
        /*
         * range
         * 7 * 7
         * bit mask i == 1 => 1 / i == 2 => 2 ... / i == 3 => 4   | 1 2 4 8 16 32 64 (128 is IsHeal)
         */

        (int, int) relativePositionOfB = (b.x - a.x, b.y - a.y);
        byte lineRange = range[range.Length / 2 + relativePositionOfB.Item1];
        byte bYPos = (byte)(0x01 << (range.Length / 2 + relativePositionOfB.Item2));
        
        if ((lineRange & bYPos) == bYPos && bYPos < 128) { return true; }
        else { return false; }
    }


    public Enemy[] GetEnemiesWithinAttackRanges(byte rotation, (int,int) range)
    {
        return Enemies.Where(enemy => 
            GetIsWithInAttackRangeAToB(
                rotation: (Rotation)rotation, 
                range: range, 
                a: Player.Instance._Transform, 
                b: enemy._Transform)).ToArray();
    }

     public Enemy[] GetEnemiesWithinSkillRanges(byte[] range)
     {
        if (range.Length > 7) throw new ArgumentException();

        return Enemies.Where(enemy =>
            GetIsWithinSkillRangeAToB(
                range: range, 
                a: Player.Instance._Transform, 
                b: enemy._Transform)).ToArray();
     }
}
