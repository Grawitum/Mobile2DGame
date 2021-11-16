using Game.Car;
using Game.Boat;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tool;
using Services.Analytics;

namespace Game
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, SelectCar carModel,SelectInputController inputController)
        {
            profilePlayer.ServicesSingleton.GetAnalyticsManager().SendGameStarted();

            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            
            var inputGameKeyController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar,inputController);
            AddController(inputGameKeyController);
                

            //var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            //AddController(inputGameController);

            switch (carModel)
            {
                case SelectCar.Car:
                    var carController = new CarController();
                    AddController(carController);
                    
                    break;
                case SelectCar.Boat:
                    var boarController = new BoatController();
                    AddController(boarController);
                    break;
                default:
                    break;
            }
            //var carController = new CarController();
            //AddController(carController);
        }
    }
}
