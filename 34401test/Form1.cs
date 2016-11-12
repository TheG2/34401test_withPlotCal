using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilent.Agilent34401.Interop;
using Agilent.AgilentRfSigGen.Interop;
//reference from other project 12/16/15
using Ivi.RFSigGen.Interop;
using Ivi.Driver.Interop;
using System.Diagnostics;
using System.IO;
// reference for the Cal module 1/14/16
//  Creating and test a module CalFiles

//12/13/2015 This program connects using VIA to an Keysight 34401a DMM.  The IVI-COM driver is used to speed development with more reuseable code.
// The program sets up the DMM to trigger externally and read 75 points using Multipoint trigger and 
// read. 
// Checkboxes display the completion status of each step. 
// The motiavtion for this program is to characterize the RF detector assemblies 200-0927-320 across many different 
// frequency bands and power levels. The DMM shall be coonnected to the trigger out of a E8257 sweeper so a voltage maesaurement
// shall be triggered at each frequency point in the configured frequency sweeps. 
// Basci program was tested by feeding a square wave from RIGOL DG1022U into the ext trigger connection on a 34401a.
// This is nearly the smae approach required for trigger RF power measurement so that effort is also moved
// forward with this effort.
// QUESTION EMAIL Garret.hurd@xicomtech (or G@EIRP.NET)


// 1-24-16 cleaning up the form and code. 
// step 1 remove debug chunks
// removing DMM btnMeasure control and btnMeasure_Click
// removing  btnDMMEsgOutput and btnDmmEsgOutput_Click
// removing  btnOutputResults and btnOutputResults_Click
// removed the atten hold on/off buttons and routines
// removing the checkboxes for SCPI only control
// deleted ReadMultiPointWithStatus
// 1-26-16 more cleanup: cleanup openInit Routines
// Created separate routines to readback the ESG and DMM configure. Moved of the config routine
// deleting batch testing button. THis works now. btnBatchMeasure_Click
// 11-12-16 publishing to git from VS2015. Verifying basic funtionality of this version.
// form1 has very rough layout, and command buttons are use to intiate conept testing features. 
// more details will be place in the Wiki on GitHub to try out the wiki feature and document this app.


namespace _34401test
{
    public partial class Frm34401test : Form
    {

        #region --- Utility Variables ---
        //Declare 34401
        Agilent34401 DMM = new Agilent34401();

        //Holder for the entered VisaID
        String DMM_VisaID = string.Empty;

        //Declare and instantiate reading array for the voltage readings
        //public Double[] DCVoltPoints =  {0};
        public float[] DCVoltPoints = { 0 };



        //Declare RFSigGen
        AgilentRfSigGen ESG = new AgilentRfSigGen();
 
        //Holder for entered RFSigGen VisaID
        String RFSigGen_VisaID = string.Empty;

        //integer for number of points to measure
        int PointCount;
        //Step frequency range
        double StepFreqRange;

        // array of results to write. Cast RicHTB to string[]
        string[] DataForFile;
        TestDataTable TDT_PwrSweep = new TestDataTable();  //TestDataTable for PwrSweepData
        TestDataTable TDT_FreqSweep = new TestDataTable(); //TestDataTable for FreqSweepData
        TestDataTable TDT_OutputCal = new TestDataTable(); //TestDataTable for Output Calibration
        FrmBigChart frm_OutputCal; 

        //Variables for the Results
        Random randID = new Random(); //Random values for the TestID, column1 of TEST DT
        Double FreqStartPoint;//Frequency value from step
        Double FreqStep;//FreqStep Size set during the configuration routing then used in the output routine.
        Double PwrStartPoint; //starting Pwr STep value. set during configure routine
        Double PwrStepSize; //pwr step increment. SEt during the configure routine.
        string strID; // name for the series, ID of the column

        //Variables for Start and Stop Drive(Ghz) or Freq(GHz)
        //These will be populated by The SetupPwrStep ro SetupFreqstep
        float Xstart;
        float Xstop;
        float XstepSize;

#endregion --- Utility Variables ---


        public Frm34401test()
        {
            InitializeComponent();
        }


#region --- OPEN and INIT EQUIPMENT --
        //---Block of Module For OPEN/Initialze close Methods-----

       /// <summary>
       /// Open/Initializes 34401a and the passed VISA ID.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           //Pass visaID and ButtonID to OpenInit method
            OpenInit_DMM(txtBoxVisaID.Text, button1);
            Config34401(DMM);

        }

        /// <summary>
        /// Opens and initializes the DMM with pass VisaID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="strVisaID">VISA ResourceID of the DMM</param>
        /// <param name="_button">ID of Button used to OPEN/INIT. </param>
        public void OpenInit_DMM(string strVisaID,Button _buttonID )
        {
           //moved to separate open init routine used to be all in button click
           //
            
            if (DMM.Initialized == true)
            {
                //Close DMM, Uncheckbox, Change Btn txt to Open DMM
                DMM.Close();
                txtBoxVisaID.Text = DMM_VisaID;
                chkBox34401Open.Checked = false;
                //button1.Text = "Open/Init 34401";
                _buttonID.Text = "Open/Init DMM";
                ClearCheckBoxes();
                ClearTextBoxes();
            }
            else if (DMM.Initialized == false)
            {
                //Iniialize and add checkmark, change btn txt to Close DMM
                //DMM_VisaID = txtBoxVisaID.Text;
                DMM_VisaID = strVisaID;
                //1-9-16 attempting to add a timeout to the options string
                DMM.Initialize(txtBoxVisaID.Text, false, false, "Simulate=false");
                chkBox34401Open.Checked = true;
               // button1.Text = "Close 34401";
                _buttonID.Text = "Close 34401";
                //Confirm initialize by doing idenifying
                txtBoxVisaID.Text = DMM.Identity.InstrumentModel.ToString();
            }

        }


