namespace OwnBrandSoundSensor
{
    public class SoundSensor
    {

        private readonly Random random = new();

        /// <summary>
        /// Returns sound activity [0,1]
        /// </summary>
        public double GetSoundActivity()
        {
            int currentSecond = DateTime.Now.Second;

            // in the second half of a minute, decrease values to zero again
            if (currentSecond > 30) currentSecond = 60 - currentSecond;

            // scale to [0,1]
            double soundAcitity = (double)currentSecond / 30.0;

            // add a bit of randomness
            soundAcitity = (soundAcitity * 0.8) + random.NextDouble() * 0.2;

            return soundAcitity;
        }

    }
}