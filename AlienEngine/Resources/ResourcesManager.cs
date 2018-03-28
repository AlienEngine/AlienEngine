using System;
using System.Collections.Generic;
using AlienEngine.Core.Assets;
using AlienEngine.Core.Audio;
using AlienEngine.Imaging;
using Mono.CSharp;

namespace AlienEngine.Core.Resources
{
    public static class ResourcesManager
    {
        private static Dictionary<string, IResource> _loadedResources;
        
        private static List<IDisposable> _disposableResources;
        private static bool _disposed;

        private static event Action OnDisposeResources;

        static ResourcesManager()
        {
            _loadedResources = new Dictionary<string, IResource>();
            _disposableResources = new List<IDisposable>();
            _disposed = false;
            OnDisposeResources = new Action(() => { });
        }

        internal static void AddOnDisposeEvent(Action e)
        {
            OnDisposeResources += e;
        }

        internal static void RemoveOnDisposeEvent(Action e)
        {
            OnDisposeResources -= e;
        }

        internal static void AddDisposableResource(IDisposable resource)
        {
            if (_disposed)
            {
                _disposableResources = new List<IDisposable>();
                _disposed = false;
            }

            _disposableResources.Add(resource);
        }

        internal static void RemoveDisposableResource(IDisposable resource)
        {
            if (!_disposed)
                _disposableResources.Remove(resource);
        }

        internal static void DisposeResources()
        {
            OnDisposeResources?.Invoke();
            OnDisposeResources = null;

            for (int i = 0, l = _disposableResources.Count; i < l; i++)
                if (_disposableResources[i] != null)
                    _disposableResources[i].Dispose();

            foreach (var resource in _loadedResources)
            {
                resource.Value.Dispose();
            }

            _disposableResources.Clear();
            _disposableResources = null;
            
            _loadedResources.Clear();
            _loadedResources = null; 
            
            _disposed = true;
        }

        public static T LoadResource<T>(ResourceType resourceType, string path) where T: class, IResource
        {
            IResource resource;

            if (IsResourceLoaded(path))
            {
                resource = _loadedResources[path];
            }
            else
            {
                switch (resourceType)
                {
                    case ResourceType.Texture:
                        resource = new Texture();
                        break;
                    case ResourceType.CubeMap:
                        resource = new Cubemap();
                        break;
                    case ResourceType.Audio:
                        resource = new AudioClip();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(resourceType), resourceType, null);
                }

                if (!resource.Load(path))
                    throw new ResourceLoaderException($"Unable to load the resource at path \"${path}\" using the type \"${nameof(resourceType)}\".");

                _loadedResources.Add(path, resource);
            }

            return resource as T;
        }

        public static T LoadResource<T>(ResourceType resourceType, IAsset asset) where T: class, IResource
        {
            IResource resource = asset.ToResource();

            if (IsResourceLoaded(asset.Source))
            {
                resource = _loadedResources[asset.Source];
            }
            else
            {
                switch (resourceType)
                {
                    case ResourceType.Texture:
                        resource = (Texture) resource;
                        break;
                    case ResourceType.CubeMap:
                        resource = (Cubemap) resource;
                        break;
                    case ResourceType.Audio:
                        resource = (AudioClip) resource;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(resourceType), resourceType, null);
                }

                if (!resource.Load(asset.Source))
                    throw new ResourceLoaderException($"Unable to load the resource at path \"${asset.Source}\" using the type \"${nameof(resourceType)}\".");

                _loadedResources.Add(asset.Source, resource);
            }

            return resource as T;
        }

        public static bool IsResourceLoaded(string path)
        {
            return _loadedResources.ContainsKey(path) && _loadedResources[path] != null;
        }
    }
}
