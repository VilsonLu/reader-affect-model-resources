function [meanNorm, stdNorm] = GetNormalizerConstants()
%NormalizerConstants returns the mean and standard deviation from the list
%of all data points in the data set to be built.

    M = [];
    
    %% Get list of files.
    path = 'DataPoints';
    filePattern = fullfile(path, '*.csv');
    filelist = dir(filePattern);
    
    %% Build data point matrix.
    for i = 1 : length(filelist)
        % Import file
        baseFilename = filelist(i).name;
        fullFilename = fullfile(path, baseFilename);
        features = ImportEegFeatures(fullFilename,1,1);
        % Append to matrix
        M = [M ; features];
    end
    
    meanNorm = mean(M);
    stdNorm = std(M);
end