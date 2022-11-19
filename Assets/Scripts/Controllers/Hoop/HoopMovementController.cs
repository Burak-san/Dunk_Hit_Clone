using System;
using DG.Tweening;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.Hoop
{
    public class HoopMovementController : MonoBehaviour
    {
        [SerializeField]private bool _rightHoopIn = true;
        [SerializeField]private bool _leftHoopIn = false;
        public void Basket()
        {
            float yPos = Random.Range(-3, 3);
            
            if (_rightHoopIn == true && _leftHoopIn == false)
            {
                if (transform.position.x<0)
                {
                    transform.DOMoveX(transform.position.x + 3, 1, false).SetEase(Ease.InOutSine);
                    transform.DOMoveY(yPos, 0.1f, false);
                }
                else
                {
                    transform.DOMoveX(transform.position.x + 3, 1, false).SetEase(Ease.InOutSine);
                    transform.DOMoveY(yPos, 0.1f, false);
                }

                _rightHoopIn = false;
                _leftHoopIn = true;
            }

            if (_leftHoopIn == true && _rightHoopIn == false)
            {
                if (transform.position.x<0)
                {
                    transform.DOMoveX(transform.position.x - 3, 1, false).SetEase(Ease.InOutSine);
                    transform.DOMoveY(yPos, 0.1f, false);
                }
                else
                {
                    transform.DOMoveX(transform.position.x - 3, 1, false).SetEase(Ease.InOutSine);
                    transform.DOMoveY(yPos, 0.1f, false);
                }
            }
        }
    }
}