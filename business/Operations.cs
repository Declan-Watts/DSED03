using System;

namespace DSED03.business
{
    public static class Operations
    {
        public static int randomNumber(int from, int to)
        {
            Random rnd = new Random();
            int result = rnd.Next(from, to);
            return result;
        }
    }
}