        /// <summary>
        /// Open/Initialize & CLose RFSig at the passed VISA ID
        /// </summary>
        /// <param name="strVisaID">VISA ID of the ESG</param>
        public void OpenInit_RFSigGen(string strVisaID)
        {
            if (ESG.Initialized == true)
            {
                //Close RFSigGen, Uncheckbox, Change Btn txt to Open/Init
                ESG.Close();
                chkBox_RFSigGenOpenInit.Checked = false;
                btnRFSigGenOpenInit.Text = "Open/Init RFSigGen";
                txtBox_RFSigGenVisaID.Text = RFSigGen_VisaID;
                ClearCheckBoxes();
                ClearTextBoxes();
                //Clear the configure CheckBxo and RchtbBox
                chkboxConfig_SigGen.Checked = false;
                rchTB_SigGenConfigReadout.Clear();
            }
            else if (ESG.Initialized == false)
            {
                //Iniialize and add checkmark, change btn txt to Close RfSigGen
                //RFSigGen_VisaID = txtBox_RFSigGenVisaID.Text;
                RFSigGen_VisaID = strVisaID;
                ESG.Initialize(txtBox_RFSigGenVisaID.Text, false, false, "Simulate=false");
                chkBox_RFSigGenOpenInit.Checked = true;
                btnRFSigGenOpenInit.Text = "Close RFSigGen";
                //Confirm initialize by doing idenifying
                txtBox_RFSigGenVisaID.Text = ESG.Identity.InstrumentModel.ToString();
                //Trying to enable display way up top.
                ESG.Display.DisplayEnabled = true;
                //Setting Update in remote on for development
                //--Manually set as NO SCPI or IVI for this.
            }

        }

        private void btnRFSigGenOpenInit_Click(object sender, EventArgs e)
        {
            //Call  OpenInit_RFSigGen
            OpenInit_RFSigGen(txtBox_RFSigGenVisaID.Text);
        }

        //---END oF Block of Module For OPEN/Initialze close Methods-----
        //----------------------------------------------
#endregion --- OPEN and INIT EQUIPMENT --


#region --- EQUIPEMENT MEASUREMENT CONFIGURATION -----
        //----START OF BLOCK OF Module for instrument CONFIGURAITONS----

        /// <summary>
        /// Configure 34401 for external measurement outputs reults to RchTB for readback
        /// 1-6-16 USES SCPI CONFIGURATION ONLY.  1-24-16 cleaning 
        /// 1-26-2016 moving the configuration readout to separate method. 
        /// </summary>
        public void Config34401(Agilent34401 _DMM)
        {
            //SCPI TO CONFIGURE 34401
                Ivi.Visa.Interop.IFormattedIO488 outVal;
                outVal = _DMM.System.IO;
                outVal.WriteString("*RST");
                outVal.WriteString("*CLS");
                outVal.WriteString("CONF:VOLT:DC 10, 0.01");
                outVal.WriteString("TRIG:SOUR EXT");     
                // Moved the trigger count definition to the Setup for Freq or Ampl sweeps of the ESg
               // outVal.WriteString("TRIG:COUN " + tb_TriggerCount.Text);
                outVal.WriteString("SAMP:COUN 1");
               // INIT Occurs in the measurement routine.   

            //  separate confirmation method. ReadBackConfig_DMM(rchTB_DMMConfigReadout);           
        }

      
       /// <summary>
       /// Sets the DMM TriggerCount. Typically called immediately
       /// after the ESG power or Freq step setup
       /// </summary>
       /// <param name="strTriggerCount"></param>
        public void SetDmmTriggerCount(string strTriggerCount)
        {
            //SETTING THE DMM Trigger Count here. Not clean But will work for the diode test.
            Ivi.Visa.Interop.IFormattedIO488 DMMoutVal;
            DMMoutVal = DMM.System.IO;
            DMMoutVal.WriteString("TRIG:COUN " + ESG.Sweep.PowerStep.Points.ToString());
           // tb_TriggerCount.Text = ESG.Sweep.PowerStep.Points.ToString();
        }


        /// <summary>
        /// Reads and Report the Basic DMM configuration to the reference richTextBox
        /// </summary>
        /// <param name="rchTB"></param>
        public void ReadBackConfig_DMM(RichTextBox rchTB)
        {
            //1-26-16 moved out of the Configure routine
            //This is the richTB that has been used  rchTB_DMMConfigReadout
            rchTB_DMMConfigReadout.Clear();
            chkboxConfigure.Checked = false;

            //Readout to the RichTB To COnfirm.
            rchTB.AppendText("SampleTrigger" + DMM.Trigger.MultiPoint.SampleTrigger.ToString() + "  TrigSource" + DMM.Trigger.Source.ToString() + "\n");
            rchTB.AppendText("Count" + DMM.Trigger.MultiPoint.Count.ToString() + "\n");
            rchTB.AppendText("Range" + DMM.DCVoltage.Range.ToString() + "  Res:" + DMM.DCVoltage.Resolution.ToString());
            rchTB.AppendText("TRIG:COUN =" + DMM.Trigger.MultiPoint.Count.ToString() + "\n");
            //change state of checkbox for visual confirmation
            chkboxConfigure.Checked = true;   
        }




        private void btnConfigure_Click(object sender, EventArgs e)
        {
            //Call the configure DMM
            Config34401(DMM);
            // readback results to GUI
            ReadBackConfig_DMM(rchTB_DMMConfigReadout);      
        }






        //--RFSIG GEN ESG SETUP FUNCTION. 
        //--12-15-2015 adding setup for AMPL and Freq Step Sweeps from other projects. 
        //--Adding the control for all the setup params.

        //----START OF BLOCK OF Module for instrument CONFIGURAITONS----
        //----------------------------------------------
       
