function NumRows = GetNumberOfRows(filename)
%GETNUMBEROFROWS Returns the number of rows in the CSV file.
%   var = GetNumberOfRows(filename)
%
% Example:
%   x = GetNumberOfRows('myFile.csv');
%

%% Open the CSV file.
fid = fopen(filename, 'rb');

%% Get file size.
fseek(fid, 0, 'eof');
fileSize = ftell(fid);
frewind(fid);

%% Read the whole file.
data = fread(fid, fileSize, 'uint8');

%% Close the file.
fclose(fid);

%% Count number of line-feeds and increase by one.
NumRows = sum(data == 10) + 1;
