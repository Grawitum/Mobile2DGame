using UnityEngine;

namespace Game.Transport
{
    [CreateAssetMenu(fileName = nameof(TransportConfig), menuName = "Configs/" + nameof(TransportConfig))]
    internal class TransportConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }
        [field: SerializeField] public TransportType TransportType { get; private set; }
    }
}
