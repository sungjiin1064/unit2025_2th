using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyExample
{   
    private int hp;
    private int atk;

    public int HP { get;set; } // ������Ƽ ��� ���� 1.
    public int ATK { get;set; }
    public int HP2 { get { return hp; } set { hp = value; } }

    public int DEF { get;set; } // �ܺο��� ���� �������� ������.

    public int MaxLevel { get;private set; } // 
    public int GetHP()
    {
        if(hp <= 0)
        {
            hp = 0;
        }
        return hp;
    }
    
    public void SetHP(int _hp) { hp = _hp;}
    public int GetAtk() {  return atk; }
    public void SetAtk(int _atk) { atk = _atk;}

    /*
     * ������Ƽ
     * ���� : �������� public (Ÿ��)(�����̸�) ù���ڸ� �빮�ڷ� �ۼ��ϴ� ���� �̸� ��Ģ�Դϴ�.
     * public int HP
    */

    /// <summary>
    /// 
    /// </summary>
    public void UseThisFunction()
    {
        hp /= 2;
    }
}
public class AnotherClass
{
    PropertyExample example;
    public void Test()
    {
        example.UseThisFunction();

        example.HP = 10;
        int maxHP = example.HP;

    }
    void Start()
    {
        example = new(); // example = new PropertyExample();
        Test();
    }
}
