using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyExample
{   
    private int hp;
    private int atk;

    public int HP { get;set; } // 프로포티 사용 형태 1.
    public int ATK { get;set; }
    public int HP2 { get { return hp; } set { hp = value; } }

    public int DEF { get;set; } // 외부에서 값을 변경하지 마세요.

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
     * 프로퍼티
     * 사용법 : 변수선언 public (타입)(변수이름) 첫글자를 대문자로 작성하는 것이 이름 규칙입니다.
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