      /// <summary>
        /// Configures a frequency sweep:13.75-14.5,75pts,20ms dwell, Negative Trigger
      /// </summary>
      /// <param name="StartFreq">Start Freq in Hz</param>
      /// <param name="StopFreq">Stop Freq in Hz</param>
      /// <param name="Step">Step size in Hz</param>
      /// <param name="PwrdBm">Power level for sweep in dBm</param>
        private void SetFreqStep(Double StartFreq, Double StopFreq, float Step, Double PwrdBm)
        {
          
            //Configures the freq sweep
            ESG.Sweep.Mode = AgilentRfSigGenSweepModeEnum.AgilentRfSigGenSweepModeFrequencyStep;
            //Set FrequecyStep trigger to Softare, as this allows a software trigger to beging the sweep.
            ESG.Sweep.FrequencyStep.ConfigureDwell(AgilentRfSigGenSweepTriggerSourceEnum.AgilentRfSigGenSweepTriggerSourceImmediate, 0.02);
           
           //Set Power, Start, Stop, Dwell for the Freq Sweep (aka Sweep/Step FREQ) 
            ESG.Sweep.FrequencyStep.Start = StartFreq;
            Xstart = Convert.ToSingle(ESG.Sweep.FrequencyStep.Start / 1e9);
            ESG.Sweep.FrequencyStep.Stop = StopFreq;
            Xstop = Convert.ToSingle(ESG.Sweep.FrequencyStep.Stop / 1e9);
            ESG.Sweep.FrequencyStep.Size = Step;
            XstepSize = Convert.ToSingle(ESG.Sweep.FrequencyStep.Stop / 1e9 );
            ESG.Sweep.FrequencyStep.Dwell = 0.02;
            ESG.RF.Level = PwrdBm; //Set the ESG power level
            ESG.RF.OutputEnabled = true;
            StepFreqRange = ESG.Sweep.FrequencyStep.Stop - ESG.Sweep.FrequencyStep.Start;
           
            //Manually calculating and reading out ESG number of points.
            PointCount = Convert.ToInt16(StepFreqRange / ESG.Sweep.FrequencyStep.Size);
            TB_NumberOfPoints.Text = ESG.Sweep.FrequencyStep.Points.ToString();

            //Setting the Sweep state to Single and setting the trigger to allow
            // triggering via a remote command is proving. challenging
           ESG.Sweep.TriggerSource = AgilentRfSigGenSweepTriggerSourceEnum.AgilentRfSigGenSweepTriggerSourceSoftware;
        
            //Set variables so other routines can use various settings.
            //Converting into GHz here
            FreqStartPoint = ESG.Sweep.FrequencyStep.Start/1E09;
            FreqStep = ESG.Sweep.FrequencyStep.Size/1E09;

            //Removing the attenuation Hold and this is conistantly being turned on without
            //a discrete call to turn off.
            //1-7-16 Trying to remove attenuation with :POWer:ATTenuation:AUTO ON 
            //(OFF is equivalent to Atten hold On). 
           Ivi.Visa.Interop.IFormattedIO488 outVal;
           outVal = ESG.System.IO;
           outVal.WriteString(":POW:ATT:AUTO ON");
           //SHould be setup and waiting for the software trigger to come in now.      

            //Readout the configs to the richTB to allow confirmation
           // call routine to readback config ReadBackConfig_ESG(rchTB_SigGenConfigReadout);
        }

        /// <summary>
        /// Configures and ESG Power Step (aka SWEEP/STEP AMPL)
        /// </summary>
        /// <param name="StartPwr">Start power in dBm</param>
        /// <param name="StopPwr">Stop power in dBm</param>
        /// <param name="Step">Step Size in dB</param>
        /// <param name="Freq">Frequency in Herts, typically scientific notation</param>
        private void SetupPwrStep(Double StartPwr, Double StopPwr, float Step, Double Freq)
        {
          
            // set the mode to SWEEP Amplitude Step
            ESG.Sweep.Mode = AgilentRfSigGenSweepModeEnum.AgilentRfSigGenSweepModePowerStep;
            
            // Sweep/Step AMPLitude 
            //set the Freq, start, stop, and Dwell for power step
            ESG.Sweep.PowerStep.Start = StartPwr;
            Xstart = Convert.ToSingle(ESG.Sweep.PowerStep.Start);
            ESG.Sweep.PowerStep.Stop = StopPwr;
            Xstop = Convert.ToSingle(ESG.Sweep.PowerStep.Stop);
            ESG.Sweep.PowerStep.Size = Step;
            XstepSize = Convert.ToSingle(ESG.Sweep.PowerStep.Size );
            ESG.Sweep.PowerStep.Dwell = 0.02;
            ESG.RF.Frequency = Freq;
            ESG.RF.OutputEnabled = true;      //Set RF output oN  

            //1-7-16 Trying to remove attenuation with :POWer:ATTenuation:AUTO ON 
            //(OFF is equivalent to Atten hold On). 
            Ivi.Visa.Interop.IFormattedIO488 outVal;
            outVal = ESG.System.IO;
            outVal.WriteString(":POW:ATT:AUTO ON", true);
        
            //manually calc the number of points and readout the number point from 
            // the ESG for comparison.
            PointCount = Convert.ToInt16((ESG.Sweep.PowerStep.Stop - ESG.Sweep.PowerStep.Start) / ESG.Sweep.PowerStep.Size);   
            TB_NumberOfPoints.Text = ESG.Sweep.PowerStep.Points.ToString();

            //SETTING THE DMM Trigger Count here. Not clean But will work for the diode test.
            //SetDmmTriggerCount(ESG.Sweep.PowerStep.Points.ToString());

            //Set variables so other routines can use various settings.
            //Pwr Step starting point and increment typically in dB
            PwrStartPoint = ESG.Sweep.PowerStep.Start;
            PwrStepSize = ESG.Sweep.PowerStep.Size;

            //Struggline to get the SingleSweep Enabled Via Software
            //REcheck SendSoftwareTrigger();
            ESG.Sweep.TriggerSource = AgilentRfSigGenSweepTriggerSourceEnum.AgilentRfSigGenSweepTriggerSourceSoftware;
                                    
            //REadBack the instrument Ampl Step parameters and fill rchTB to COnfirm
            // Call config readback method ReadBackConfig_ESG(rchTB_SigGenConfigReadout);           
        }

