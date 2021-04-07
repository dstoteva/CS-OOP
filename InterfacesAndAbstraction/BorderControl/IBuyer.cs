namespace BorderControl
{
    public interface IBuyer : IAgeable, IInhabitor
    {
        int Food { get; set; }

        void BuyFood();
    }
}