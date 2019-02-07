function DataPointBuilder(baselineFile,erpFiles,user,userid,profile,emoanno)
%DataPointBuilder Removes (subtracts) the baseline from the ERP.
%
    %% Import the baseline file.
    [fPath, fName, fExt] = fileparts(baselineFile);
    %header = GetCsvHeaders(baseline,2);
    bFeatures = ImportEegFeatures(baselineFile,2,2);
    disp('Importing baseline...');
    
    %% Create save path.
    basePath = pwd;
    cd(fPath);
    cd ..;
    if ~exist('05 DataPoints','dir')
        mkdir('05 DataPoints');
    end
    cd('05 DataPoints');
    savePath = pwd;
    cd(basePath);
    disp(['savePath: ' savePath])
    
    disp('Building data points...');
    %% For each ERP file, build its data point
    for i = 1 : length(erpFiles)
        erp = char(erpFiles(i));
        disp(['     Current file: ' erp '...']);
        
        % Create output filename
        [~, fileName, fileExt] = fileparts(erp);
        temp = strsplit(fileName,'_');
        saveFile = strcat(savePath,'\',user,'_',char(strcat(temp(1),'_',temp(2))),'_datapoint',fileExt);
        
        % Get the segment number and window number
        sw = sscanf(fileName, 'S%u_W%u');
        
        % Get the EmoAnno row based on the segment number
        % PL,AT,SE,AP,FR_EV,FR_NA,FR_AE,FR_O,IS_STR
        % Transform the -3 to -1/+1 to +3 into low(0)/high(1)
        emo = emoanno(sw(1),:);
        for j = 1:length(emo)
            if emo(j) > 0
                emo(j) = 1;
            else
                emo(j) = 0;
            end
        end

        % Import ERP file
        eFeatures = ImportEegFeatures(erp,2,2);
        
        % Get data point
        datapoint = bFeatures - eFeatures;
        
        % Build row // ID SEG WIN EM RP DP
        saveRow = [userid transpose(sw) emo profile datapoint];

        % Save data point in a file
        dlmwrite(saveFile, saveRow, 'delimiter', ',', 'precision', 16);
        
        % Copy file to 'DataPoints' folder
        copyfile(saveFile, '_DataPoints');
    end
    
    disp('Finished building data points...');
end