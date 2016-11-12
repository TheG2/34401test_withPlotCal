using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _34401test
{
    public class TestDataTable:DataTable
    {
       /// <summary>
        /// Sets up a dataTable that is appropriate for DataCrossBinds and storing Xicom data 
        /// This can be used to pass the data between two or multiple forms.
        /// Same Method from PwrMeter Testing applications
       /// </summary>
        public TestDataTable()
        {
            Columns.Add("ID", typeof(string));
            Columns.Add("XValue", typeof(float));
            Columns.Add("YValue", typeof(float));
        }
    }







}