using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action TimerExpired;
    public static event Action BoundaryEntered;
    public static event Action TimerAdderCollected;
    public static event Action TableRepairCollected;
    public static event Action CoinRushCollected;

    public static void TriggerTimerExpired()
    {
        TimerExpired?.Invoke();
    }

    public static void TriggerBoundaryEntered()
    {
        BoundaryEntered?.Invoke();
    }

    public static void TriggerTimerAdderCollected()
    {
        TimerAdderCollected?.Invoke();
    }

    public static void TriggerTableRepairCollected()
    {
        TableRepairCollected?.Invoke();
    }

    public static void TriggerCoinRushCollected()
    {
        CoinRushCollected?.Invoke();
    }
}
