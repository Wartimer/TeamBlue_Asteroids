using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace TeamBlue_Asteroids
{
    internal class UIFactory : IUIFactory
    {
        private readonly UIData _uiData;
        private readonly Data _data;

        internal UIFactory(UIData uiData, Data data)
        {
            _uiData = uiData;
            _data = data;
        }
        
        public GameObject CreateUiElement(UiType type)
        {
            var element = Object.Instantiate(_uiData.CreateUiElement(type), _data.Canvas);
            return element;
        }
    }
}

