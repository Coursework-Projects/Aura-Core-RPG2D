using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerHandler : MonoBehaviour
{
    public void TriggerAnimationEvent()
    {
        GetComponentInParent<Player>().TriggerAnimationEvent();
    }
}
