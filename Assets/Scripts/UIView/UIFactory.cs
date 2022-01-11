using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace TeamBlue_Asteroids
{
    internal class UIFactory : IUIFactory
    {
        private readonly Data _data;
        private readonly UIData _uiData;

        internal UIFactory(Data data)
        {
            _data = data;
            _uiData = _data.UIData;
        }
        
        public GameObject CreateUiElement(UiType type)
        {
            var element = Object.Instantiate(_uiData.CreateUiElement(type), _data.Canvas);
            return element;
        }
    }
}

