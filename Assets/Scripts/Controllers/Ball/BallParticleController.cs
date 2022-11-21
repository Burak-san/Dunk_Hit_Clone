using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Ball
{
    public class BallParticleController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> particles;
        
        public void Combo(int count)
        {
            particles[count].SetActive(true);
        }
        
        public void ExitCombo()
        {
            particles[0].SetActive(false);
            particles[1].SetActive(false);
        }
    }
}