function BuildDataset(saveFilename)
%BuildDataset This function builds the dataset file based on the contents
%of '_DataPoints' folder. It imports the files, normalizes the values, then
%saves it in one file specified in the 'saveFilename' parameter.
    
    H = {'USER' 'SEG', 'WIN', 'CLASS_PLEASANTNESS', 'CLASS_ATTENTION', 'CLASS_SENSITIVITY', 'CLASS_APPTITUDE', 'FROM_EVALUATIVE', 'FROM_NARRATIVE', 'FROM_AESTHETIC', 'FROM_OTHERS', 'IS_STRIKING', 'SEX', 'READ_FREQ_1', 'READ_FREQ_2', 'READ_FREQ_3', 'READ_FREQ_4', 'READ_PREF_1', 'READ_PREF_2', 'READ_PREF_3', 'READ_PREF_4', 'READ_PREF_5', 'READ_TYPE', 'GENRE_ABM', 'GENRE_CHL', 'GENRE_CLC', 'GENRE_CGN', 'GENRE_CDM', 'GENRE_ESS', 'GENRE_FLM', 'GENRE_FAN', 'GENRE_HFC', 'GENRE_HOR', 'GENRE_HUM', 'GENRE_POE', 'GENRE_ROM', 'GENRE_SCF', 'GENRE_SHS', 'GENRE_STH', 'GENRE_NFC', 'theta_AF3_minMag', 'theta_AF3_maxMag', 'theta_AF3_avgMag', 'theta_AF3_minPSD', 'theta_AF3_maxPSD', 'theta_AF3_avgPSD', 'theta_T7_minMag', 'theta_T7_maxMag', 'theta_T7_avgMag', 'theta_T7_minPSD', 'theta_T7_maxPSD', 'theta_T7_avgPSD', 'theta_Pz_minMag', 'theta_Pz_maxMag', 'theta_Pz_avgMag', 'theta_Pz_minPSD', 'theta_Pz_maxPSD', 'theta_Pz_avgPSD', 'theta_T8_minMag', 'theta_T8_maxMag', 'theta_T8_avgMag', 'theta_T8_minPSD', 'theta_T8_maxPSD', 'theta_T8_avgPSD', 'theta_AF4_minMag', 'theta_AF4_maxMag', 'theta_AF4_avgMag', 'theta_AF4_minPSD', 'theta_AF4_maxPSD', 'theta_AF4_avgPSD', 'theta_AF_minDASM', 'theta_AF_maxDASM', 'theta_AF_avgDASM', 'theta_AF_minRASM', 'theta_AF_maxRASM', 'theta_AF_avgRASM', 'theta_T_minDASM', 'theta_T_maxDASM', 'theta_T_avgDASM', 'theta_T_minRASM', 'theta_T_maxRASM', 'theta_T_avgRASM', 'alpha_AF3_minMag', 'alpha_AF3_maxMag', 'alpha_AF3_avgMag', 'alpha_AF3_minPSD', 'alpha_AF3_maxPSD', 'alpha_AF3_avgPSD', 'alpha_T7_minMag', 'alpha_T7_maxMag', 'alpha_T7_avgMag', 'alpha_T7_minPSD', 'alpha_T7_maxPSD', 'alpha_T7_avgPSD', 'alpha_Pz_minMag', 'alpha_Pz_maxMag', 'alpha_Pz_avgMag', 'alpha_Pz_minPSD', 'alpha_Pz_maxPSD', 'alpha_Pz_avgPSD', 'alpha_T8_minMag', 'alpha_T8_maxMag', 'alpha_T8_avgMag', 'alpha_T8_minPSD', 'alpha_T8_maxPSD', 'alpha_T8_avgPSD', 'alpha_AF4_minMag', 'alpha_AF4_maxMag', 'alpha_AF4_avgMag', 'alpha_AF4_minPSD', 'alpha_AF4_maxPSD', 'alpha_AF4_avgPSD', 'alpha_AF_minDASM', 'alpha_AF_maxDASM', 'alpha_AF_avgDASM', 'alpha_AF_minRASM', 'alpha_AF_maxRASM', 'alpha_AF_avgRASM', 'alpha_T_minDASM', 'alpha_T_maxDASM', 'alpha_T_avgDASM', 'alpha_T_minRASM', 'alpha_T_maxRASM', 'alpha_T_avgRASM', 'betaLo_AF3_minMag', 'betaLo_AF3_maxMag', 'betaLo_AF3_avgMag', 'betaLo_AF3_minPSD', 'betaLo_AF3_maxPSD', 'betaLo_AF3_avgPSD', 'betaLo_T7_minMag', 'betaLo_T7_maxMag', 'betaLo_T7_avgMag', 'betaLo_T7_minPSD', 'betaLo_T7_maxPSD', 'betaLo_T7_avgPSD', 'betaLo_Pz_minMag', 'betaLo_Pz_maxMag', 'betaLo_Pz_avgMag', 'betaLo_Pz_minPSD', 'betaLo_Pz_maxPSD', 'betaLo_Pz_avgPSD', 'betaLo_T8_minMag', 'betaLo_T8_maxMag', 'betaLo_T8_avgMag', 'betaLo_T8_minPSD', 'betaLo_T8_maxPSD', 'betaLo_T8_avgPSD', 'betaLo_AF4_minMag', 'betaLo_AF4_maxMag', 'betaLo_AF4_avgMag', 'betaLo_AF4_minPSD', 'betaLo_AF4_maxPSD', 'betaLo_AF4_avgPSD', 'betaLo_AF_minDASM', 'betaLo_AF_maxDASM', 'betaLo_AF_avgDASM', 'betaLo_AF_minRASM', 'betaLo_AF_maxRASM', 'betaLo_AF_avgRASM', 'betaLo_T_minDASM', 'betaLo_T_maxDASM', 'betaLo_T_avgDASM', 'betaLo_T_minRASM', 'betaLo_T_maxRASM', 'betaLo_T_avgRASM', 'betaMd_AF3_minMag', 'betaMd_AF3_maxMag', 'betaMd_AF3_avgMag', 'betaMd_AF3_minPSD', 'betaMd_AF3_maxPSD', 'betaMd_AF3_avgPSD', 'betaMd_T7_minMag', 'betaMd_T7_maxMag', 'betaMd_T7_avgMag', 'betaMd_T7_minPSD', 'betaMd_T7_maxPSD', 'betaMd_T7_avgPSD', 'betaMd_Pz_minMag', 'betaMd_Pz_maxMag', 'betaMd_Pz_avgMag', 'betaMd_Pz_minPSD', 'betaMd_Pz_maxPSD', 'betaMd_Pz_avgPSD', 'betaMd_T8_minMag', 'betaMd_T8_maxMag', 'betaMd_T8_avgMag', 'betaMd_T8_minPSD', 'betaMd_T8_maxPSD', 'betaMd_T8_avgPSD', 'betaMd_AF4_minMag', 'betaMd_AF4_maxMag', 'betaMd_AF4_avgMag', 'betaMd_AF4_minPSD', 'betaMd_AF4_maxPSD', 'betaMd_AF4_avgPSD', 'betaMd_AF_minDASM', 'betaMd_AF_maxDASM', 'betaMd_AF_avgDASM', 'betaMd_AF_minRASM', 'betaMd_AF_maxRASM', 'betaMd_AF_avgRASM', 'betaMd_T_minDASM', 'betaMd_T_maxDASM', 'betaMd_T_avgDASM', 'betaMd_T_minRASM', 'betaMd_T_maxRASM', 'betaMd_T_avgRASM', 'betaHi_AF3_minMag', 'betaHi_AF3_maxMag', 'betaHi_AF3_avgMag', 'betaHi_AF3_minPSD', 'betaHi_AF3_maxPSD', 'betaHi_AF3_avgPSD', 'betaHi_T7_minMag', 'betaHi_T7_maxMag', 'betaHi_T7_avgMag', 'betaHi_T7_minPSD', 'betaHi_T7_maxPSD', 'betaHi_T7_avgPSD', 'betaHi_Pz_minMag', 'betaHi_Pz_maxMag', 'betaHi_Pz_avgMag', 'betaHi_Pz_minPSD', 'betaHi_Pz_maxPSD', 'betaHi_Pz_avgPSD', 'betaHi_T8_minMag', 'betaHi_T8_maxMag', 'betaHi_T8_avgMag', 'betaHi_T8_minPSD', 'betaHi_T8_maxPSD', 'betaHi_T8_avgPSD', 'betaHi_AF4_minMag', 'betaHi_AF4_maxMag', 'betaHi_AF4_avgMag', 'betaHi_AF4_minPSD', 'betaHi_AF4_maxPSD', 'betaHi_AF4_avgPSD', 'betaHi_AF_minDASM', 'betaHi_AF_maxDASM', 'betaHi_AF_avgDASM', 'betaHi_AF_minRASM', 'betaHi_AF_maxRASM', 'betaHi_AF_avgRASM', 'betaHi_T_minDASM', 'betaHi_T_maxDASM', 'betaHi_T_avgDASM', 'betaHi_T_minRASM', 'betaHi_T_maxRASM', 'betaHi_T_avgRASM', 'gamma_AF3_minMag', 'gamma_AF3_maxMag', 'gamma_AF3_avgMag', 'gamma_AF3_minPSD', 'gamma_AF3_maxPSD', 'gamma_AF3_avgPSD', 'gamma_T7_minMag', 'gamma_T7_maxMag', 'gamma_T7_avgMag', 'gamma_T7_minPSD', 'gamma_T7_maxPSD', 'gamma_T7_avgPSD', 'gamma_Pz_minMag', 'gamma_Pz_maxMag', 'gamma_Pz_avgMag', 'gamma_Pz_minPSD', 'gamma_Pz_maxPSD', 'gamma_Pz_avgPSD', 'gamma_T8_minMag', 'gamma_T8_maxMag', 'gamma_T8_avgMag', 'gamma_T8_minPSD', 'gamma_T8_maxPSD', 'gamma_T8_avgPSD', 'gamma_AF4_minMag', 'gamma_AF4_maxMag', 'gamma_AF4_avgMag', 'gamma_AF4_minPSD', 'gamma_AF4_maxPSD', 'gamma_AF4_avgPSD', 'gamma_AF_minDASM', 'gamma_AF_maxDASM', 'gamma_AF_avgDASM', 'gamma_AF_minRASM', 'gamma_AF_maxRASM', 'gamma_AF_avgRASM', 'gamma_T_minDASM', 'gamma_T_maxDASM', 'gamma_T_avgDASM', 'gamma_T_minRASM', 'gamma_T_maxRASM', 'gamma_T_avgRASM'};
    temp = [];
    DP = [];
    
    tic;
    
    %% Get list of files.
    path = '_DataPoints';
    filePattern = fullfile(path, '*.csv');
    filelist = dir(filePattern);
    
    %% Build data point matrix.
    disp('Importing files...');
    for i = 1 : length(filelist)
        % Import file
        baseFilename = filelist(i).name;
        fullFilename = fullfile(path, baseFilename);
        datapoint = ImportDataPoint(fullFilename,1,1);
        
        % Separate the ID S W EM RP columns from the DP
        dump = datapoint(:,1:40);
        toNormalize = datapoint(:,41:end);
        
        % Append to matrix
        temp = [temp ; dump];
        DP = [DP ; toNormalize];
        
    end
    
    disp('Evaluating z-scores...');
    Z = zscore(DP);
    
    disp('Clipping values to -3 / +3');
    [row, col] = size(Z);
    for i = 1:row
        for j = 1:col
            if Z(i,j) > 3
                Z(i,j) = 3;
            elseif Z(i,j) < -3
                Z(i,j) = -3;
            end
        end
    end
    
    disp('Building the final matrix...');
    M = [temp Z];
    
    disp('Saving .CSV file...');
    CsvWriteH(saveFilename, M, H);

    toc;
end