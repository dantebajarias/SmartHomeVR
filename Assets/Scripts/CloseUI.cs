using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Oculus.Interaction
{
    public class CloseUI : MonoBehaviour
    {
        [SerializeField, Interface(typeof(ISelector))]
        private UnityEngine.Object _selector;

        [SerializeField]
        private GameObject UI;

        private ISelector Selector;

        private bool _selected = false;

        protected bool _started = false;

        protected virtual void Awake()
        {
            Selector = _selector as ISelector;
        }

        protected virtual void Start()
        {
            this.BeginStart(ref _started);
            this.AssertField(Selector, nameof(Selector));
            this.EndStart(ref _started);
        }

        protected virtual void OnEnable()
        {
            if (_started)
            {
                Selector.WhenSelected += HandleSelected;
                Selector.WhenUnselected += HandleUnselected;
            }
        }

        protected virtual void OnDisable()
        {
            if (_started)
            {
                HandleUnselected();
                Selector.WhenSelected -= HandleSelected;
                Selector.WhenUnselected -= HandleUnselected;
            }
        }

        private void OnDestroy()
        {
            //Destroy(_material);
        }

        private void HandleSelected()
        {
            if (UI != null)
            {
                UI.SetActive(false);
            }
            if(_selected) return;
            _selected = true;

        }
        private void HandleUnselected()
        {
            if (!_selected) return;
            _selected = false;

        }


        #region Inject

        public void InjectSelector(ISelector selector)
        {
            _selector = selector as UnityEngine.Object;
            Selector = selector;
        }

        #endregion

    }
}