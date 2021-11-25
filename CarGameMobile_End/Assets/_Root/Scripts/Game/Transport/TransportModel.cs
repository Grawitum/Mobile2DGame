using Features.Shed.Upgrade;

namespace Game.Transport
{
    internal class TransportModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;

        public readonly TransportType Type;

        public float Speed { get; set; }

        public float JumpHeight { get; set; }

        public TransportModel(TransportConfig transportConfig)
        {
            _defaultSpeed = transportConfig.Speed;
            Speed = transportConfig.Speed;
            _defaultJumpHeight = transportConfig.JumpHeight;
             JumpHeight = transportConfig.JumpHeight;

            Type = transportConfig.TransportType;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpHeight = _defaultJumpHeight;
        }       
    }
}
