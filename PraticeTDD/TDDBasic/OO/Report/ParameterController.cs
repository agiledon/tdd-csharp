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
                if (para is SimpleParameter) {
                    SimpleParameter simplePara = para as SimpleParameter;
                    string[] values = request.ParameterValues(simplePara.Name);
                simplePara.Values = values;
            } else {
                if (para is ItemParameter) {
                    ItemParameter itemPara = para as ItemParameter;
                    foreach (Item item in itemPara.Items)
                    {
                        string[] values = request.ParameterValues(item.Name);
                        item.Values = values;
                    }
                } else {
                    TableParameter tablePara = para as TableParameter;
                    string[] rows =
                            request.ParameterValues(tablePara.RowName);
                        string[] columns =
                            request.ParameterValues(tablePara.ColumnName);
                        string[] dataCells =
                            request.ParameterValues(tablePara.DataCellName);

                    int columnSize = columns.Length;
                    for (int i = 0; i < rows.Length; i++)
                    {
                        for (int j = 0; j < columns.Length; j++)
                        {
                            TableParameterElement element = new TableParameterElement(rows[i], columns[j], dataCells[columnSize * i + j]);
                            tablePara.AddElement(element);
                        }
                    }
                }
            }
        }
    }
}
}
