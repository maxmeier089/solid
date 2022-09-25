namespace ExternalBrandSoundSensor
{
    public class ExternalSoundSensor
    {

        private readonly Random random = new();

        /// <summary>
        /// Returns sound activity [0,10]
        /// </summary>
        public float ReadSoundLevel()
        {
            int currentSecond = DateTime.Now.Second;

            // in the second half of a minute, decrease values to zero again
            if (currentSecond > 30) currentSecond = 60 - currentSecond;

            // scale to [0,1]
            float soundAcitity = currentSecond / 30.0f;

            // add a bit of randomness
            soundAcitity = (soundAcitity * 0.8f) + ((float)random.NextDouble() * 0.2f);

            // scale to [0,10]
            soundAcitity *= 10.0f;

            return soundAcitity;
        }

    }
}