        /// <summary>
        /// Configures the ESG and DMM, the readback configuration
        /// to refernced richTB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigSigGen_Click(object sender, EventArgs e)
        {
           //For Developement having the ESG Display showing all options is best.
            ESG.Display.DisplayEnabled = true;
                    
            //Configure the Sig and REadout THe results
            if (radioBtnFreqStep.Checked)
            {
                
                SetFreqStep(Convert.ToDouble(TB_startFreq.Text), Convert.ToDouble(TB_StopFreq.Text), Convert.ToSingle(tb_FreqStep.Text), Convert.ToDouble(tb_ESGpwr.Text));
                Config34401(DMM);
                SetDmmTriggerCount(ESG.Sweep.FrequencyStep.Points.ToString());
               
            }
            else if (radioBtnPwrStep.Checked)
            {
                
                SetupPwrStep(Convert.ToDouble(tb_StartPwr.Text),Convert.ToDouble(tb_StopPwr.Text),Convert.ToSingle(tb_PwrStepSize.Text),Convert.ToDouble(tb_ESGFreq.Text));
                Config34401(DMM);
                SetDmmTriggerCount(ESG.Sweep.PowerStep.Points.ToString());
            }

            //now configure and confirm the DMM and ESG
            ReadBackConfig_DMM(rchTB_DMMConfigReadout);
            ReadBackConfig_ESG(rchTB_SigGenConfigReadout);

        }


        /// <summary>
        /// Reads back the ESG conifguration to the reference RichTB. 
        /// Best pratice to have as separate routine than embedded in config routine
        /// </summary>
        /// <param name="rchTB">RichTextBox to contain output</param>
        public void ReadBackConfig_ESG(RichTextBox rchTB)
        {
            // 1-26-16 moved to this method from config routine
            // original richTextBox for readback rchTB_SigGenConfigReadout

            rchTB.Clear();
            //Clear the configure CheckBox
            chkboxConfig_SigGen.Checked = false;
            
            //REadBack the instrument Ampl Step parameters and fill rchTB to COnfirm
            rchTB.AppendText("--AMPL SWEEP READBACK---");
            rchTB.AppendText("Mode:" + ESG.Sweep.Mode.ToString() + "\n");
            rchTB.AppendText("StartPwr:" + ESG.Sweep.PowerStep.Start.ToString() + " StopPwr:" + ESG.Sweep.PowerStep.Stop.ToString() + "\n");
            rchTB.AppendText("StepSize:" + ESG.Sweep.PowerStep.Size.ToString() + " Dwell:" + ESG.Sweep.FrequencyStep.Dwell + "\n");
            rchTB.AppendText("PointCount(Man):" + PointCount.ToString() + "PwrStepPoints(ESG)" + ESG.Sweep.PowerStep.Points.ToString() + "\n");
          
            //used to be part of setupFreqSweepRoutine
            rchTB.AppendText("---\n\n" + "--FREQ SWEEP READBACK");
            rchTB.AppendText("Mode:" + ESG.Sweep.Mode.ToString() + "\n");
            rchTB.AppendText("StartFreq:" + ESG.Sweep.FrequencyStep.Start.ToString() + " StopFreq:" + ESG.Sweep.FrequencyStep.Stop.ToString() + "\n");
            rchTB.AppendText("StepSize:" + ESG.Sweep.FrequencyStep.Size.ToString() + " Dwell:" + ESG.Sweep.FrequencyStep.Dwell + "\n");
            rchTB.AppendText("PointCount(Manual):" + PointCount.ToString() + " FreqStepPoints(ESG)" + ESG.Sweep.FrequencyStep.Points.ToString() + "\n");
            chkboxConfig_SigGen.Checked = true;
        
        }

#endregion --- EQUIPEMENT MEASUREMENT CONFIGURATION -----


#region --- INITIATE/PERFORM MEASUREMENTS -----
//----START OF BLOCK to INITIATE/PERFORM CONFIGURED MEASUREMENtS----

        ///// <summary>
        ///// Performs ReadMultiPoint and Returns the Array
        ///// </summary>
        ///// <param name="_DMM"></param>
        ///// <param name="MultiPointPoints"></param>
        //public void MultiPointRead(Agilent34401 _DMM)
        //{
        //    _DMM.Measurement.ReadMultiPoint(5000,ref DCVoltPoints);
        //}
       
