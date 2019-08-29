using System.Collections.Generic;

namespace Zhangyi.PracticeTDD.TDDBasic.Tools.Moq
{
    public interface ITextFileReader
    {
        IList<string> Read(string fileName);
    }
}
