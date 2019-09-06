using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PraticeTDD.TDDBasic.OO.Report
{
    class ParameterController
    {
        public void FillParameters(IHttpRequest request, ParameterGraph parameterGraph)
        {
            foreach (IParameter para in parameterGraph.BuildParameters())
            {
                para.Fill(request);
            }
        }
    }
}