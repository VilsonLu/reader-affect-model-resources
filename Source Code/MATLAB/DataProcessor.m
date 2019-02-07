function DataProcessor(username,userid)
%DataProcessor Processes the data for 'username'
%

    %% Some constants.
    if nargin > 0
        user = cell2mat(username);
    else
        user = ''; % TEST
        userid = 1;
    end

    if ~exist('_DataPoints','dir')
        mkdir('_DataPoints');
    end


    rawPath = [user '\00 Raw'];
    windowsPath = [user '\03 Windows'];
    featuresPath = [user '\04 Features'];

    baseline = [];
    profile = [];
    emoanno = [];

    %% 
    filePattern = fullfile(rawPath, '*.csv');
    filelist = dir(filePattern);

    for k = 1 : length(filelist)
        filename = filelist(k).name;
        fullFilename = fullfile(rawPath, filename);

        if regexp(filename,'\w*baseline\w*') >= 1
            baseline = fullFilename;
        elseif regexp(filename,'\w*profile\w*') >= 1
            profile = ImportReaderProfile(fullFilename,1,1);
        elseif regexp(filename,'\w*EmoAnno\w*') >= 1
            [PL,AT,SE,AP,IS_STR,FR_EV,FR_NA,FR_AE,FR_O] = ImportEmoAnno(fullFilename,2,GetNumberOfRows(fullFilename)-1);
            emoanno = [PL,AT,SE,AP,FR_EV,FR_NA,FR_AE,FR_O,IS_STR];
        end
    end

    % Copy RAW baseline to '03 Windows' folder
    copyfile(strcat(char(baseline)), strcat(char(windowsPath)));

    %% Extract EEG Features.

%     % Get list of files in path
%     filePattern = fullfile(windowsPath, '*.csv');
%     filelist = dir(filePattern);
% 
%     % For each file in path, extract the EEG features
%     for k = 1 : length(filelist)
%       baseFilename = filelist(k).name;
%       filesize = filelist(k).bytes;
%       fullFilename = fullfile(windowsPath, baseFilename);
% 
%       % Disregard empty files and files with only the headers
%       if filesize > 167
%         EegFeaturesExtractor(fullFilename);
%       end
%     end

    %% Build the data points.

    % Get list of files in path
    filePattern = fullfile(featuresPath, '*.csv');
    filelist = dir(filePattern);
    erplist = {};

    % Separate the baseline features files from the others
    for k = 1 : length(filelist)
        filename = filelist(k).name;
        fullFilename = fullfile(featuresPath, filename);

        if regexp(filename,'\w*baseline\w*') >= 1
            baseline = fullFilename;
        else
            erplist = [erplist fullFilename];
        end
    end

    DataPointBuilder(baseline,erplist,user,userid,profile,emoanno);
end