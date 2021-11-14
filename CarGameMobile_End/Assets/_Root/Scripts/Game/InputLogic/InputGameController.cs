using Game.Car;
using Tool;
using UnityEngine;
using Profile;

namespace Game.InputLogic
{
    internal class InputGameController : BaseController
    {
        private readonly ResourcePath _resourcePath;
        private BaseInputView _view;


        public InputGameController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            CarModel car,
            SelectInputController inputController
            )
        {
            Debug.Log(inputController);
            switch (inputController)
            {
                case SelectInputController.Acceleration:
                    _resourcePath = new ResourcePath("Prefabs/EndlessMove");
                    break;
                case SelectInputController.Key:
                    _resourcePath = new ResourcePath("Prefabs/KeyboardMove");
                    break;
                default:
                    break;
            }
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private BaseInputView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            BaseInputView view = objectView.GetComponent<BaseInputView>();
            return view;
        }
    }
}
