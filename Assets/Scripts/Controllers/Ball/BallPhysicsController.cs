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
            GetReferences();
        }

        private void GetReferences()
        {
            _manager = GetComponent<BallManager>();
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Border"))
            {
                SetPosition(other);
            }

            if (other.CompareTag("Ground"))
            {
                UISignals.Instance.onCheckClickable?.Invoke();
            }
            
            if (other.CompareTag("TopSideHoop"))
            {
                ScoreSignals.Instance.onScoreIncreaseable?.Invoke();
            }

            if (other.CompareTag("InSideHoop"))
            {
                _manager.SetBallDirection();
                ScoreSignals.Instance.onGainScore?.Invoke();
                CoreGameSignals.Instance.onBasket?.Invoke();
            }
            
            if (other.CompareTag("BottomSideHoop"))
            {
                ScoreSignals.Instance.onScoreGainBlocked?.Invoke();
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