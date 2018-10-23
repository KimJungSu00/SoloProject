namespace UI.Model
{
    public interface IItemExchangeable
    {
        void Send();
        void Receive(ItemStruct item);
    }
}
