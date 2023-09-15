using UnityEngine;

namespace Game.WeaponScripts
{
    internal class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField, Min(1)] private int _maxCountCartridge = 1;
        [SerializeField, Min(0)] private int _countCartridge = 0;

        public int CountCartrige
        {
            get => _countCartridge;

            set
            {
                if(_countCartridge != value)
                {
                    if(value < 0)
                    {
                        _countCartridge = 0;

                        //Add inventory where ammo will be taken from
                        Debug.LogWarning("Add inventory where ammo will be taken from");

                        Recharge(_maxCountCartridge);
                    }
                    else if (value > _maxCountCartridge)
                    {
                        _countCartridge = _maxCountCartridge;
                    }
                    else
                    {
                        _countCartridge = value;
                    }
                }
            }
        }

        private void Start()
        {
            if(_countCartridge > _maxCountCartridge)
            {
                throw new System.Exception("The maximum number of cartridges is less than loaded.");
            }
        }

        public void Shot()
        {
            CountCartrige--;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10 * hit.distance, Color.green, 1f);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red, 1f);
            }
        }

        private void Recharge(int countCartridge)
        {
            CountCartrige = countCartridge;
        }

    }
}
