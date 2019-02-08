%format = absolute path of the folder containing the segmented signals
format = "/Users/JohnBoy/Desktop/Thesis Data/Windowed/New/";
%Name of the Test Subject and serves as the folder name
name = "Tetet"
%total = (total number of files inside the folder) - 1 
total = 393;

%--------------------------------------------------------------------------
%This part of the code averaged the data per column

function result = average(q) 
		result = sum(q)/length(q);
endfunction

out1 = strcat("averagedCSV-",name,".csv");
%Comment the out1 variable and uncomment out2 variable to compute for the average baseline
%out2 = strcat("averagedCSVBaseline-",name,".csv");

for n = 0:total,
	h = num2str(n);
	filename = strcat(format,name,"/",h,".csv");
	raw = csvread(filename);
	
	%Brainwaves Area
	brain = raw(:,6:19);
	
	for x = 1:columns(brain),
	
		column = brain(:,x);
		
		switch(x)
			case 1
				af3Avg = average(column);
			case 2
				f7Avg = average(column);
			case 3
				f3Avg = average(column);
			case 4
				fc5Avg = average(column);
			case 5
				t7Avg = average(column);
			case 6
				p7Avg = average(column);
			case 7
				o1Avg = average(column);
			case 8
				o2Avg = average(column);
			case 9
				p8Avg = average(column);
			case 10
				t8Avg = average(column);
			case 11
				fc6Avg = average(column);
			case 12
				f4Avg = average(column);
			case 13
				f8Avg = average(column);
			case 14
				af4Avg = average(column);
		endswitch	
	endfor
	
	%Mouse Area
	column = raw(:,33:35);
	for b = 1:columns(column),
		
		mouse = column(:,b);
		
		switch(b)			
			case 1
				clickAvg = average(mouse);
			case 2
				freqAvg = average(mouse);
			case 3
				duraAvg = average(mouse);
		endswitch
	endfor
	
	%Emotion Area
	col = raw(:,37:40);
	for b = 1:columns(col),
		
		emo = col(:,b);
		
		switch(b)			
			case 1
				confiAVG= average(emo);
			case 2
				exciAVG = average(emo);
			case 3
				inteAVG = average(emo);
			case 4
				frusAVG = average(emo);
		endswitch
	endfor
	
	avg = [af3Avg, f7Avg, f3Avg, fc5Avg, t7Avg, p7Avg, o1Avg, o2Avg, p8Avg, t8Avg, fc6Avg, f4Avg, f8Avg, af4Avg, clickAvg, freqAvg, duraAvg, confiAVG, exciAVG, inteAVG, frusAVG];
	
	dlmwrite(out1, avg, ",", "-append");
	%Comment the line above and uncomment the line below to save the averaged baseline
	%dlmwrite(out2, avg, ",", "-append");
endfor