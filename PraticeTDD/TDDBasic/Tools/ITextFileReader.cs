using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PracticeTDD.TDDBasic.Tools
{
    public interface ITextFileReader
    {
        IList<string> Read(string fileName);
    }
}
