using System;
using System.Collections.Concurrent;

namespace reCaptureApp.MVVM
{
    public static class ViewConnector
    {
        private static ConcurrentDictionary<Type, Type> _registrations = new ConcurrentDictionary<Type, Type>();

        public static void RegisterViewAndViewModelConnection(Type viewModelType, Type viewType)
        {
            if (viewModelType == null)
            {
                throw new ArgumentNullException(nameof(viewModelType), "The ViewModel type could not be null.");
            }

            if (viewType == null)
            {
                throw new ArgumentNullException(nameof(viewType), "The View type could not be null.");
            }

            if (!viewModelType.IsSubclassOf(typeof(ViewModelBase)))
            {
                throw new Exception($"{nameof(viewModelType)} is not deriving from {nameof(ViewModelBase)}");
            }

            if (!viewType.IsSubclassOf(typeof(ViewBase)))
            {
                throw new Exception($"{nameof(viewType)} is not deriving from {nameof(ViewBase)}");
            }

            if (_registrations.ContainsKey(viewModelType))
            {
                throw new Exception($"This type of viewmodel has been already registered. Type: {viewModelType}");
            }

            bool success = _registrations.TryAdd(viewModelType, viewType);

            if (!success)
            {
                throw new Exception($"An another thread has already registered this type of ViewModel. Type: {viewModelType}");
            }
        }

        public static ViewBase GetNewViewInstanceForViewModelType(Type viewModelType, ViewModelBase bindingContext)
        {
            if (viewModelType == null)
            {
                throw new ArgumentNullException(nameof(viewModelType), "The ViewModel type could not be null.");
            }

            Type viewType;
            if (!_registrations.TryGetValue(viewModelType, out viewType))
            {
                throw new Exception($"This type of ViewModel is not registered. Type: {viewModelType}");
            }

            ViewBase newInstance = Activator.CreateInstance(viewType) as ViewBase ?? throw new Exception($"Could not create instance of {viewType?.AssemblyQualifiedName ?? "null"}");

            newInstance.BindingContext = bindingContext;

            return newInstance;
        }
    }
}
