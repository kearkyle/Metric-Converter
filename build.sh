echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo Compile Metricconverter.cs to create the file: Metricconverter.dll
mcs -target:library -out:Metricconverter.dll Metricconverter.cs

echo Compile Metricinterface.cs to create the file: Metricinterface.dll
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:Metricconverter.dll -out:Metricinterface.dll Metricinterface.cs

echo Compile Metricmain.cs and link the two previously created dll files to create an executable file. 
mcs -r:System -r:System.Windows.Forms -r:Metricinterface.dll -out:Metric.exe Metricmain.cs

echo View the list of files in the current folder
ls -l

echo Run the Assignment 1 program.
./Metric.exe

echo The script has terminated.
