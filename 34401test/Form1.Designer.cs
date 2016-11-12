namespace _34401test
{
    partial class Frm34401test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm34401test));
            this.txtBoxVisaID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBox34401Open = new System.Windows.Forms.CheckBox();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.chkboxConfigure = new System.Windows.Forms.CheckBox();
            this.chkBoxMakeMeasurement = new System.Windows.Forms.CheckBox();
            this.chkBoxOutputResults = new System.Windows.Forms.CheckBox();
            this.lbl_RFsigGenOpenInit = new System.Windows.Forms.Label();
            this.txtBox_RFSigGenVisaID = new System.Windows.Forms.TextBox();
            this.lblRFSigGenVisaID = new System.Windows.Forms.Label();
            this.btnRFSigGenOpenInit = new System.Windows.Forms.Button();
            this.chkBox_RFSigGenOpenInit = new System.Windows.Forms.CheckBox();
            this.TB_startFreq = new System.Windows.Forms.TextBox();
            this.lblStartFreq = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_StopFreq = new System.Windows.Forms.TextBox();
            this.TB_NumberOfPoints = new System.Windows.Forms.TextBox();
            this.lblStepPoints = new System.Windows.Forms.Label();
            this.tb_StartPwr = new System.Windows.Forms.TextBox();
            this.radioBtnFreqStep = new System.Windows.Forms.RadioButton();
            this.radioBtnPwrStep = new System.Windows.Forms.RadioButton();
            this.lblStartPwr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_StopPwr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfigSigGen = new System.Windows.Forms.Button();
            this.chkboxConfig_SigGen = new System.Windows.Forms.CheckBox();
            this.rchTB_SigGenConfigReadout = new System.Windows.Forms.RichTextBox();
            this.tb_PwrStepSize = new System.Windows.Forms.TextBox();
            this.lblPwrStep = new System.Windows.Forms.Label();
            this.tb_TriggerCount = new System.Windows.Forms.TextBox();
            this.lblTriggerCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rchTB_DMMConfigReadout = new System.Windows.Forms.RichTextBox();
            this.rchTB_OutputDmmESG = new System.Windows.Forms.RichTextBox();
            this.tb_FreqStep = new System.Windows.Forms.TextBox();
            this.lblFreqStep = new System.Windows.Forms.Label();
            this.btnRFOutput = new System.Windows.Forms.Button();
            this.btnFetchReadTest = new System.Windows.Forms.Button();
            this.btnFrmBigChartTestDT_Test = new System.Windows.Forms.Button();
            this.lblESGAmpl = new System.Windows.Forms.Label();
            this.tb_ESGpwr = new System.Windows.Forms.TextBox();
            this.tb_ESGFreq = new System.Windows.Forms.TextBox();
            this.lblESGFreq = new System.Windows.Forms.Label();
            this.chkBox_Measure = new System.Windows.Forms.CheckBox();
            this.btn_ClearTDTs = new System.Windows.Forms.Button();
            this.btn_WriteTDTsTest = new System.Windows.Forms.Button();
            this.btnReadInBatch = new System.Windows.Forms.Button();
            this.btnCalFileToSpecificTest = new System.Windows.Forms.Button();
            this.rchTB_CalTest = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnPlotCal = new System.Windows.Forms.Button();
            this.RichTxtBoxOutput = new System.Windows.Forms.RichTextBox();
            this.RchTxtBoxMeasurement = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxVisaID
            // 
            this.txtBoxVisaID.Location = new System.Drawing.Point(101, 41);
            this.txtBoxVisaID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxVisaID.Name = "txtBoxVisaID";
            this.txtBoxVisaID.Size = new System.Drawing.Size(296, 26);
            this.txtBoxVisaID.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 35);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open/Init ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "DMM VISA ID:";
            // 
            // chkBox34401Open
            // 
            this.chkBox34401Open.AutoSize = true;
            this.chkBox34401Open.Location = new System.Drawing.Point(383, 45);
            this.chkBox34401Open.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBox34401Open.Name = "chkBox34401Open";
            this.chkBox34401Open.Size = new System.Drawing.Size(22, 21);
            this.chkBox34401Open.TabIndex = 3;
            this.chkBox34401Open.UseVisualStyleBackColor = true;
            // 
            // btnConfigure
            // 
            this.btnConfigure.Location = new System.Drawing.Point(566, 34);
            this.btnConfigure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(122, 31);
            this.btnConfigure.TabIndex = 5;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // chkboxConfigure
            // 
            this.chkboxConfigure.AutoSize = true;
            this.chkboxConfigure.Location = new System.Drawing.Point(544, 40);
            this.chkboxConfigure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkboxConfigure.Name = "chkboxConfigure";
            this.chkboxConfigure.Size = new System.Drawing.Size(22, 21);
            this.chkboxConfigure.TabIndex = 14;
            this.chkboxConfigure.UseVisualStyleBackColor = true;
            // 
            // chkBoxMakeMeasurement
            // 
            this.chkBoxMakeMeasurement.AutoSize = true;
            this.chkBoxMakeMeasurement.Location = new System.Drawing.Point(596, 71);
            this.chkBoxMakeMeasurement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBoxMakeMeasurement.Name = "chkBoxMakeMeasurement";
            this.chkBoxMakeMeasurement.Size = new System.Drawing.Size(22, 21);
            this.chkBoxMakeMeasurement.TabIndex = 15;
            this.chkBoxMakeMeasurement.UseVisualStyleBackColor = true;
            // 
            // chkBoxOutputResults
            // 
            this.chkBoxOutputResults.AutoSize = true;
            this.chkBoxOutputResults.Location = new System.Drawing.Point(566, 71);
            this.chkBoxOutputResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBoxOutputResults.Name = "chkBoxOutputResults";
            this.chkBoxOutputResults.Size = new System.Drawing.Size(22, 21);
            this.chkBoxOutputResults.TabIndex = 16;
            this.chkBoxOutputResults.UseVisualStyleBackColor = true;
            // 
            // lbl_RFsigGenOpenInit
            // 
            this.lbl_RFsigGenOpenInit.AutoSize = true;
            this.lbl_RFsigGenOpenInit.Location = new System.Drawing.Point(-78, 112);
            this.lbl_RFsigGenOpenInit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_RFsigGenOpenInit.Name = "lbl_RFsigGenOpenInit";
            this.lbl_RFsigGenOpenInit.Size = new System.Drawing.Size(0, 20);
            this.lbl_RFsigGenOpenInit.TabIndex = 18;
            // 
            // txtBox_RFSigGenVisaID
            // 
            this.txtBox_RFSigGenVisaID.Location = new System.Drawing.Point(133, 79);
            this.txtBox_RFSigGenVisaID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBox_RFSigGenVisaID.Name = "txtBox_RFSigGenVisaID";
            this.txtBox_RFSigGenVisaID.Size = new System.Drawing.Size(259, 26);
            this.txtBox_RFSigGenVisaID.TabIndex = 19;
            // 
            // lblRFSigGenVisaID
            // 
            this.lblRFSigGenVisaID.AutoSize = true;
            this.lblRFSigGenVisaID.Location = new System.Drawing.Point(18, 82);
            this.lblRFSigGenVisaID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRFSigGenVisaID.Name = "lblRFSigGenVisaID";
            this.lblRFSigGenVisaID.Size = new System.Drawing.Size(111, 20);
            this.lblRFSigGenVisaID.TabIndex = 20;
            this.lblRFSigGenVisaID.Text = "ESG VISA ID:";
            // 
            // btnRFSigGenOpenInit
            // 
            this.btnRFSigGenOpenInit.Location = new System.Drawing.Point(405, 79);
            this.btnRFSigGenOpenInit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRFSigGenOpenInit.Name = "btnRFSigGenOpenInit";
            this.btnRFSigGenOpenInit.Size = new System.Drawing.Size(135, 31);
            this.btnRFSigGenOpenInit.TabIndex = 21;
            this.btnRFSigGenOpenInit.Text = "Open/Init ";
            this.btnRFSigGenOpenInit.UseVisualStyleBackColor = true;
            this.btnRFSigGenOpenInit.Click += new System.EventHandler(this.btnRFSigGenOpenInit_Click);
            // 
            // chkBox_RFSigGenOpenInit
            // 
            this.chkBox_RFSigGenOpenInit.AutoSize = true;
            this.chkBox_RFSigGenOpenInit.Location = new System.Drawing.Point(379, 83);
            this.chkBox_RFSigGenOpenInit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBox_RFSigGenOpenInit.Name = "chkBox_RFSigGenOpenInit";
            this.chkBox_RFSigGenOpenInit.Size = new System.Drawing.Size(22, 21);
            this.chkBox_RFSigGenOpenInit.TabIndex = 22;
            this.chkBox_RFSigGenOpenInit.UseVisualStyleBackColor = true;
            // 
            // TB_startFreq
            // 
            this.TB_startFreq.Location = new System.Drawing.Point(106, 125);
            this.TB_startFreq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_startFreq.Name = "TB_startFreq";
            this.TB_startFreq.Size = new System.Drawing.Size(82, 26);
            this.TB_startFreq.TabIndex = 23;
            // 
            // lblStartFreq
            // 
            this.lblStartFreq.AutoSize = true;
            this.lblStartFreq.Location = new System.Drawing.Point(19, 132);
            this.lblStartFreq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartFreq.Name = "lblStartFreq";
            this.lblStartFreq.Size = new System.Drawing.Size(85, 20);
            this.lblStartFreq.TabIndex = 24;
            this.lblStartFreq.Text = "Start Freq:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Stop Freq:";
            // 
            // TB_StopFreq
            // 
            this.TB_StopFreq.Location = new System.Drawing.Point(106, 163);
            this.TB_StopFreq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_StopFreq.Name = "TB_StopFreq";
            this.TB_StopFreq.Size = new System.Drawing.Size(82, 26);
            this.TB_StopFreq.TabIndex = 26;
            // 
            // TB_NumberOfPoints
            // 
            this.TB_NumberOfPoints.Location = new System.Drawing.Point(253, 195);
            this.TB_NumberOfPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_NumberOfPoints.Name = "TB_NumberOfPoints";
            this.TB_NumberOfPoints.Size = new System.Drawing.Size(39, 26);
            this.TB_NumberOfPoints.TabIndex = 27;
            // 
            // lblStepPoints
            // 
            this.lblStepPoints.AutoSize = true;
            this.lblStepPoints.Location = new System.Drawing.Point(198, 199);
            this.lblStepPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStepPoints.Name = "lblStepPoints";
            this.lblStepPoints.Size = new System.Drawing.Size(49, 20);
            this.lblStepPoints.TabIndex = 28;
            this.lblStepPoints.Text = "# Pts:";
            this.lblStepPoints.Click += new System.EventHandler(this.lblStepPoints_Click);
            // 
            // tb_StartPwr
            // 
            this.tb_StartPwr.Location = new System.Drawing.Point(379, 133);
            this.tb_StartPwr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_StartPwr.Name = "tb_StartPwr";
            this.tb_StartPwr.Size = new System.Drawing.Size(54, 26);
            this.tb_StartPwr.TabIndex = 29;
            // 
            // radioBtnFreqStep
            // 
            this.radioBtnFreqStep.AutoSize = true;
            this.radioBtnFreqStep.Location = new System.Drawing.Point(223, 132);
            this.radioBtnFreqStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnFreqStep.Name = "radioBtnFreqStep";
            this.radioBtnFreqStep.Size = new System.Drawing.Size(67, 24);
            this.radioBtnFreqStep.TabIndex = 30;
            this.radioBtnFreqStep.TabStop = true;
            this.radioBtnFreqStep.Text = "Freq";
            this.radioBtnFreqStep.UseVisualStyleBackColor = true;
            // 
            // radioBtnPwrStep
            // 
            this.radioBtnPwrStep.AutoSize = true;
            this.radioBtnPwrStep.Location = new System.Drawing.Point(223, 166);
            this.radioBtnPwrStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnPwrStep.Name = "radioBtnPwrStep";
            this.radioBtnPwrStep.Size = new System.Drawing.Size(70, 24);
            this.radioBtnPwrStep.TabIndex = 31;
            this.radioBtnPwrStep.TabStop = true;
            this.radioBtnPwrStep.Text = "Ampl";
            this.radioBtnPwrStep.UseVisualStyleBackColor = true;
            // 
            // lblStartPwr
            // 
            this.lblStartPwr.AutoSize = true;
            this.lblStartPwr.Location = new System.Drawing.Point(306, 135);
            this.lblStartPwr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartPwr.Name = "lblStartPwr";
            this.lblStartPwr.Size = new System.Drawing.Size(78, 20);
            this.lblStartPwr.TabIndex = 32;
            this.lblStartPwr.Text = "Start Pwr:";
            this.lblStartPwr.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Stop Pwr:";
            // 
            // tb_StopPwr
            // 
            this.tb_StopPwr.Location = new System.Drawing.Point(379, 166);
            this.tb_StopPwr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_StopPwr.Name = "tb_StopPwr";
            this.tb_StopPwr.Size = new System.Drawing.Size(54, 26);
            this.tb_StopPwr.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-78, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Configure";
            // 
            // btnConfigSigGen
            // 
            this.btnConfigSigGen.Location = new System.Drawing.Point(470, 144);
            this.btnConfigSigGen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfigSigGen.Name = "btnConfigSigGen";
            this.btnConfigSigGen.Size = new System.Drawing.Size(116, 31);
            this.btnConfigSigGen.TabIndex = 36;
            this.btnConfigSigGen.Text = "Configure";
            this.btnConfigSigGen.UseVisualStyleBackColor = true;
            this.btnConfigSigGen.Click += new System.EventHandler(this.btnConfigSigGen_Click);
            // 
            // chkboxConfig_SigGen
            // 
            this.chkboxConfig_SigGen.AutoSize = true;
            this.chkboxConfig_SigGen.Location = new System.Drawing.Point(440, 144);
            this.chkboxConfig_SigGen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkboxConfig_SigGen.Name = "chkboxConfig_SigGen";
            this.chkboxConfig_SigGen.Size = new System.Drawing.Size(22, 21);
            this.chkboxConfig_SigGen.TabIndex = 37;
            this.chkboxConfig_SigGen.UseVisualStyleBackColor = true;
            // 
            // rchTB_SigGenConfigReadout
            // 
            this.rchTB_SigGenConfigReadout.Location = new System.Drawing.Point(695, 146);
            this.rchTB_SigGenConfigReadout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rchTB_SigGenConfigReadout.Name = "rchTB_SigGenConfigReadout";
            this.rchTB_SigGenConfigReadout.Size = new System.Drawing.Size(442, 130);
            this.rchTB_SigGenConfigReadout.TabIndex = 38;
            this.rchTB_SigGenConfigReadout.Text = "";
            // 
            // tb_PwrStepSize
            // 
            this.tb_PwrStepSize.Location = new System.Drawing.Point(383, 200);
            this.tb_PwrStepSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_PwrStepSize.Name = "tb_PwrStepSize";
            this.tb_PwrStepSize.Size = new System.Drawing.Size(50, 26);
            this.tb_PwrStepSize.TabIndex = 39;
            // 
            // lblPwrStep
            // 
            this.lblPwrStep.AutoSize = true;
            this.lblPwrStep.Location = new System.Drawing.Point(306, 202);
            this.lblPwrStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPwrStep.Name = "lblPwrStep";
            this.lblPwrStep.Size = new System.Drawing.Size(77, 20);
            this.lblPwrStep.TabIndex = 40;
            this.lblPwrStep.Text = "Pwr Step:";
            // 
            // tb_TriggerCount
            // 
            this.tb_TriggerCount.Location = new System.Drawing.Point(647, 7);
            this.tb_TriggerCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_TriggerCount.Name = "tb_TriggerCount";
            this.tb_TriggerCount.Size = new System.Drawing.Size(54, 26);
            this.tb_TriggerCount.TabIndex = 41;
            // 
            // lblTriggerCount
            // 
            this.lblTriggerCount.AutoSize = true;
            this.lblTriggerCount.Location = new System.Drawing.Point(540, 9);
            this.lblTriggerCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTriggerCount.Name = "lblTriggerCount";
            this.lblTriggerCount.Size = new System.Drawing.Size(109, 20);
            this.lblTriggerCount.TabIndex = 42;
            this.lblTriggerCount.Text = "Trigger Count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "34401a DMM SECTION";
            // 
            // rchTB_DMMConfigReadout
            // 
            this.rchTB_DMMConfigReadout.Location = new System.Drawing.Point(695, 34);
            this.rchTB_DMMConfigReadout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rchTB_DMMConfigReadout.Name = "rchTB_DMMConfigReadout";
            this.rchTB_DMMConfigReadout.Size = new System.Drawing.Size(442, 102);
            this.rchTB_DMMConfigReadout.TabIndex = 44;
            this.rchTB_DMMConfigReadout.Text = "";
            this.rchTB_DMMConfigReadout.TextChanged += new System.EventHandler(this.rchTB_DMMConfigReadout_TextChanged);
            // 
            // rchTB_OutputDmmESG
            // 
            this.rchTB_OutputDmmESG.Location = new System.Drawing.Point(325, 338);
            this.rchTB_OutputDmmESG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rchTB_OutputDmmESG.Name = "rchTB_OutputDmmESG";
            this.rchTB_OutputDmmESG.Size = new System.Drawing.Size(293, 118);
            this.rchTB_OutputDmmESG.TabIndex = 48;
            this.rchTB_OutputDmmESG.Text = "";
            // 
            // tb_FreqStep
            // 
            this.tb_FreqStep.Location = new System.Drawing.Point(106, 202);
            this.tb_FreqStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_FreqStep.Name = "tb_FreqStep";
            this.tb_FreqStep.Size = new System.Drawing.Size(82, 26);
            this.tb_FreqStep.TabIndex = 49;
            // 
            // lblFreqStep
            // 
            this.lblFreqStep.AutoSize = true;
            this.lblFreqStep.Location = new System.Drawing.Point(19, 206);
            this.lblFreqStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFreqStep.Name = "lblFreqStep";
            this.lblFreqStep.Size = new System.Drawing.Size(84, 20);
            this.lblFreqStep.TabIndex = 50;
            this.lblFreqStep.Text = "Freq Step:";
            // 
            // btnRFOutput
            // 
            this.btnRFOutput.Location = new System.Drawing.Point(477, 236);
            this.btnRFOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRFOutput.Name = "btnRFOutput";
            this.btnRFOutput.Size = new System.Drawing.Size(109, 32);
            this.btnRFOutput.TabIndex = 53;
            this.btnRFOutput.Text = "RF OFF";
            this.btnRFOutput.UseVisualStyleBackColor = true;
            this.btnRFOutput.Click += new System.EventHandler(this.btnRFOutput_Click_1);
            // 
            // btnFetchReadTest
            // 
            this.btnFetchReadTest.Location = new System.Drawing.Point(470, 188);
            this.btnFetchReadTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFetchReadTest.Name = "btnFetchReadTest";
            this.btnFetchReadTest.Size = new System.Drawing.Size(116, 31);
            this.btnFetchReadTest.TabIndex = 56;
            this.btnFetchReadTest.Text = "MEASURE";
            this.btnFetchReadTest.UseVisualStyleBackColor = true;
            this.btnFetchReadTest.Click += new System.EventHandler(this.btnFetchReadTest_Click);
            // 
            // btnFrmBigChartTestDT_Test
            // 
            this.btnFrmBigChartTestDT_Test.Location = new System.Drawing.Point(637, 422);
            this.btnFrmBigChartTestDT_Test.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFrmBigChartTestDT_Test.Name = "btnFrmBigChartTestDT_Test";
            this.btnFrmBigChartTestDT_Test.Size = new System.Drawing.Size(183, 31);
            this.btnFrmBigChartTestDT_Test.TabIndex = 59;
            this.btnFrmBigChartTestDT_Test.Text = "Test TDT Plotting";
            this.btnFrmBigChartTestDT_Test.UseVisualStyleBackColor = true;
            this.btnFrmBigChartTestDT_Test.Click += new System.EventHandler(this.btnFrmBigChartTestDT_Test_Click);
            // 
            // lblESGAmpl
            // 
            this.lblESGAmpl.AutoSize = true;
            this.lblESGAmpl.Location = new System.Drawing.Point(19, 243);
            this.lblESGAmpl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblESGAmpl.Name = "lblESGAmpl";
            this.lblESGAmpl.Size = new System.Drawing.Size(82, 20);
            this.lblESGAmpl.TabIndex = 60;
            this.lblESGAmpl.Text = "Pwr(dBm):";
            // 
            // tb_ESGpwr
            // 
            this.tb_ESGpwr.Location = new System.Drawing.Point(106, 239);
            this.tb_ESGpwr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ESGpwr.Name = "tb_ESGpwr";
            this.tb_ESGpwr.Size = new System.Drawing.Size(82, 26);
            this.tb_ESGpwr.TabIndex = 61;
            // 
            // tb_ESGFreq
            // 
            this.tb_ESGFreq.Location = new System.Drawing.Point(371, 237);
            this.tb_ESGFreq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ESGFreq.Name = "tb_ESGFreq";
            this.tb_ESGFreq.Size = new System.Drawing.Size(62, 26);
            this.tb_ESGFreq.TabIndex = 62;
            // 
            // lblESGFreq
            // 
            this.lblESGFreq.AutoSize = true;
            this.lblESGFreq.Location = new System.Drawing.Point(287, 244);
            this.lblESGFreq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblESGFreq.Name = "lblESGFreq";
            this.lblESGFreq.Size = new System.Drawing.Size(89, 20);
            this.lblESGFreq.TabIndex = 63;
            this.lblESGFreq.Text = "Freq(GHz):";
            // 
            // chkBox_Measure
            // 
            this.chkBox_Measure.AutoSize = true;
            this.chkBox_Measure.Location = new System.Drawing.Point(440, 194);
            this.chkBox_Measure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBox_Measure.Name = "chkBox_Measure";
            this.chkBox_Measure.Size = new System.Drawing.Size(22, 21);
            this.chkBox_Measure.TabIndex = 64;
            this.chkBox_Measure.UseVisualStyleBackColor = true;
            // 
            // btn_ClearTDTs
            // 
            this.btn_ClearTDTs.Location = new System.Drawing.Point(637, 381);
            this.btn_ClearTDTs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ClearTDTs.Name = "btn_ClearTDTs";
            this.btn_ClearTDTs.Size = new System.Drawing.Size(183, 31);
            this.btn_ClearTDTs.TabIndex = 66;
            this.btn_ClearTDTs.Text = "Clear_TDTs";
            this.btn_ClearTDTs.UseVisualStyleBackColor = true;
            this.btn_ClearTDTs.Click += new System.EventHandler(this.btn_ClearTDTs_Click);
            // 
            // btn_WriteTDTsTest
            // 
            this.btn_WriteTDTsTest.Location = new System.Drawing.Point(637, 336);
            this.btn_WriteTDTsTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_WriteTDTsTest.Name = "btn_WriteTDTsTest";
            this.btn_WriteTDTsTest.Size = new System.Drawing.Size(183, 31);
            this.btn_WriteTDTsTest.TabIndex = 67;
            this.btn_WriteTDTsTest.Text = "Write_TDTs";
            this.btn_WriteTDTsTest.UseVisualStyleBackColor = true;
            this.btn_WriteTDTsTest.Click += new System.EventHandler(this.btn_WriteTDTsTest_Click);
            // 
            // btnReadInBatch
            // 
            this.btnReadInBatch.Location = new System.Drawing.Point(101, 282);
            this.btnReadInBatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadInBatch.Name = "btnReadInBatch";
            this.btnReadInBatch.Size = new System.Drawing.Size(183, 27);
            this.btnReadInBatch.TabIndex = 68;
            this.btnReadInBatch.Text = "BATCH MEASURE";
            this.btnReadInBatch.UseVisualStyleBackColor = true;
            this.btnReadInBatch.Click += new System.EventHandler(this.btnReadInBatch_Click);
            // 
            // btnCalFileToSpecificTest
            // 
            this.btnCalFileToSpecificTest.Location = new System.Drawing.Point(637, 467);
            this.btnCalFileToSpecificTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalFileToSpecificTest.Name = "btnCalFileToSpecificTest";
            this.btnCalFileToSpecificTest.Size = new System.Drawing.Size(210, 31);
            this.btnCalFileToSpecificTest.TabIndex = 69;
            this.btnCalFileToSpecificTest.Text = "Cal File to Specifc Array";
            this.btnCalFileToSpecificTest.UseVisualStyleBackColor = true;
            this.btnCalFileToSpecificTest.Click += new System.EventHandler(this.btnCalFileToSpecificTest_Click);
            // 
            // rchTB_CalTest
            // 
            this.rchTB_CalTest.Location = new System.Drawing.Point(325, 467);
            this.rchTB_CalTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rchTB_CalTest.Name = "rchTB_CalTest";
            this.rchTB_CalTest.Size = new System.Drawing.Size(215, 170);
            this.rchTB_CalTest.TabIndex = 70;
            this.rchTB_CalTest.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Load Cal File|*.cal";
            this.openFileDialog1.InitialDirectory = "C:\\ATSRF\\DATA";
            this.openFileDialog1.Title = "Select Output Cal File (XCM*.cal)";
            // 
            // btnPlotCal
            // 
            this.btnPlotCal.Location = new System.Drawing.Point(637, 508);
            this.btnPlotCal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlotCal.Name = "btnPlotCal";
            this.btnPlotCal.Size = new System.Drawing.Size(210, 31);
            this.btnPlotCal.TabIndex = 71;
            this.btnPlotCal.Text = "Plot Cal";
            this.btnPlotCal.UseVisualStyleBackColor = true;
            this.btnPlotCal.Click += new System.EventHandler(this.btnPlotCal_Click);
            // 
            // RichTxtBoxOutput
            // 
            this.RichTxtBoxOutput.Location = new System.Drawing.Point(13, 467);
            this.RichTxtBoxOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RichTxtBoxOutput.Name = "RichTxtBoxOutput";
            this.RichTxtBoxOutput.Size = new System.Drawing.Size(293, 179);
            this.RichTxtBoxOutput.TabIndex = 73;
            this.RichTxtBoxOutput.Text = "";
            // 
            // RchTxtBoxMeasurement
            // 
            this.RchTxtBoxMeasurement.Location = new System.Drawing.Point(13, 338);
            this.RchTxtBoxMeasurement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RchTxtBoxMeasurement.Name = "RchTxtBoxMeasurement";
            this.RchTxtBoxMeasurement.Size = new System.Drawing.Size(293, 118);
            this.RchTxtBoxMeasurement.TabIndex = 72;
            this.RchTxtBoxMeasurement.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 289);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 20);
            this.label6.TabIndex = 76;
            this.label6.Text = "Perform measurement(s) defined in textfile";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 289);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 77;
            this.label7.Text = "C:\\results\\testBatch.txt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(828, 341);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(327, 20);
            this.label8.TabIndex = 78;
            this.label8.Text = "Write In-Memory TestData to  file in C:\\results";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(828, 381);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 20);
            this.label9.TabIndex = 79;
            this.label9.Text = "Clear/Empty  In-Memory TestData ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(855, 478);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(396, 20);
            this.label10.TabIndex = 80;
            this.label10.Text = "Parse cal file into array of same #pts and freq for config";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(855, 513);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(349, 20);
            this.label11.TabIndex = 81;
            this.label11.Text = "Plot the cal created for conifgured measurement";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(828, 427);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(357, 20);
            this.label12.TabIndex = 82;
            this.label12.Text = "Dev Tool to test TDT data Structure and graphing";
            // 
            // Frm34401test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 653);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RichTxtBoxOutput);
            this.Controls.Add(this.RchTxtBoxMeasurement);
            this.Controls.Add(this.btnPlotCal);
            this.Controls.Add(this.rchTB_CalTest);
            this.Controls.Add(this.btnCalFileToSpecificTest);
            this.Controls.Add(this.btnReadInBatch);
            this.Controls.Add(this.btn_WriteTDTsTest);
            this.Controls.Add(this.btn_ClearTDTs);
            this.Controls.Add(this.chkBox_Measure);
            this.Controls.Add(this.lblESGFreq);
            this.Controls.Add(this.tb_ESGFreq);
            this.Controls.Add(this.tb_ESGpwr);
            this.Controls.Add(this.lblESGAmpl);
            this.Controls.Add(this.btnFrmBigChartTestDT_Test);
            this.Controls.Add(this.btnFetchReadTest);
            this.Controls.Add(this.btnRFOutput);
            this.Controls.Add(this.lblFreqStep);
            this.Controls.Add(this.tb_FreqStep);
            this.Controls.Add(this.rchTB_OutputDmmESG);
            this.Controls.Add(this.rchTB_DMMConfigReadout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTriggerCount);
            this.Controls.Add(this.tb_TriggerCount);
            this.Controls.Add(this.lblPwrStep);
            this.Controls.Add(this.tb_PwrStepSize);
            this.Controls.Add(this.rchTB_SigGenConfigReadout);
            this.Controls.Add(this.chkboxConfig_SigGen);
            this.Controls.Add(this.btnConfigSigGen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_StopPwr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStartPwr);
            this.Controls.Add(this.radioBtnPwrStep);
            this.Controls.Add(this.radioBtnFreqStep);
            this.Controls.Add(this.tb_StartPwr);
            this.Controls.Add(this.lblStepPoints);
            this.Controls.Add(this.TB_NumberOfPoints);
            this.Controls.Add(this.TB_StopFreq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStartFreq);
            this.Controls.Add(this.TB_startFreq);
            this.Controls.Add(this.chkBox_RFSigGenOpenInit);
            this.Controls.Add(this.btnRFSigGenOpenInit);
            this.Controls.Add(this.lblRFSigGenVisaID);
            this.Controls.Add(this.txtBox_RFSigGenVisaID);
            this.Controls.Add(this.lbl_RFsigGenOpenInit);
            this.Controls.Add(this.chkBoxOutputResults);
            this.Controls.Add(this.chkBoxMakeMeasurement);
            this.Controls.Add(this.chkboxConfigure);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.chkBox34401Open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBoxVisaID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm34401test";
            this.Text = "RF Level Detector Diode Test App - BETA in DEV- ESG & DMM -- 200-0927-320 320-029" +
    "7-XXX G@EIRP.NET";
            this.Load += new System.EventHandler(this.Frm34401test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxVisaID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBox34401Open;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.CheckBox chkboxConfigure;
        private System.Windows.Forms.CheckBox chkBoxMakeMeasurement;
        private System.Windows.Forms.CheckBox chkBoxOutputResults;
        private System.Windows.Forms.Label lbl_RFsigGenOpenInit;
        private System.Windows.Forms.TextBox txtBox_RFSigGenVisaID;
        private System.Windows.Forms.Label lblRFSigGenVisaID;
        private System.Windows.Forms.Button btnRFSigGenOpenInit;
        private System.Windows.Forms.CheckBox chkBox_RFSigGenOpenInit;
        private System.Windows.Forms.TextBox TB_startFreq;
        private System.Windows.Forms.Label lblStartFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_StopFreq;
        private System.Windows.Forms.TextBox TB_NumberOfPoints;
        private System.Windows.Forms.Label lblStepPoints;
        private System.Windows.Forms.TextBox tb_StartPwr;
        private System.Windows.Forms.RadioButton radioBtnFreqStep;
        private System.Windows.Forms.RadioButton radioBtnPwrStep;
        private System.Windows.Forms.Label lblStartPwr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_StopPwr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfigSigGen;
        private System.Windows.Forms.CheckBox chkboxConfig_SigGen;
        private System.Windows.Forms.RichTextBox rchTB_SigGenConfigReadout;
        private System.Windows.Forms.TextBox tb_PwrStepSize;
        private System.Windows.Forms.Label lblPwrStep;
        private System.Windows.Forms.TextBox tb_TriggerCount;
        private System.Windows.Forms.Label lblTriggerCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rchTB_DMMConfigReadout;
        private System.Windows.Forms.RichTextBox rchTB_OutputDmmESG;
        private System.Windows.Forms.TextBox tb_FreqStep;
        private System.Windows.Forms.Label lblFreqStep;
        private System.Windows.Forms.Button btnRFOutput;
        private System.Windows.Forms.Button btnFetchReadTest;
        private System.Windows.Forms.Button btnFrmBigChartTestDT_Test;
        private System.Windows.Forms.Label lblESGAmpl;
        private System.Windows.Forms.TextBox tb_ESGpwr;
        private System.Windows.Forms.TextBox tb_ESGFreq;
        private System.Windows.Forms.Label lblESGFreq;
        private System.Windows.Forms.CheckBox chkBox_Measure;
        private System.Windows.Forms.Button btn_ClearTDTs;
        private System.Windows.Forms.Button btn_WriteTDTsTest;
        private System.Windows.Forms.Button btnReadInBatch;
        private System.Windows.Forms.Button btnCalFileToSpecificTest;
        private System.Windows.Forms.RichTextBox rchTB_CalTest;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnPlotCal;
        private System.Windows.Forms.RichTextBox RichTxtBoxOutput;
        private System.Windows.Forms.RichTextBox RchTxtBoxMeasurement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

