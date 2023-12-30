namespace Лаб4.Simulation.GameAccounts
{
    public class ReducedLossGameAccount : GameAccount
    {
        public ReducedLossGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
        }

        protected override int CalculateRatingForWin(int gameRating)
        {
            return gameRating;
        }

        protected override int CalculateRatingForLoss(int gameRating)
        {
            return gameRating - 30;
        }

        public override string GetAccountType()
        {
            return "ReducedLossGameAccount";
        }
    }
}