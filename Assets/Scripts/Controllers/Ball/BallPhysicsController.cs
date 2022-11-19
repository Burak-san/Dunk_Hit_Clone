using Managers;
using Signals;
using UnityEngine;

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
            
            if (other.CompareTag("TopSideHoop"))
            {
                ScoreSignals.Instance.onScoreIncreaseable?.Invoke();
            }

            if (other.CompareTag("InSideHoop"))
            {
                ScoreSignals.Instance.onGainScore?.Invoke();
                //Debug.Log("InSideHook");
            }
            
            if (other.CompareTag("BottomSideHoop"))
            {
                ScoreSignals.Instance.onScoreGainBlocked?.Invoke();
            }

            if (other.CompareTag("HoopBorder"))
            {
                _manager.SetBallDirection();
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