namespace OwnBrandCeilingLight
{
    public class CeilingLight
    {
        public bool IsOn { get; private set; } = false;

        public void TurnOn()
        {
            IsOn = true; ;
            Console.WriteLine("Ceiling Light ON");
        }

        public void TurnOff()
        {
            IsOn = false; ;
            Console.WriteLine("Ceiling Light OFF");
        }

    }
}
