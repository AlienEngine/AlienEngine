using System;
using System.IO;
using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Resources;

namespace AlienEngine
{
    public class AudioSource : Component
    {
        [CLSCompliant(false)]
        protected uint BufferHandle;

        [CLSCompliant(false)]
        protected uint SourceHandle;

        private float _lengthSeconds;

        public bool AutoPlay = false;

        public AudioClip Clip;

        public AudioSource(string file)
        {
            if (file.EndsWith(".wav"))
            {
                LoadWav(File.ReadAllBytes(file));
            }
            else if (file.EndsWith(".ogg"))
            {
                LoadOgg(file);
            }
            else
            {
                throw new NotSupportedException("File format not supported");
            }

            ResourcesManager.AddOnDisposeEvent(Dispose);
        }

        public AudioSource(Stream file, string extension)
        {
            switch (extension)
            {
                case "wav":
                    using (MemoryStream ms = new MemoryStream())
                    {
                        if (!file.CanRead)
                        {
                            throw new NotSupportedException("This stream does not support reading");
                        }
                        byte[] buffer = new byte[16 * 1024];
                        int nread;
                        while ((nread = file.Read(buffer, 0, 16 * 1024)) != 0)
                        {
                            ms.Write(buffer, 0, nread);
                        }

                        LoadWav(ms.ToArray());
                    }
                    break;
                case "ogg":
                    LoadOgg(file);
                    break;
                default:
                    throw new NotSupportedException("Audio format not supported: " + extension);
            }
        }

        private void LoadWav(byte[] wave)
        {
            byte[] data;
            ALFormat format;
            uint chunkSize, sampleRate, avgBytesPerSec;
            short bytesPerSample, bitsPerSample;
            AL.Utils.LoadWavExt(wave, out data, out chunkSize, out format, out sampleRate, out avgBytesPerSec, out bytesPerSample, out bitsPerSample);

            Load(data, format, sampleRate, TimeSpan.FromSeconds(data.Length / (float)avgBytesPerSec));
        }

        private void LoadOgg(string ogg)
        {
            byte[] data;
            ALFormat format;
            uint sampleRate;
            TimeSpan len;
            AL.Utils.LoadOgg(ogg, out data, out format, out sampleRate, out len);

            Load(data, format, sampleRate, len);
        }

        private void LoadOgg(Stream ogg)
        {
            byte[] data;
            ALFormat format;
            uint sampleRate;
            TimeSpan len;
            AL.Utils.LoadOgg(ogg, out data, out format, out sampleRate, out len);

            Load(data, format, sampleRate, len);
        }

        private unsafe void Load(byte[] data, ALFormat format, uint sampleRate, TimeSpan len)
        {
            AL.GenBuffer(out BufferHandle);

            _lengthSeconds = (float)len.TotalSeconds;

            fixed (byte* dataPtr = &data[0])
            {
                IntPtr dataIntPtr = new IntPtr(dataPtr);
                AL.BufferData(BufferHandle, format, dataIntPtr, data.Length, (int)sampleRate);
            }

            AL.GenSources(1, out SourceHandle);
            AL.Source(SourceHandle, ALSourcei.Buffer, (int)BufferHandle);
            AL.Source(SourceHandle, ALSourceb.Looping, false);
            AL.Source(SourceHandle, ALSourcef.MinGain, 0.0f);
            AL.Source(SourceHandle, ALSourcef.MaxGain, 1.0f);
        }

        public void PlaySound()
        {
            AL.SourcePlay(SourceHandle);
        }

        public void StopSound()
        {
            AL.SourceStop(SourceHandle);
        }

        public void PauseSound()
        {
            AL.SourcePause(SourceHandle);
        }

        public override void Start()
        {
            if (AutoPlay)
                PlaySound();

            gameElement.LocalTransform.OnPositionChange += ((_old, _new) =>
            {
                AL.Source(SourceHandle, ALSource3f.Position, _new.X, _new.Y, _new.Z);
            });

            gameElement.LocalTransform.OnRotationChange += ((_old, _new) =>
            {
                var q = Matrix4f.CreateRotation(_new);
                AL.Source(SourceHandle, ALSource3f.Direction, -q.Column2.X, q.Column2.Y, q.Column2.Z);
            });
        }

        public void Dispose()
        {
            AL.DeleteBuffers(1, ref BufferHandle);
            Buffer = 0;
            AL.DeleteSources(1, ref SourceHandle);
        }

        public TimeSpan Length
        {
            get
            {
                return new TimeSpan(0, 0, 0, (int)_lengthSeconds);
            }
        }

        public bool IsPlaying
        {
            get { return AL.GetSourceState(SourceHandle) == ALSourceState.Playing; }
        }

        public bool IsPaused
        {
            get { return AL.GetSourceState(SourceHandle) == ALSourceState.Paused; }
        }

        public bool IsStoped
        {
            get { return AL.GetSourceState(SourceHandle) == ALSourceState.Stopped; }
        }

        public AudioSourceState State
        {
            get { return (AudioSourceState)AL.GetSourceState(SourceHandle); }
        }

