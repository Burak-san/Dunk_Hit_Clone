using System;
using Data.ValueObjects;
using Managers;
using Signals;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Controllers.Ball
{
    public class BallPhysicsController : MonoBehaviour
    {
        private BallManager _manager;

        private void Awake()
        {
            _manager = GetComponent<BallManager>();
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Border"))
            {
                SetPosition(other);
            }
            
            if (other.CompareTag("TopSideHook"))
            {
                ScoreSignals.Instance.onScoreIncreaseable?.Invoke();
                //Debug.Log("TopSideHook");
            }

            if (other.CompareTag("InSideHook"))
            {
                ScoreSignals.Instance.onGainScore?.Invoke();
                //Debug.Log("InSideHook");
            }
            
            if (other.CompareTag("BottomSideHook"))
            {
                ScoreSignals.Instance.onScoreGainBlocked?.Invoke();
                //Debug.Log("BottomSideHook");
            }
        }

        public void SetPosition(Collider2D other)
        {
            if (other.transform.position.x<0)
            {
                _manager.transform.position = new Vector3(-other.transform.position.x-1, _manager.transform.position.y);
            }
            else
            {
                _manager.transform.position = new Vector3(-other.transform.position.x+1, _manager.transform.position.y);
            }
        }
    }
}