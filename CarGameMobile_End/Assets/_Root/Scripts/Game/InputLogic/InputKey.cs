using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputKey : BaseInputView
    {
        [SerializeField] private float _inputMultiplier = 0.05f;

        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            if (Input.GetAxis(AxisManager.HORIZONTAL) > 0)
                OnRightMove(Input.GetAxis(AxisManager.HORIZONTAL)*_inputMultiplier);
            else
                OnLeftMove(-Input.GetAxis(AxisManager.HORIZONTAL)*_inputMultiplier);
        }
    }
}