        public bool Looping
        {
            get
            {
                bool result;
                AL.GetSource(SourceHandle, ALSourceb.Looping, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourceb.Looping, value);
            }
        }

        //public Vector3f Direction
        //{
        //    get
        //    {
        //        Vector3f result = new Vector3f();
        //        AL.GetSource(SourceHandle, ALSource3f.Direction, out result.X, out result.Y, out result.Z);
        //        return result;
        //    }
        //    set
        //    {
        //        AL.Source(SourceHandle, ALSource3f.Direction, value.X, value.Y, value.Z);
        //    }
        //}

        public Vector3f Velocity
        {
            get
            {
                Vector3f result = new Vector3f();
                AL.GetSource(SourceHandle, ALSource3f.Velocity, out result.X, out result.Y, out result.Z);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSource3f.Velocity, value.X, value.Y, value.Z);
            }
        }

        public Vector3i EfxAuxiliarySendFilter
        {
            get
            {
                Vector3i result = new Vector3i();
                AL.GetSource(SourceHandle, ALSource3i.EfxAuxiliarySendFilter, out result.X, out result.Y, out result.Z);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSource3i.EfxAuxiliarySendFilter, value.X, value.Y, value.Z);
            }
        }

        public bool EfxAuxiliarySendFilterGainAuto
        {
            get
            {
                bool result;
                AL.GetSource(SourceHandle, ALSourceb.EfxAuxiliarySendFilterGainAuto, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourceb.EfxAuxiliarySendFilterGainAuto, value);
            }
        }

        public bool EfxAuxiliarySendFilterGainHighFrequencyAuto
        {
            get
            {
                bool result;
                AL.GetSource(SourceHandle, ALSourceb.EfxAuxiliarySendFilterGainAuto, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourceb.EfxAuxiliarySendFilterGainAuto, value);
            }
        }

        public bool EfxDirectFilterGainHighFrequencyAuto
        {
            get
            {
                bool result;
                AL.GetSource(SourceHandle, ALSourceb.EfxDirectFilterGainHighFrequencyAuto, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourceb.EfxDirectFilterGainHighFrequencyAuto, value);
            }
        }

        public bool SourceRelative
        {
            get
            {
                bool result;
                AL.GetSource(SourceHandle, ALSourceb.SourceRelative, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourceb.SourceRelative, value);
            }
        }

        public float ConeInnerAngle
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.ConeInnerAngle, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.ConeInnerAngle, value);
            }
        }

        public float ConeOuterAngle
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.ConeOuterAngle, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.ConeOuterAngle, value);
            }
        }

        public float ConeOuterGain
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.ConeOuterGain, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.ConeOuterGain, value);
            }
        }

        public float EfxAirAbsorptionFactor
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.EfxAirAbsorptionFactor, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.EfxAirAbsorptionFactor, value);
            }
        }

        public float EfxConeOuterGainHighFrequency
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.EfxConeOuterGainHighFrequency, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.EfxConeOuterGainHighFrequency, value);
            }
        }

        public float EfxRoomRolloffFactor
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.EfxRoomRolloffFactor, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.EfxRoomRolloffFactor, value);
            }
        }

        public float Volume
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.Gain, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.Gain, value);
            }
        }

        public float MaxDistance
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.MaxDistance, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.MaxDistance, value);
            }
        }

        public float MaxVolume
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.MaxGain, out result);
                return result;
            }
        }

        public float MinVolume
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.MinGain, out result);
                return result;
            }
        }

        public float Pitch
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.Pitch, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.Pitch, value);
            }
        }

        public float ReferenceDistance
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.ReferenceDistance, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.ReferenceDistance, value);
            }
        }

        public float RolloffFactor
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.RolloffFactor, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.RolloffFactor, value);
            }
        }

        public float SecOffset
        {
            get
            {
                float result;
                AL.GetSource(SourceHandle, ALSourcef.SecOffset, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcef.SecOffset, value);
            }
        }

        public int Buffer
        {
            get
            {
                int result;
                AL.GetSource(SourceHandle, ALSourcei.Buffer, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcei.Buffer, value);
            }
        }

        public int ByteOffset
        {
            get
            {
                int result;
                AL.GetSource(SourceHandle, ALGetSourcei.ByteOffset, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcei.ByteOffset, value);
            }
        }

        public int EfxDirectFilter
        {
            get
            {
                int result;
                AL.GetSource(SourceHandle, ALSourcei.EfxDirectFilter, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcei.EfxDirectFilter, value);
            }
        }

        public int SampleOffset
        {
            get
            {
                int result;
                AL.GetSource(SourceHandle, ALGetSourcei.SampleOffset, out result);
                return result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcei.SampleOffset, value);
            }
        }

        public ALSourceType SourceType
        {
            get
            {
                int result;
                AL.GetSource(SourceHandle, ALGetSourcei.SourceType, out result);
                return (ALSourceType)result;
            }
            set
            {
                AL.Source(SourceHandle, ALSourcei.SourceType, (int)value);
            }
        }
    }
}