using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FooFoo
{
    //only there is sense managing exceptions in the case we logged it 
    //before to throw such exception
    //The methods on each class must have enough cohision if not put them in an independent class
    //Also we can reuse such class/method in another case

    //Methods and classes with intention Names
    //short Methods 5 to 8 lines maximum
    //Each class with its respective methods cohition
    //should do only one thing
    //find & group lines related, and extract them onto related classes, 
    //put all the methods togheter
    public class DataTableToCsvMapper
    {
        private StreamWriter _stream;
        private DataTable _dataTable;

        public MemoryStream Map(DataTable dataTable)
        {
            MemoryStream returnStream = new MemoryStream();
            _stream = new StreamWriter(returnStream);
            _dataTable = dataTable;
            WriteColumnNames();
            WriteRows();
            _stream.Flush();
            _stream.Close();
            return returnStream;
        }

        private void WriteColumnNames()
        {
            for (int i = 0; i < _dataTable.Columns.Count; i++)
            {
                _stream.Write(_dataTable.Columns[i]);
                if (i < _dataTable.Columns.Count - 1)
                    _stream.Write(",");
            }
            _stream.WriteLine();
        }

        private void WriteRows()
        {
            foreach (DataRow dr in _dataTable.Rows)
            {
                WriteRow(dr);
                _stream.WriteLine();
            }
        }

        private void WriteRow(DataRow dr)
        {
            for (int i = 0; i < _dataTable.Columns.Count; i++)
            {
                WriteCell(dr[i]);
                WriteSeparator(i);
            }
        }

        private void WriteCell(object cell)
        {
            if (!Convert.IsDBNull(cell))
            {
                string str = $"\"{cell.ToString():c}\"".Replace("\r\n", " ");
                _stream.Write(str);
            }
            else
            {
                _stream.Write("");
            }
        }

        private void WriteSeparator(int i)
        {
            if (i < _dataTable.Columns.Count - 1)
                _stream.Write(",");
        }
    }
}