        /// <summary>
        /// Perform a complete measurement with All Configured equipement
        /// Puts the DMM in a "WAITING FOR TRIGGER STATE"
        /// Then Send a trigger command to the ESG. 
        /// </summary>
        /// <param name="SweepType">String the represent the sweep type AMPL, FREQ</param>
        public void MeasureAll(string SweepType)
        {
            //uncheckbox to identify routine has started. 
            chkBox_Measure.Checked = false;

            // Place the DMM in the waiting for trigger state
            Ivi.Visa.Interop.IFormattedIO488 outVal;
            outVal = DMM.System.IO;
            outVal.WriteString("INIT");

            // Triggers the ESG to begin the configured sweep
            ESG.SendSoftwareTrigger();  
            
            // Call method to readout the buffer and place each value as array entry
            // Data will be moved from the DMM to OUtput after the measurement is complete. 
            double[] myArray = DMM.IviDmm.Measurement.FetchMultiPoint(5000);

            // RchTxtBoxMeasurement.AppendText("Length of the ReadList Array_List" + myArray.Count().ToString() + "\n"
            chkBox_Measure.Checked = true;

            //Pass the DMM data Array to method and add FREQ or AMPL mechanism
            //the Globally avaiable TestDataTable is filled up and readied for plotting.
            if (SweepType == "Freq")
            {
                // This is a freq step so pass the TDT_
                AddStimulusToDmmData(TDT_FreqSweep, myArray, Convert.ToString(Xstart + " to " + Xstop + "GHz_" + ESG.RF.Level + "dBm"), Xstart, Xstop);
            }
            else if (SweepType == "Ampl")
            {
                //This is a power step so pass the TDT pwrStep
                AddStimulusToDmmData(TDT_PwrSweep, myArray, Convert.ToString(Xstart + " to " + Xstop + " dBm_" + Convert.ToString((ESG.RF.Frequency / 1e9)) + "GHz"), Xstart, Xstop);
            }

        }
        //----END OF BLOCK to INITIATE/PERFORM CONFIGURED MEASUREMENtS----
        //----------------------------------------------------------------
#endregion --- INITIATE/PERFORM MEASUREMENTS -----


#region --- RESULTS OUTPUT FUNCTIONS ---
        //---------------------------------------------------------
        //----START OF BLOCK for outputting MEASUREMENT RESULTS----       
        /// <summary>
        /// Output the results of the array holding the multipoints
        /// if the ESG is Configured and initialized, then also include the frequency points. 
        /// </summary>
        public void OutputMultiPointArray(RichTextBox _RchTxtBox)
        {
            //Accepts the desired richTextBox to contain output as a parameter.
            //THis allows better reuse of the routine.

            //Make sure the ESG is initialized and configured. the build the points.
            if ((ESG.Initialized==true) & (chkboxConfig_SigGen.Checked==true))
            {
                //The data pair will have a pwr or voltage as a pwrStep or FreqStep
                //FreqStep will be Freq,Volts
                //PwrSTep will be Pwr,Volts
                if (radioBtnFreqStep.Checked == true)
                {
                   //FreqStep is selected so need the freq point and the increment.
                    //loop thru results array and output results
                    for (int i = 0; i < DCVoltPoints.Length; i++)
                    {
                        //freqPoint initial Value is set in the Configure routine.
                       // FreqPoint = FreqPoint + i * FreqStep;
                        _RchTxtBox.AppendText((FreqStartPoint + i * FreqStep).ToString() + "," + DCVoltPoints[i].ToString() + "\n");        
                        //.AppendText(i.ToString() + "\n");
                    }
                
                }
                //This is the block when a PwrStep is desired.
                if (radioBtnPwrStep.Checked == true)
                {
                    //Pwr step is selected so need the Pwr starting point and increment.
                    //lopp thru Dcvolts array and add Pwr to each voltage point.
                    for (int i = 0; i < DCVoltPoints.Length; i++)
                    {
                        //freqPoint initial Value is set in the Configure routine.
                        // FreqPoint = FreqPoint + i * FreqStep;
                        _RchTxtBox.AppendText((PwrStartPoint + i * PwrStepSize).ToString() + "," + DCVoltPoints[i].ToString() + "\n");
                        //.AppendText(i.ToString() + "\n");
                    }

                }

    
                
            }

        
        }


        /// <summary>
        /// Output the Measured dmm points to the Identifie Richtextbox
        /// This only requires the DMM to trigger and is independent of the ESG. 
        /// This allow the DMM to be solid prior to moving on. 
        /// </summary>
        /// <param name="_RchTxtBox">RichTextBox that will contain the outputs</param>
        public void OutputDMMData (RichTextBox  _RchTxtBox)
        {

            //Pwr step is selected so need the Pwr starting point and increment.
            //lopp thru Dcvolts array and add Pwr to each voltage point.
            for (int i = 0; i < DCVoltPoints.Length; i++)
            {
                //freqPoint initial Value is set in the Configure routine.
                // FreqPoint = FreqPoint + i * FreqStep;
                _RchTxtBox.AppendText((PwrStartPoint + i * PwrStepSize).ToString() + "," + DCVoltPoints[i].ToString() + "\n");
                //.AppendText(i.ToString() + "\n");
            }

        }


        /// <summary>
        /// Write the contents of the the TDTs to txt file. 
        /// </summary>
        public void WriteTDTsToFile(TestDataTable TDT, string strFileNameModifier)
        {
            // build file name with  unique identifier for the string
            // and the passed file name modifier
            DateTime DT_sec = DateTime.Now;
             string strFileName = @"c:\results\results_" + "_" + strFileNameModifier ;
            strFileName = strFileName + "---" + DT_sec.ToString("mm") + DT_sec.ToString("ss") + ".EIRP";


            //create an instance of the file stream object
           // System.IO.StreamWriter SW_results = new StreamWriter(@"c:\results\results_200-0927-320.EIRP");
            System.IO.StreamWriter SW_results = new StreamWriter(strFileName);
            foreach (DataRow row in TDT.Rows)
            {
                SW_results.WriteLine(row.ItemArray[0] + ","  + row.ItemArray[1] + "," + row.ItemArray[2]);
            }
            //close and cleanup
            SW_results.Close();
            SW_results = null;

        }

       


        //---------------------------------------------------------
        //----END OF BLOCK for outputting MEASUREMENT RESULTS----
#endregion --- RESULTS OUTPUT FUNCTIONS ---



        #region ---- UTILITY and UI ACTIONS STUFF ---

        public void ClearCheckBoxes()
        {
            chkBox34401Open.Checked = false;
            chkboxConfigure.Checked = false;
            chkBoxMakeMeasurement.Checked = false;
            chkBoxOutputResults.Checked = false;
        }


