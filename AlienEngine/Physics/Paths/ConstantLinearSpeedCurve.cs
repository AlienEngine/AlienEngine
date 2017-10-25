

namespace AlienEngine.Core.Physics.Paths
{
    /// <summary>
    /// Wrapper around a 3d position curve that specifies a specific velocity at which to travel.
    /// </summary>
    public class ConstantLinearSpeedCurve : ConstantSpeedCurve<Vector3f>
    {
        /// <summary>
        /// Constructs a new constant speed curve.
        /// </summary>
        /// <param name="speed">Speed to maintain while traveling around a curve.</param>
        /// <param name="curve">Curve to wrap.</param>
        public ConstantLinearSpeedCurve(float speed, Curve<Vector3f> curve)
            : base(speed, curve)
        {
        }

        /// <summary>
        /// Constructs a new constant speed curve.
        /// </summary>
        /// <param name="speed">Speed to maintain while traveling around a curve.</param>
        /// <param name="curve">Curve to wrap.</param>
        /// <param name="sampleCount">Number of samples to use when constructing the wrapper curve.
        /// More samples increases the accuracy of the speed requirement at the cost of performance.</param>
        public ConstantLinearSpeedCurve(float speed, Curve<Vector3f> curve, int sampleCount)
            : base(speed, curve, sampleCount)
        {
        }

        protected override float GetDistance(Vector3f start, Vector3f end)
        {
            float distance;
            Vector3f.Distance(ref start, ref end, out distance);
            return distance;
        }
    }
}