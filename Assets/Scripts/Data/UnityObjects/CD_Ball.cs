using Controllers.Ball;
using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Ball", menuName = "DunkHit/CD_Ball", order = 0)]
    public class CD_Ball : ScriptableObject
    {
        public BallMovementData BallMovementData;
    }
}