using Game.Car;
using Services;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly ServicesSingleton ServicesSingleton;


        public ProfilePlayer(float speedCar, GameState initialState,ServicesSingleton servicesSingleton) : this(speedCar)
        {
            CurrentState.Value = initialState;
            ServicesSingleton = servicesSingleton;
        }

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar);
        }
    }
}
