using Receptors;
using UnityEngine;

namespace Manas
{
    public class ManaCollisionHandler : MonoBehaviour
    {
        [SerializeField] private ManaTypes manaType;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var receptor = other.GetComponent<Receptor>();
            if (receptor)
            {
                switch (manaType)
                {
                    case ManaTypes.Fire:
                        receptor.AddMana(new FireMana(receptor));
                        break;
                    case ManaTypes.Air:
                        receptor.AddMana(new AirMana(receptor));
                        break;
                    case ManaTypes.Earth:
                        receptor.AddMana(new EarthMana(receptor));
                        break;
                    case ManaTypes.Water:
                        receptor.AddMana(new WaterMana(receptor));
                        break;
                }
            }
            
            Destroy(gameObject);
        }
    }
}
