using System;
using AlienEngine.Core.Resources;

namespace AlienEngine.Core.Audio
{
    public class AudioClip: IResource
    {
        public bool Load(string path)
        {
            return false;
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~AudioClip()
        {
            ReleaseUnmanagedResources();
        }
    }
}
