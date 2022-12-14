using System.Threading.Tasks;
using Data.UnityObjects;
using Data.ValueObjects;
using DG.Tweening;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class HoopManager : MonoBehaviour
    {
        [SerializeField] private GameObject leftHoop;
        [SerializeField] private GameObject rightHoop;

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
        
        private async void OnBasket()
        {
            if (_ballMovementData.direction == 1)
            {
                rightHoop.SetActive(true);
                rightHoop.transform.position = new Vector3(6.5f, Random.Range(-2, 3));
                rightHoop.transform.DOMoveX(3.5f, 0.75f, false).SetEase(Ease.OutBounce);
                //RightHoop.transform.DORotate(new Vector3(0, 0, 180), 1, RotateMode.LocalAxisAdd);
                await Task.Delay(200);
                leftHoop.transform.DOMoveX(leftHoop.transform.position.x - 3, 0.75f, false).SetEase(Ease.OutBounce);
                await Task.Delay(1001);
                leftHoop.SetActive(false);
                
            }
            else if (_ballMovementData.direction == -1)
            {
                leftHoop.SetActive(true);
                leftHoop.transform.position = new Vector3(-6.5f, Random.Range(-2, 3));
                leftHoop.transform.DOMoveX(-3.5f, 0.75f, false).SetEase(Ease.OutBounce);
                //LeftHoop.transform.DORotate(new Vector3(0, 0, -180), 1, RotateMode.LocalAxisAdd);
                await Task.Delay(200);
                rightHoop.transform.DOMoveX(rightHoop.transform.position.x + 3, 0.75f, false).SetEase(Ease.OutBounce);
                await Task.Delay(1001);
                rightHoop.SetActive(false);
            }
        }

        private void OnReset()
        {
        }
    }
}