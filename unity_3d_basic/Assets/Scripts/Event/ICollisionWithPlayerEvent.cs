using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollisionWithPlayerEvent : IEvent
{
    public NPC NPC;

    public ICollisionWithPlayerEvent(NPC nPC)
    {
        NPC = nPC;
    }

    public ICollisionWithPlayerEvent()
    {

    }
}
