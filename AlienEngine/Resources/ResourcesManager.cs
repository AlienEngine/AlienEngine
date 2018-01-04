using System;
using System.Collections.Generic;

namespace AlienEngine.Core.Resources
{
    internal static class ResourcesManager
    {
        private static List<IDisposable> _disposableResources;
        private static bool _disposed;

        private static event Action OnDisposeResources;

        static ResourcesManager()
        {
            _disposableResources = new List<IDisposable>();
            _disposed = false;
        }

        public static void AddOnDisposeEvent(Action e)
        {
            OnDisposeResources += e;
        }

        public static void RemoveOnDisposeEvent(Action e)
        {
            OnDisposeResources -= e;
        }

        public static void AddDisposableResource(IDisposable resource)
        {
            if (_disposed)
            {
                _disposableResources = new List<IDisposable>();
                _disposed = false;
            }

            _disposableResources.Add(resource);
        }

        public static void RemoveDisposableResource(IDisposable resource)
        {
            if (!_disposed)
                _disposableResources.Remove(resource);
        }

        public static void DisposeResources()
        {
            OnDisposeResources?.Invoke();
            OnDisposeResources = null;

            for (int i = 0, l = _disposableResources.Count; i < l; i++)
                if (_disposableResources[i] != null)
                    _disposableResources[i].Dispose();

            _disposableResources.Clear();
            _disposableResources = null;
            _disposed = true;
        }
    }
}
