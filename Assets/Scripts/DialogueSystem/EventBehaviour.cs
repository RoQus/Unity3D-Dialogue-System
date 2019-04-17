using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventBehaviour : ScriptableObject
{
    public void TestEvent()
    {
        Debug.Log("Test Event successful");
    }
    
    public void TestEvent02()
    {
        Debug.Log("Test Event 2 successful");
    }
}
