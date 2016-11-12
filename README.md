# 34401test_withPlotCal
34401Test_withPlotCal push from ZenBook 
C# Visa 34401 DVM, External Trigger, to Array with ESG sigGen Sweep Trigger out to DVM
Setup: 34401 connected via GPIB, ESG connected via ENET(TCP/IP). 
Trigger out on ESG is connect to External Trigger of DVM via bnc. 

Required: Agilent(Keysight) VISA or NI VISA library as the code accesses by VISA resource ID.
VS and C# on WIN7 box was used to create the application.

Basic Purpose: ESG is commanded to perform a freq or power sweep with 20-25ms dwells at each step. A square wave identifies each
step in the swept. THe RF output from the ESG is connected to a RF-to-DC detector. 
The DC output from detector is connected to the DVM. The DVM is triggered by the square wave and measure voltage for each step 
in the sweep and place the measurement in the buffer.

Results are pulled from the DVM into an array and plotted using chart object.
Mutliple tests can be identified in a text file then the set of test performed unattended. 
Results are written to a text file as CSV for easy importing into other apps like excel. 
Sort of a simple test sequencer. Using the trigger output from ESGs and the power/freq step feature
is often overlooked, but fast swept scalar measurements can be performed with realtime monitoring. 
Hopefully shares some ideas.
