using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class GammaCorectionColorsFilter : PixelFilter
    {
        public GammaCorectionColorsFilter() : base(new GammaCorectionColorsParameters()) {}

        public override string ToString()
        {
            return "Гамма-корекция цвета";
        }
        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {

            var newR = Math.Pow(originalPixel.R, 1 / (parameters as GammaCorectionColorsParameters).GammaCorectionColorsRByUser);
            var newG = Math.Pow(originalPixel.G, 1 / (parameters as GammaCorectionColorsParameters).GammaCorectionColorsGByUser);
            var newB = Math.Pow(originalPixel.B, 1 / (parameters as GammaCorectionColorsParameters).GammaCorectionColorsBByUser);


            return new Pixel(newR, newG, newB);
        }
    }
}
