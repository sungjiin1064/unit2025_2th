using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

// 이벤트를 총괄적으로 관리하는 특별한 클래스
// Generic Coding(T) 어떠한 클래스도 올 수 있는데
//  where을 사용해서 이 클래스가 IEvent를 상속한 경우만 <> 안에 들어올 수 있다.
public class Bus<T> where T : IEvent   // IEvent를 상속시킨 T만 Bus로 사용할 수 있다.
{
    public delegate void Event(T evt);
    public static event Event OnEvent;
    public static void Raise (T evt) => OnEvent?.Invoke (evt);
}
public interface IEvent 
{

}
