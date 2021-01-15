using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class ReductionInSizeTransformers : ITransformer<ReductionInSizeParameters>
    {
        public Size ResultSize { get; private set; }

        Size originalSize;
        double TransformParameter;


        public void Initialize(Size size, ReductionInSizeParameters parameters)
        {
            originalSize = size;
            TransformParameter = parameters.ReductionInSizeParameter;

            ResultSize = new Size(
                (int)(size.Width / TransformParameter),
                (int)(size.Height / TransformParameter));

            if (ResultSize.Width == 0 || ResultSize.Height ==0)
            {
                ResultSize = size;
                TransformParameter = 1;
            }
        }

        public Point? MapPoint(Point point)
        {
            var x = (int)(point.X * TransformParameter);
            var y = (int)(point.Y * TransformParameter);

            return new Point(x, y);
        }
    }
}
