using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class GammaCorectionColorsParameters : IParameters
    {
        public double GammaCorectionColorsRByUser { get; set; }
        public double GammaCorectionColorsGByUser { get; set; }
        public double GammaCorectionColorsBByUser { get; set; }


        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo() {
                    Name = "Канал R",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefailtValue = 1,
                    Increment = 0.01
                },

                new ParameterInfo()
                {
                    Name = "Канал G",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefailtValue = 1,
                    Increment = 0.01
                },

                 new ParameterInfo()
                {
                    Name = "Канал B",
                    MinValue = 0.2,
                    MaxValue = 5,
                    DefailtValue = 1,
                    Increment = 0.01
                }

            };
        }

        public void SetValues(double[] values)
        {
            GammaCorectionColorsRByUser = values[0];
            GammaCorectionColorsGByUser = values[1];
            GammaCorectionColorsBByUser = values[2];
    }
    }
}
