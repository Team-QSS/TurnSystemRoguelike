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

    private bool GetIsWithInAttackRange(Rotation rotation, Entity.EntityTransform player, Entity.EntityTransform enemy, (int, int) range)
    {
        /*
        * up (p.x - range.x / 2 <= enemy.x <= p.x + range.x / 2) && (p.y < enemy.y <= p.y - range.y)
        * right (p.x < enemy.x <= p.x + range.y) && (p.y - range.x / 2 <= enemy.y <= p.y + range.x / 2)
        * down (p.x - range.x / 2 <= enemy.x <= p.x + range.x / 2) && (p.y > enemy.y >= p.y + range.y)
        * left (p.x > enemy.x >= p.x - range.y) && (p.y - range.x / 2 <= enemy.y <= p.y + range.x / 2)
        */
        switch (rotation)
        {
            case Rotation.Up: return (player.x - range.Item1 / 2 <= enemy.x && enemy.x <= player.x + range.Item1 / 2) && (player.y < enemy.y && enemy.y <= player.y - range.Item2);
            case Rotation.Right: return (player.x < enemy.x && enemy.x <= player.x + range.Item2) && (player.y - range.Item1 / 2 <= enemy.y && enemy.y <= player.y + range.Item1 / 2);
            case Rotation.Down: return (player.x - range.Item1 / 2 <= enemy.x && enemy.x <= player.x + range.Item1 / 2) && (player.y > enemy.y && enemy.y >= player.y + range.Item2);
            case Rotation.Left: return (player.x > enemy.x && enemy.x >= player.x - range.Item2) && (player.y - range.Item1 / 2 <= enemy.y && enemy.y <= player.y + range.Item1 / 2);;
            default: return false;
        }
    }
    
    public Enemy[] GetEnemiesWithinAttackRanges(byte rotation, (int,int) range)
    {
        foreach (Enemy enemy in Enemies)
        {
            
        }
        
        return null;
    }
    
    public int[] GetIsWithinSkillRanges(byte[] range)
    {
        return null;
    }
    
}
