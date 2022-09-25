namespace ExternalBrandFloorLamp
{
    public class FloorLamp
    {

        private bool status = false;

        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                Console.WriteLine("Floor lamp " + (status ? "ON" : "OFF"));
            }
        }

    }
}