        public void ClearTextBoxes()
        {
            
            rchTB_DMMConfigReadout.Clear();
            RchTxtBoxMeasurement.Clear();
            RichTxtBoxOutput.Clear();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblStepPoints_Click(object sender, EventArgs e)
        {

        }

        private void btnRFOutput_Click_1(object sender, EventArgs e)
        {
            //checks if RF output is enabled, then enables/disables depeding
            //also updates the text on the button
            if (ESG.RF.OutputEnabled)
            {
                //Turn it off 
                ESG.RF.OutputEnabled = false;
                btnRFOutput.Text = "RF ON";
            }
            else if (!ESG.RF.OutputEnabled)
            {
                //turn in on
                ESG.RF.OutputEnabled = true;
                btnRFOutput.Text = "RF OFF";
            }

        }



        //Button to call fetch read testing
        // this is the measure button by the ESG configuration
        private void btnFetchReadTest_Click(object sender, EventArgs e)
        {
            //uncheckbox to identify routine has started. 
            chkBox_Measure.Checked = false;
            
            Ivi.Visa.Interop.IFormattedIO488 outVal;
            outVal = DMM.System.IO; 
            outVal.WriteString("INIT"); // Place the DMM in the waiting for trigger state
            ESG.SendSoftwareTrigger();  // Triggers the ESG to begin the configured sweep
            //outVal.WriteString("FETCH?"); // Move the capture data to the output buffer     
            //float[] myArray;   // Setup float array for holding dmm measurements
            // FetchMultiPoint allow a timeout to be specified. This worked better for this application.
           double[] myArray = DMM.IviDmm.Measurement.FetchMultiPoint(5000);
            // Call method to readout the buffer and place each value as array entry
           // myArray = outVal.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_R4, ",");
           //
            
           // RchTxtBoxMeasurement.AppendText("Length of the ReadList Array_List" + myArray.Count().ToString() + "\n");

           chkBox_Measure.Checked = true;



           //Determine wether to pass a freq or Pwr step TDT
            if (radioBtnFreqStep.Checked)
            {
                // This is a freq step so pass the TDT_
                AddStimulusToDmmData(TDT_FreqSweep, myArray, Convert.ToString(Xstart + " to " + Xstop + "GHz_" + ESG.RF.Level + "dBm"), Xstart, Xstop);
                FrmBigChart frmFreqSweepChart = new FrmBigChart(TDT_FreqSweep, "200-0927-320 FreqSweeps");
                frmFreqSweepChart.Show();
            }
            else if (radioBtnPwrStep.Checked)
            {
                //This is a power step so pass the TDT pwrStep
               AddStimulusToDmmData(TDT_PwrSweep, myArray, Convert.ToString(Xstart + " to " + Xstop + " dBm_" + Convert.ToString((ESG.RF.Frequency/1e9)) + "GHz"), Xstart, Xstop);
                FrmBigChart frmPwrSweepChart = new FrmBigChart(TDT_PwrSweep, "200-0927-320 PwrSweeps");
                frmPwrSweepChart.Show();
            }



            RchTxtBoxMeasurement.Clear();
            //Pwr step is selected so need the Pwr starting point and increment.
            //lopp thru Dcvolts array and add Pwr to each voltage point.
            for (int i = 0; i < myArray.Length; i++)
            {
                //freqPoint initial Value is set in the Configure routine.
                // FreqPoint = FreqPoint + i * FreqStep;
                RchTxtBoxMeasurement.AppendText(myArray[i].ToString() + "\n");
              
                //.AppendText(i.ToString() + "\n");
            }


        }


        private void btn_ClearTDTs_Click(object sender, EventArgs e)
        {
            //testing clearing of the TestDataTables
            TDT_PwrSweep.Clear();
            TDT_FreqSweep.Clear();
        }

        private void btn_WriteTDTsTest_Click(object sender, EventArgs e)
        {
            WriteTDTsToFile(TDT_FreqSweep, "FreqSweeps");
            WriteTDTsToFile(TDT_PwrSweep, "AmplSweeps");
        }

        
#endregion ---- UTILITY and UI ACTIONS STUFF ---
     
#region ---Piece for adding data to TestDataTable And showing the form---

        /// <summary>
        /// Add somerows to the TestDataTable.
        /// Includes an integer that is used to identify a switch(ie case)
        /// for each for the type of data to be added for the test case: SSG, PinPout.
        /// </summary>
        /// < name="DT"></param>
        public TestDataTable AddSomeDataRows(TestDataTable DT, int iType)
        {
            TestDataTable _DT = DT;
            //_DT.Rows.Add("PInPout", -25f, -25f);
            //_DT.Rows.Add("PInPout", -24f, -24f);
            //_DT.Rows.Add("PInPout", -23f, -23f);
            //_DT.Rows.Add("PInPout2", -20f, -25f);
            //_DT.Rows.Add("PInPout2", -21f, -24f);
            //_DT.Rows.Add("PInPout2", -22f, -23f);

            Random randX = new Random(); //Random X Value
            Random randY = new Random(); //random Y value
            float FreqPoint;//Frequency value
            float PwrPoint;//Power Value 
            string strID; // name for the series, ID of the column

            switch (iType)
            {

                case 1://SSG Case



                    //loop 101 points for a small signal gain plot
                    for (int i = 0; i < 100; i++)
                    {
                        FreqPoint = 13.75f + i * .01f;
                        _DT.Rows.Add("SSG attn=0dB", FreqPoint, randY.Next(70, 75));
                    }

                    //Loop 101 points and with 5 dB of atten 
                    for (int i = 0; i < 100; i++)
                    {
                        FreqPoint = 13.75f + i * .01f;
                        _DT.Rows.Add("SSG attn=5dB", FreqPoint, randY.Next(65, 70));
                    }

                    //Loop 101 points and with 10 dB of atten 
                    for (int i = 0; i < 100; i++)
                    {
                        FreqPoint = 13.75f + i * .01f;
                        _DT.Rows.Add("SSG attn=10dB", FreqPoint, randY.Next(60, 65));
                    }

                    //Loop 101 points and with 15 dB of atten 
                    for (int i = 0; i < 100; i++)
                    {
                        FreqPoint = 13.75f + i * .01f;
                        _DT.Rows.Add("SSG attn=15dB", FreqPoint, randY.Next(55, 60));
                    }

                    //Loop 101 points and with 20 dB of atten 
                    for (int i = 0; i < 100; i++)
                    {
                        FreqPoint = 13.75f + i * .01f;

                        if (i <= 50)
                        {

                            //first 50 flat response
                            _DT.Rows.Add("SSG attn=20dB", FreqPoint, randY.Next(50, 53));
                        }
                        else if (i <= 100)
                        {

                            //Add a little slope for last 50 points
                            _DT.Rows.Add("SSG attn=20dB", FreqPoint, randY.Next(48, 51));
                        }

                    }

                    //end of case 1 ssg
                    break;

                case 2: //PinPoutCase

                    //Perform three loop for that simulate low mid and high frequency
                    for (int i = 0; i < 3; i++)
                    {
                        strID = "Freq_" + i.ToString() + "GHZ";
                        for (int Y = 0; Y < 100; Y++)
                        {
                            PwrPoint = -30f + Y * 0.5f;
                            _DT.Rows.Add(strID, PwrPoint, randY.Next(10, 11) + Y * 0.5);

                        }

                    }

                    break; // end of PinPout Switch 


            }

           //Looping Through some Random Numbers to build a few series to test the idea



            return _DT;
        }


        /// <summary>
        /// Simple test to populate a couple TestdataTables and move to a form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrmBigChartTestDT_Test_Click(object sender, EventArgs e)
        {
            //11-7-15 reviewing the code status. This creates a couple instance of DataTable with 
            //Test data then create form with Charts of the DataTable plots. Idea is to get real data from meters. 
            //Look like a AddSomeDataRows does some heavy lifting.

            //declare a table and fill it up SSG
            TestDataTable myDT = new TestDataTable();
            AddSomeDataRows(myDT, 1);
            FrmBigChart myChartFrm = new FrmBigChart(myDT, "Small Signal Gain Testing");
            myChartFrm.Show();

            //Declare a table and fill up a PinPout
            TestDataTable myDT2 = new TestDataTable();
            AddSomeDataRows(myDT2, 2);
            FrmBigChart myChartFrm2 = new FrmBigChart(myDT2, "Power In Vs Power Out Transfer");
            myChartFrm2.Show();

        }


        /// <summary>
        /// Accepts a dataTable filled with DMM Measurements, then adds the stimulus (ie Xvalues)
        /// and the stimulus.
        /// 1-9-16 adjust input array from float[] to double[] to be compatible with DMM.IviDMM.Measurement.FetchMultipoint
        /// </summary>
        /// <param name="ArrayDmmData">TestDataTable that gete the Axis Populated.</param>
        /// <param name="strPlotName">String that is the series Name. Unique so cross binding works</param>
        /// <param name="Xstart">Float that is Starting Xvalue. Typically start Drive level (dBm) or freq (GHz)</param>
        /// <param name="Xstop">Float that is the Ending Xvalue. Typically stop drive (dBm) or Freq(Ghz)</param>
        /// <returns>TestDataTable with data</returns>
        public void AddStimulusToDmmData(TestDataTable TDT, double[] ArrayDmmData, string strPlotName, float Xstart, float Xstop)
        {
         
            float Xvalue; //current Xvalue for the loop

            //need to have some uniqueID in the strPlotName. Two series with the same name makes 
            //for misleading results Going to use a timestamp. 
            DateTime DT_sec = DateTime.Now;
            strPlotName = strPlotName + "---" + DT_sec.ToString("mm") + ":" + DT_sec.ToString("ss");

            //Loop through thte data table add a Dmm data in the third Column
            for (int i = 0; i < ArrayDmmData.Length; i++)
            {
               //determine the Xvalue
               Xvalue = Convert.ToSingle((Xstart + ((Xstop - Xstart) / (ArrayDmmData.Length - 1))*i));
               String.Format("{0:f3}",Xvalue);
                
                // DataRow to the Table.
               TDT.Rows.Add(strPlotName,Xvalue, Convert.ToSingle(ArrayDmmData[i]));    
      
                //RchTextBox OUtput for testing of results
                RichTxtBoxOutput.AppendText (Xvalue + "," + ArrayDmmData[i]+"\n");
            }
           
        }




#endregion ---End of pieces for adding data to TestDataTasble. ---


   


#region ---- Batch tests sequencing ------

        /// <summary>
        /// This will read in a text file that contains the list of test parameters to perform.
        /// Typically this will be one test each line of the file:
        /// Ampl,Start,Stop,freq
        /// freq,Start,Stop,Power 
        /// 
        /// </summary>
        /// <param name="strPathToBatch"></param>
        public void ReadInBatch(string strPathToBatch)
        {

            // Using DotNetPerls StreamReader example
            // http://www.dotnetperls.com/streamreader
            // Read in a file line-by-line, and store it all in a List.
            //
            List<string> listOfTests = new List<string>();
            using (StreamReader reader = new StreamReader(strPathToBatch))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    listOfTests.Add(line);    // Add to list.
                }
            }

