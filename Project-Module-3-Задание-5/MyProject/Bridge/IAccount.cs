namespace Bridge
{
    interface IAccount
    {
        void Accept(IVisitor visitor);
    }
}
