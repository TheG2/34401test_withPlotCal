using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace _34401test
{
    /// <summary>
    /// Add a new class to project that will inclue basic method for handling common cal file
    /// operations. First method being created in a tool to read in a pass cal file then return an 
    /// array of the desired size. 
    /// </summary>
    class CalibrationUtilz
    {



        /// <summary>
        /// Accepts a path to CalFile then reads entire contents into
        /// an string array. Validation and parsing for specific test then 
        /// handled by other functions
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public string[] MakeFullCalFileArray(string strPath)
        {
            string[] FullCalArray = { "cal" };

            //StopWatch for measuring the execution time of the this approach
            Stopwatch CalTimer = new Stopwatch();
            CalTimer.Start();

            // Read the entire cal file into a string array
            if (File.Exists(strPath))
            {
                FullCalArray = File.ReadAllLines(strPath);
            }

            return FullCalArray;
        }






        
        /// <summary>
        /// Accepts a path with file name to a typical XCM *cal  file the returns
        /// a trimmed down specific double array of calibration factor for the request
        /// start, stop, and point counts. The intent is to then add this trimmed down specificArray
        /// to an array of RF power measurements of the same points count. Cal gets added to the measurement
        /// resulting in a claibrated power measurement.
        /// </summary>
        /// <param name="strCalFileName">File Qualified path with fileName to *.cal file</param>
        /// <param name="Start">Double for the start frequency in GHz</param>
        /// <param name="Stop">double for the stop frequency in GHz</param>
        /// <param name="CalPoints">
        /// integer for the number of points. Example would be 76 for the typical
        /// 750Mhz sweep every 10 Mhz
        /// </param>
        /// <returns></returns>
        //public double[] CalFiletoSpecificCal(string strCalFileName,double Start, double Stop, int Points)
       
        //1-15-16 changing this function to return a TestDataTable with the Specific Cal.
        //public string CalFiletoSpecificCal(string[] FullCalArray, double Start, double Stop, int CalPoints)  
        public TestDataTable CalFiletoSpecificCal(string[] FullCalArray, double Start, double Stop, int CalPoints)  
        {               
            //double[] SpecificCal = {0}; //Arry for dssired results
            //string[] FullCalArray = {"cal"};

            //String builder for testing purpose on 1-14-16
            //the final version of the routing will return an array
            //string builder is useful during the test phase. 
            StringBuilder strBldrResults = new StringBuilder();

            //create new instance for returning results
            //New row are added inside the for loop below
            TestDataTable TDT_SpecificCal = new TestDataTable(); 


            //StopWatch for measuring the execution time of the this approach
            Stopwatch CalTimer = new Stopwatch();
            CalTimer.Start();
           
            //// Read the entire cal file into a string array
            //if (File.Exists(strCalFileName))
            //{
            //    FullCalArray = File.ReadAllLines(strCalFileName);
            //}

        

            //Check to see that requested frequencies are in the cal file.
            //Seems best to have a seperate routine to check for this.
           // CheckFreqRange(FullCalArray, Start, Stop);

            
            // Find the index for Start Frequency and Calfactor
           // int StartIndex = Array.FindIndex(FullCalArray, element => element.StartsWith(Start.ToString(), StringComparison.Ordinal));
            
            // Find the index for Stop Frequency and CalFactor
           // int StopIndex = Array.FindIndex(FullCalArray, element => element.StartsWith(Stop.ToString(), StringComparison.Ordinal));

             
            //Loop through the FullCalArray for the requested points
            //frequency spacing, locating the specific calibration point each time.
            // setup a starting value for last Good cal index
            int indexOfLastValidCal = 10;

            
            //---Loop that does the heavy lifting is here---///
            #region--Start of loop through fullCalFile locating points--
            
            for (int i = 0; i <= CalPoints; i++)
            {
                double SearchFreq = Start + ((Stop - Start) / CalPoints) * i;
                string strSearchFreq = Math.Round(SearchFreq, 2).ToString("0.00");
                int indexForSpecificCal;     //Index to actually get for the calfilev

                //most calibration files only have 1 digit precision for value each 10Hz. 
                //for example, 13.80 GHz, is list as 13.8 which will not be located in most cases. 
                // First method is to locate by 0.00 format, then check if the last 0. 
                // if the last digit is 0, then format to 0.0

                //if (strSearchFreq.Substring(4,1) == "0") this throws error as frequencies lower than 10 GHz
                //wont have 4 positions. 1234 or 7.90
                //First check the value of the frequency
                if (SearchFreq < 10)
                {
                    //now check for the 0 and cut off
                    if (strSearchFreq.Substring(3, 1) == "0")
                    {
                        //trim off the last character
                        strSearchFreq = strSearchFreq.Substring(0, 3);
                    }
                }
                //now check for Search Frequencies Greater than 10 GHz
                else if (SearchFreq <= 10)
                {
                    //now check for the 0 and cut off
                    if (strSearchFreq.Substring(4, 1) == "0")
                    {
                        //trim off the last character
                        strSearchFreq = strSearchFreq.Substring(0, 4);
                    };
                }

                
                // index actually retried from FindINdex Routine
                int LocatedFreqIndex = Array.FindIndex(FullCalArray, element => element.StartsWith(strSearchFreq, StringComparison.Ordinal));

                 //Check to see if Array.FindIndex Returned anything
                  if (LocatedFreqIndex == -1)
                  {
                      // use the last know good cal index
                      indexForSpecificCal = indexOfLastValidCal;
                  }
                  else
                  {
                     //LocatedFreqIndex is good so use that for the file
                      indexForSpecificCal = LocatedFreqIndex;
                      // reset the last known good marker to the Located index
                      indexOfLastValidCal = LocatedFreqIndex;
                  }

              //Now get the CalFactor from the string
              int intCommaLocation = FullCalArray[indexForSpecificCal].IndexOf(",");
              int intLengthOfRow = FullCalArray[indexForSpecificCal].Length;
              string strCalFactor = FullCalArray[indexForSpecificCal].Substring(intCommaLocation+1, (intLengthOfRow - intCommaLocation - 1));

                // integer for holding the most recent LocatedFreqIndex.ToString \
                // There will typically be instance where the specific search frequency cannot be located, so using the most recent index
                // will pretty much just use and interpolation. This add some 
                // error but its an acceptable magnitude of error. Typical cal file incremenet is 2.5. 

          
                //strBldrResults.Append(FullCalArray[LocatedFreqIndex] + "___" + CalTimer.ElapsedMilliseconds.ToString() + "ms, " + SearchFreq.ToString() + "\n");
              //strBldrResults.AppendLine(strSearchFreq + "," + Math.Round(SearchFreq, 2).ToString("0.00") + ", index:" + indexForSpecificCal.ToString() + "," + strCalFactor);
              strBldrResults.AppendLine( Math.Round(SearchFreq, 2).ToString("0.00")  + "," + strCalFactor);

               //1-15-16 Adding the search frequency and Calfactor to Teste Data Table
               //Add ID,Frequency,CalFactor to TDT_Specific Cal
              TDT_SpecificCal.Rows.Add("XCM-foo",Math.Round(SearchFreq, 2),Convert.ToDouble(strCalFactor));
                

            }

            strBldrResults.Append("TDT_SpecificCal.RowCount=" + TDT_SpecificCal.Rows.Count.ToString());
            #endregion--End of loop through fullCalFile locating points--

            //return SpecificCal;
            
            //testing. Return the full string for start frequency line. 
            //This should be the two value string with the freq,cal factor. 
            //return (FullCalArray[StartIndex] + "\n" + FullCalArray[StopIndex]);
            //1-15-16 testing to change to return object from a string{} to a TestDataTable.
            //return strBldrResults.ToString();
            return TDT_SpecificCal;


          


        }


        /// <summary>
        /// Verifies the request measurement start and stop frequencies are
        /// withing the range of the calibration file.
        /// Note Calibration Start Frequency is on line 10 (zero based index)
        /// highest (ie Stop) frequency is on line 10 + Cal point Count (from line 9 index 8)
        /// </summary>
        /// <param name="FullCalfile">String array of Entire Call file</param>
        /// <param name="Start">Start Frequeny in GHz</param>
        /// <param name="Stop">Stop Frequency in GHz</param>
        /// <returns>string with results</returns>
        public string CheckFreqRange(string[] FullCalArray, double Start, double dblStop)
        {
            StringBuilder strResults = new StringBuilder();
            //Get MinFreq from CalfileArray index 9 (row 10)
            int intCommaLocation = FullCalArray[9].IndexOf(",");
            double CalFileMinFreq = Convert.ToDouble(FullCalArray[9].Substring(0, intCommaLocation ));
            
            //Get MaxFrom from LastIndex of CalFileArray
            intCommaLocation = FullCalArray.Last().IndexOf(",");
            double CalFileMaxFreq = Convert.ToDouble(FullCalArray.Last().Substring(0, intCommaLocation ));

            if (CalFileMinFreq > Start)
            {
                // Add warning to strBuilder
                strResults.Append("StartFreq Lower than CalFile Minimum Freq. \n");
                strResults.Append("Test Min:" + Convert.ToString(Start) + " Cal Min: " + CalFileMinFreq + "\n");
            }

            if (CalFileMaxFreq < dblStop)
            {
                // Add max freq problem to strBuilder
                strResults.Append("Current Stop Freq is greater than CalFile Max Freq. \n");
                strResults.Append("Test Max:" + Convert.ToString(dblStop) + " Cal Max: " + CalFileMaxFreq + "\n");
            }

            //if the stringBuilder is empty at this point then it likely ok
            if (strResults.Length == 0)
            {
                strResults.Clear();
               strResults.Append("1");

            }

            //For development and Testing Displays the MessageBox.
        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        string caption = "Calibration File Check Results";
		DialogResult result;
        result = MessageBox.Show(strResults.ToString(), caption, buttons);
          
            return strResults.ToString();
        }

    
    
    
    
    
    
    
    }


    }
    


