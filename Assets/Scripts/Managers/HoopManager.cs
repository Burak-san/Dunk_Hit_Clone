using System.Threading.Tasks;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class HoopManager : MonoBehaviour
    {
        [SerializeField] private GameObject LeftHoop;
        [SerializeField] private GameObject RightHoop;

        private BallMovementData _ballMovementData;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _ballMovementData = GetBallMovementData();
        }
        
        private BallMovementData GetBallMovementData() => Resources.Load<CD_Ball>("Data/CD_Ball").BallMovementData;

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onBasket += OnBasket;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onBasket -= OnBasket;
        }
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void OnPlay()
        {
            
        }
        
        private void OnBasket()
        {
            if (_ballMovementData.direction == 1)
            {
                RightHoop.SetActive(true);
                RandomYPos();
                LeftHoop.SetActive(false);
            }
            else if (_ballMovementData.direction == -1)
            {
                LeftHoop.SetActive(true);
                RandomYPos();
                RightHoop.SetActive(false);
            }
        }

        private void RandomYPos()
        {
            RightHoop.transform.position = new Vector3(3.5f, Random.Range(-2, 2));
            LeftHoop.transform.position = new Vector3(-3.5f, Random.Range(-2, 2));
        }

        private void OnReset()
        {
        }
    }
}