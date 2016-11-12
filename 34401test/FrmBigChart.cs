using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _34401test
{
    public partial class FrmBigChart : Form
    {
        public FrmBigChart(TestDataTable DT,string strChartTitle)
        {
            InitializeComponent();
            TestDataTable myDT = DT;

            //1-18-16 adding a min max check to optimize the scaling
            double minY = double.MaxValue;
            double maxY = double.MinValue;
            double minX = double.MaxValue;
            double maxX = double.MinValue;
            foreach (DataRow dr in DT.Rows)
            {
                double Yvalue = Convert.ToDouble(dr[2]);
                minY = Math.Min(minY, Yvalue);
                maxY = Math.Max(maxY, Yvalue);

                double Xvalue = Convert.ToDouble(dr[1]);
                minX = Math.Min(minX, Xvalue);
                maxX = Math.Max(maxX, Xvalue);
            }



            //CHeck the row count of the pass Datatable to see if there are any contents
            TB_RowCount.Text = DT.Rows.Count.ToString();
            //Setup the chart with
            chart1.Titles.Add(strChartTitle);
            chart1.Series.Clear();
            chart1.DataSource = DT;
            chart1.DataBindCrossTable(myDT.Rows,"ID","XValue","Yvalue","");
            for (int i = 0; i < chart1.Series.Count(); i++)
            {
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
               
            }
            //set the MaxY Value and format above
            chart1.ChartAreas[0].AxisY.Maximum = maxY;
            chart1.ChartAreas[0].AxisY.Minimum = minY;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f2}";

            //SEt the MaxX Value and format
            chart1.ChartAreas[0].AxisX.Maximum = maxX;
            chart1.ChartAreas[0].AxisX.Minimum = minX;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f2}";
            
            //for debugging
            //TB_RowCount.Text = TB_RowCount.Text + " MaxX:" + maxX.ToString() + " MinX:" + minX.ToString();
            //TB_RowCount.Text = TB_RowCount.Text + " MaxY:" + maxY.ToString() + " MinY:" + minY.ToString();
        }

      
    }
}
  