%format1 = absolute path of the averagedCSV file
format1 = "/Users/JohnBoy/Desktop/Octave Scripts/averagedCSV-";
%format2 = absolute path of the averaged baseline
format2 = "/Users/JohnBoy/Desktop/Thesis Data/Processed Baseline/averagedCSVBaseline-";
%Name of the Test Subject and serves as the file name
name = "Tetet"

%--------------------------------------------------------------------------
%This code subtracts the baseline from the averaged signals per column

file1 = strcat(format1,name,".csv");
file2 = strcat(format2,name,".csv");
processed = load(file1);
baseline = load(file2);

baseAVG = baseline(:,15:28);
procAVG = processed(:,1:14);
mouseAVG = processed(:,15:17);
emo = processed(:,18:21);

for x = 1:14,

	switch(x)	
		case 1		
			af3AVG = baseAVG(:,x)-procAVG(:,x);
		case 2
			f7AVG = baseAVG(:,x)-procAVG(:,x);
		case 3
			f3AVG = baseAVG(:,x)-procAVG(:,x);
		case 4
			fc5AVG = baseAVG(:,x)-procAVG(:,x);
		case 5
			t7AVG = baseAVG(:,x)-procAVG(:,x);
		case 6
			p7AVG = baseAVG(:,x)-procAVG(:,x);
		case 7
			o1AVG = baseAVG(:,x)-procAVG(:,x);
		case 8
			o2AVG = baseAVG(:,x)-procAVG(:,x);
		case 9
			p8AVG = baseAVG(:,x)-procAVG(:,x);
		case 10
			t8AVG = baseAVG(:,x)-procAVG(:,x);
		case 11
			fc6AVG = baseAVG(:,x)-procAVG(:,x);
		case 12
			f4AVG = baseAVG(:,x)-procAVG(:,x);
		case 13
			f8AVG = baseAVG(:,x)-procAVG(:,x);
		case 14
			af4AVG = baseAVG(:,x)-procAVG(:,x);
	endswitch
endfor

label2 = [af3AVG, f7AVG, f3AVG, fc5AVG, t7AVG, p7AVG, o1AVG, o2AVG, p8AVG, t8AVG, fc6AVG, f4AVG, f8AVG, af4AVG,mouseAVG,emo];

output = strcat("subtractCSV-",name,".csv");
csvwrite(output, label2);
