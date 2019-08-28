using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PraticeTDD.TDDBasic.OO.Report
{
    interface IParameter
    {
        string Name { get; }
    }

    class SimpleParameter : IParameter
    {
        private string name;

        public SimpleParameter(string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public string[] Values {
            get; set;
        }
    }

    class ItemParameter : IParameter
    {
        private readonly string name;
        private IList<Item> items = new List<Item>();

        public ItemParameter(string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public IList<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (item != null)
            {
                items.Add(item);
            }            
        }

    }

    class Item
    {
        private string name;

        public Item(string name)
        {
            this.name = name;
        }

        public string Name => this.name;
        public string[] Values {
            get; set;
        }
    }

    class TableParameter : IParameter
    {
        private string name;
        private IList<TableParameterElement> elements = new List<TableParameterElement>();

        public TableParameter(string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public string RowName { get; set; }
        public string ColumnName { get; set; }
        public string DataCellName { get; set; }

        public IList<TableParameterElement> Elements => this.elements;

        public void AddElement(TableParameterElement element)
        {
            if (element != null)
            {
                this.elements.Add(element);
            }
        }
    }

    class TableParameterElement
    {
        private string row;
        private string column;
        private string dataCell;

        public TableParameterElement(string row, string column, string dataCell)
        {
            this.row = row;
            this.column = column;
            this.dataCell = dataCell;
        }

        public string Row => this.row;
        
        public string Column => this.column;

        public string DataCell => this.dataCell;
    }

}
