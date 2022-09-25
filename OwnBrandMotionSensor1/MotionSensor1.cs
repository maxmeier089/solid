namespace OwnBrandMotionSensor1
{
    public class MotionSensor1
    {

        private readonly Random random = new();

        /// <summary>
        /// Returns motion activity [0,1]
        /// </summary>
        /// <returns></returns>
        public double GetMotionActivity()
        {
            int currentSecond = DateTime.Now.Second;

            // in the second half of a minute, decrease values to zero again
            if (currentSecond > 30) currentSecond = 60 - currentSecond;

            // scale to [0,1]
            double motionActivity = (double)currentSecond / 30.0;

            // add a bit of randomness
            motionActivity = (motionActivity * 0.8) + random.NextDouble() * 0.2;

            return motionActivity;
        }

    }
}