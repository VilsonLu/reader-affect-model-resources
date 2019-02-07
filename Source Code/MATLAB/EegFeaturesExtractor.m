function EegFeaturesExtractor(file)
% EegFeaturesExtractor Given the raw EEG signals, this function
% preprocesses the data and extracts the statistical features.
%

%% Import the file.
%file = 'JULES_TV\00 Raw\JULES_baseline_20160808-124059.csv';
%file = 'JULES_TV\03 Windows\S1_W0.csv';
[fPath, fName, fExt] = fileparts(file);
numRows = GetNumberOfRows(file);
header = GetCsvHeaders(file,0);
[TS,rawAF3,rawT7,rawPZ,rawT8,rawAF4] = ImportBaseline(file,2,numRows-1);
disp(['Importing ' file '...']);

%% Create save path.
basePath = pwd;
cd(fPath);
cd ..;
if ~exist('04 Features','dir')
    mkdir('04 Features');
end
cd('04 Features');
savePath = pwd;
cd(basePath);

%% Build matrix containing the raw signals.
rawData = [rawAF3,rawT7,rawPZ,rawT8,rawAF4];

%% Some constants.
Fs = 128;           % Sampling frequency (Hz)
[N, nChannels] = size(rawData);   % Number of time-domain samples
t = 1/Fs*[1:N];    % Time vector for time-domain signal (s)
freq = (1:N)*Fs/N; % Frequency vector for frequency-domain signal (Hz)
temp = strsplit(fName,'_');
fileprefix = strcat(savePath,'\',char(strcat(temp(1),'_',temp(2))));

%% Frequency band filter coefficients.
%coDelta = FreqFilt_Delta();
coTheta = FreqFilt_Theta();
coAlpha = FreqFilt_Alpha();
coBetaLo = FreqFilt_BetaLo();
coBetaMd = FreqFilt_BetaMd();
coBetaHi = FreqFilt_BetaHi();
coGamma = FreqFilt_Gamma();

%% Frequency band containers.
%deltaSig = [];
thetaSig = [];
alphaSig = [];
betaLoSig = [];
betaMdSig = [];
betaHiSig = [];
gammaSig = [];

%% Extract frequency bands for each EEG channel.
disp('Raw signal processing...');
for i = 1:nChannels
    currentCh = char(header(i+1));
    disp(['   Current Channel: ' currentCh '...']);
    
    % Raw signal.
    rawSig = rawData(:,i);

    % Smooth the data.
    disp('      Applying moving average function...');
    smSig = smooth(rawSig);
    
    % Extract DELTA frequency band.
    %disp('      Extracting DELTA frequency band...');
    %delta = filter(coDelta,smSig);
    %deltaSig = [deltaSig delta];

    % Extract THETA frequency band.
    disp('      Extracting THETA frequency band...');
    theta = filter(coTheta,smSig);
    thetaSig = [thetaSig theta];

    % Extract ALPHA frequency band.
    disp('      Extracting ALPHA frequency band...');
    alpha = filter(coAlpha,smSig);
    alphaSig = [alphaSig,alpha];
    
    % Extract BETA-LO frequency band.
    disp('      Extracting BETA-LO frequency band...');
    betaLo = filter(coBetaLo,smSig);
    betaLoSig = [betaLoSig betaLo];
    
    % Extract BETA-MID frequency band.
    disp('      Extracting BETA-MID frequency band...');
    betaMd = filter(coBetaMd,smSig);
    betaMdSig = [betaMdSig betaMd];
    
    % Extract BETA-HI frequency band.
    disp('      Extracting BETA-HI frequency band...');
    betaHi = filter(coBetaHi,smSig);
    betaHiSig = [betaHiSig betaHi];
    
    % Extract GAMMA frequency band.
    disp('      Extracting GAMMA frequency band...');
    gamma = filter(coGamma,smSig);
    gammaSig = [gammaSig gamma];
    
    % RAW PLOT SIGNAL AND SMOOTH-SIGNAL
     disp('      Plotting...');
     fig = figure;
     plot(rawSig,t);
     figure(fig);hold on
     plot(smSig,t);
%     figure(fig);hold on
%     plot(deltaSig(:,i));
%     figure(fig);hold on
%     plot(thetaSig(:,i));
%     figure(fig);hold on
%     plot(alphaSig(:,i));
%     figure(fig);hold on
%     plot(betaLoSig(:,i));
%     figure(fig);hold on
%     plot(betaMdSig(:,i));
%     figure(fig);hold on
%     plot(betaHiSig(:,i));
%     figure(fig);hold on
%     plot(gammaSig(:,i));
%     legend('Raw','Smooth','Delta','Theta','Alpha','BetaLo','BetaMid','BetaHi','Gamma');
%     title([currentCh ' Channel']);
%     grid on;
end

%% Extract frequency band features.
%disp('Delta band features...');
% %[deltaH,deltaM] = GetEegFeatures(header,deltaSig,'delta');
% disp('Theta band features...');
% [thetaH,thetaM] = GetEegFeatures(header,thetaSig,'theta');
% disp('Alpha band features...');
% [alphaH,alphaM] = GetEegFeatures(header,alphaSig,'alpha');
% disp('BetaLo band features...');
% [betaLoH,betaLoM] = GetEegFeatures(header,thetaSig,'betaLo');
% disp('BetaMd band features...');
% [betaMdH,betaMdM] = GetEegFeatures(header,thetaSig,'betaMd');
% disp('BetaHi band features...');
% [betaHiH,betaHiM] = GetEegFeatures(header,thetaSig,'betaHi');
% disp('Gamma band features...');
% [gammaH,gammaM] = GetEegFeatures(header,thetaSig,'gamma');
% 
% disp('Combining frequency band features to one file...');
% freqBandFeaturesH = [thetaH alphaH betaLoH betaMdH betaHiH gammaH];
% freqBandFeaturesM = [thetaM alphaM betaLoM betaMdM betaHiM gammaM];
% freqBandFeaturesFile = strcat(fileprefix,'_features',fExt);
% disp(['   Writing to ' freqBandFeaturesFile '...']);
% CsvWriteH(freqBandFeaturesFile,freqBandFeaturesM,freqBandFeaturesH);

end