using Xunit;

namespace Google.Authenticator.Test
{
    public class KeyFinderTest
    {

        [Fact]
        public void FindIterationNumber()
        {
            string secretKey = "PJWUMZKAUUFQKJBAMD6VGJ6RULFVW4ZH";
            string targetCode = "267762";

            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

            long currentTime = 1416643820;

            // we're going to count backwards from a specified date to a known time, I think
            for (long i = currentTime; i >= 0; i = i - 60)
            {
                var result = tfa.GeneratePINAtInterval(secretKey, i, 6);
                if (result == targetCode)
                {
                    Assert.True(true);
                    return;
                }
            }

            Assert.True(false);
        }
    }

}