            //loop through list and add to the rch_tb its and actual test. \
            for (int i = 0; i < listOfTests.Count; i++)
            {
 
                // Spopplit the line into chunks then check first chunk to see if it defines a test.
                char[] CharDelimiters = { ',' };
                string[] Params = listOfTests[i].Split(CharDelimiters);
             

                if (Params[0] == "Ampl" )
                {
                    Double Start = Convert.ToDouble(Params[1]);
                    Double Stop = Convert.ToDouble(Params[2]);
                    Single StepSize = Convert.ToSingle(Params[3]);
                    Double Point = Convert.ToDouble(Params[4]);   
                    SetupPwrStep(Start,Stop,StepSize,Point);
                    MeasureAll("Ampl");
                    RichTxtBoxOutput.AppendText(Params[0] + " " + Start + " " + Stop + " " + StepSize + " " + Point + "\n");
                }
                else if (Params[0] == "Freq")
                {
                    Double Start = Convert.ToDouble(Params[1]);
                    Double Stop = Convert.ToDouble(Params[2]);
                    Single StepSize = Convert.ToSingle(Params[3]);
                    Double Point = Convert.ToDouble(Params[4]);
                    SetFreqStep(Start, Stop, StepSize, Point);
                    MeasureAll("Freq");
                    RichTxtBoxOutput.AppendText(Params[0] + " " + Params[1] + " " + Params[2] + " " + StepSize + " " + Point + "\n");
                }

                
            }

