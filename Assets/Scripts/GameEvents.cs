using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void RooIsDead();
    public static event RooIsDead Died;

    public void RooDying()
    {
        Died();
    }
}
