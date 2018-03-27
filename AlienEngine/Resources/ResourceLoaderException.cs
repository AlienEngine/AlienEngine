using System;

namespace AlienEngine.Core.Resources
{
    public class ResourceLoaderException: Exception
    {
        public ResourceLoaderException(string message): base(message)
        {}
    }
}