            //Check to see if the TestDataTable have records, then conditionally show the graph
            //and write the results to a file.
            //show the charts
            if (TDT_FreqSweep.Rows.Count > 0)
            {
                FrmBigChart frmFreqSweepChart = new FrmBigChart(TDT_FreqSweep, "200-0927-320_FreqSweeps");
                frmFreqSweepChart.Show();
                //write results to file
                WriteTDTsToFile(TDT_FreqSweep, "200-0927-320_FreqSweeps");
            }

            if (TDT_PwrSweep.Rows.Count > 0)
            {
                FrmBigChart frmPwrSweepChart = new FrmBigChart(TDT_PwrSweep, "200-0927-320_PwrSweeps");
                frmPwrSweepChart.Show();
                //write results to file
                WriteTDTsToFile(TDT_PwrSweep, "200-0927-320_AmplSweeps");
            }

        
          
          
           
            
        
        }





        #endregion ----- End of batch testing section----

        private void btnReadInBatch_Click(object sender, EventArgs e)
        {
            ReadInBatch(@"c:\results\TestBatch.txt");
        



        }

        private void btnCalFileToSpecificTest_Click(object sender, EventArgs e)
        {
            // button for testing the CalibrationUtilz method to readin a cal file 
            // and return a specifically formatted array. of frequency and requested
            // cal factors at the requested points.

            //Adding a StopWatch To this to understand the execution time hit.
            Stopwatch CalTestTimer = new Stopwatch();
            //CalTestTimer.Start(); // Start the timer.

            //Create instance of the CalibratitionUtilz;
            CalibrationUtilz CalUtilz = new CalibrationUtilz();

            //Get Current start and stop frequency from ESG Config Boxes
            double TestStartFreq = Convert.ToDouble(TB_startFreq.Text);
            double TestStopFreq = Convert.ToDouble(TB_StopFreq.Text);
            
            //Adding OpenFileDialogFeatures
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
              
                string file = openFileDialog1.FileName;
                //string strFrequencies = CalUtilz.CalFiletoSpecificCal(@file, 7.9, 8.4, 50);
                try
                {
                    
                    //Read Entire contents of selected file to Array
                    string[] FullCalFileArray = CalUtilz.MakeFullCalFileArray(@file);
                    //Check Validate the frequency Range of Test and Cal. 
                    string strCalValidation = CalUtilz.CheckFreqRange(FullCalFileArray, TestStartFreq, TestStopFreq);
                    // Now Make Specific Cal for the Curret test range
                    if (strCalValidation == "1")
                    {
                        
                        // first step is to clear the TDT
                        TDT_OutputCal.Clear();
                        
                        //string strFrequencies = CalUtilz.CalFiletoSpecificCal(FullCalFileArray, TestStartFreq, TestStopFreq, 50);
                        
                        CalTestTimer.Reset();
                        CalTestTimer.Start();
                        TDT_OutputCal = CalUtilz.CalFiletoSpecificCal(FullCalFileArray, TestStartFreq, TestStopFreq,50);
                        
                        
                        
                        //Stop the timer.
                        CalTestTimer.Stop();
                        
                        //Call Utility function to dump the DT to a richTB
                        DumpTDTtoRchTB(rchTB_CalTest, TDT_OutputCal);
                        
                        
                        //Clear Previous Results, Readout New Results, Readout Elapsed Time
                       // rchTB_CalTest.Clear();
                        //rchTB_CalTest.AppendText("Results from the cal file" + "\n" + strFrequencies + "\n");
                        //rchTB_CalTest.AppendText("TDT_OuputCal: " + TDT_OutputCal.Rows.Count.ToString() + " ROWS \n");
                        //rchTB_CalTest.AppendText("Elapsed Time (ms):" + CalTestTimer.ElapsedMilliseconds.ToString() + "\n");       
                    }
                    else
                    {
                        //must be a cal validation issue
                        rchTB_CalTest.Clear();
                        CalTestTimer.Stop();
                        rchTB_CalTest.AppendText("CAL ISSUE " + strCalValidation + "\n" + "elapsed:" + CalTestTimer.ElapsedMilliseconds.ToString());
                    }
             
                }
                catch (IOException)
                {
                }
            }
           
        }




        /// <summary>
        /// Utililty function that will dump the contents of the passed DataTable 
        /// to the reference rchTB. 
        /// </summary>
        /// <param name="rchTB">The richTB that should contain the results</param>
        /// <param name="DT">DataTable that should be dumped to the richTB</param>
        public void DumpTDTtoRchTB(RichTextBox rchTB, DataTable DT)
        {
           //1-18-2016 works fine. Used for checking the Cal output routine 
            rchTB.Clear();      
            foreach (DataRow DR in DT.Rows)
            {
                rchTB.AppendText(DR[0].ToString() + ","+ DR[1].ToString() +","+ DR[2].ToString()+"\n");
            }
        }


        /// <summary>
        /// Clear any existing Series on reference chart then rebinds the passed dataTable
        /// </summary>
        
        /// <param name="TDT"></param>
        public void PlotDataTable( TestDataTable TDT)
        {
            frm_OutputCal = new FrmBigChart(TDT, "output cal");
            frm_OutputCal.Show();
        }

        private void btnPlotCal_Click(object sender, EventArgs e)
        {
            PlotDataTable(TDT_OutputCal);
        }

        private void RchTxtBoxMeasurement_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm34401test_Load(object sender, EventArgs e)
        {

        }

        private void rchTB_DMMConfigReadout_TextChanged(object sender, EventArgs e)
        {

        }





    }
}
