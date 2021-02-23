using System;
using System.Collections.Generic;
using Characters;
using Manas;
using Receptors;
using UnityEngine;

namespace Casters
{
    /// <summary>
    /// A Caster is a entity who can use absorbed mana to cast skills.
    /// </summary>
    [RequireComponent(typeof(Receptor))]
    public class Caster : MonoBehaviour
    {
        private Receptor _receptor;

        private void Start()
        {
            _receptor = GetComponent<Receptor>();
        }
    }
}
