namespace CardGame.SupportClasses
{
    interface IActions
    {
        bool CanHit { get; set; }
        void Hit();
        void Stand();
    }
}