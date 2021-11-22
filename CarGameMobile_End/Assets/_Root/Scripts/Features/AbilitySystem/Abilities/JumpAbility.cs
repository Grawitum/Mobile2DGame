using System;
using UnityEngine;
using JetBrains.Annotations;

namespace Features.AbilitySystem.Abilities
{
    internal class JumpAbility : IAbility
    {
        private readonly AbilityItemConfig _config;
        public JumpAbility([NotNull] AbilityItemConfig config) =>
            _config = config ?? throw new ArgumentNullException(nameof(config));

        public void Apply(IAbilityActivator activator)
        {
                var viewGameObjectRigidbody2D = activator.ViewGameObject.GetComponent<Rigidbody2D>();
                viewGameObjectRigidbody2D.AddForce(Vector2.up * _config.Value);
        }
    }
}
