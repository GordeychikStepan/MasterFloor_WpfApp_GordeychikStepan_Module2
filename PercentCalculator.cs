using System;

namespace TechGear_WpfApp_Test1
{
    public static class PercentCalculator
    {
        public static int GetPercent(int totalSale)
        {
            switch (totalSale)
            {
                case > 300000:
                    return 15;
                case >= 50000:
                    return 10;
                case >= 10000:
                    return 5;
                default:
                    return 0;
            }
        }
    }
}
