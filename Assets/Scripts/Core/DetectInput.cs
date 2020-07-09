using UnityEngine;
using Cinemachine;
using Ammunition;

namespace Core
{
    public class DetectInput : MonoBehaviour
    {
        private Camera myCamera;
        //private CinemachineImpulseSource impulse;

        private void Start()
        {
            myCamera = Camera.main;
            //impulse = GetComponent<CinemachineImpulseSource>();
        }

        private void Update()
        {
            if(!Input.GetButtonDown("Fire1")) return;
            var ray = myCamera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, Vector2.zero);
            if (!hit) return;
            var bomb = hit.collider.GetComponent<Bomb>();
            if(!bomb) return;
            hit.collider.GetComponent<Bomb>().OnTouch();
            //impulse.GenerateImpulse();
        }
    }
}