function [retHeader,retM] = GetEegFeatures(h,freqBands,freqBandName)
%GetEegFeatures Returns the magnitude, PSD, DASM, and RASM features.
%

    [N, nChannels] = size(freqBands);
    M = [];
    colHeader = {};
    
    AF3 = [];
    AF4 = [];
    T7 = [];
    T8 = [];
    
    for i = 1:nChannels
        ch = char(h(i+1));
        currentCh = strcat(freqBandName,'_',ch);
        disp(['   Current Channel: ' currentCh '...']);

        % Signal in the time-domain.
        band = freqBands(:,i);

        % Signal in the frequency domain.
        fftSig = fft(band);

        % The absolute value of the FFT.
        magnitude = abs(fftSig);

        % Power Spectrum.
        psd = PowerSpectrum(magnitude);

        %peakMag = [peakMag GetPeak(magnitude)];
        %peakPSD = [peakPSD GetPeak(psd)];
        %MSP = [MSP mean(psd)];

        % Build features
        M = [M min(magnitude) max(magnitude) mean(magnitude) min(psd) max(psd) mean(psd)];
        colHeader = [colHeader strcat(currentCh,'_minMag') strcat(currentCh,'_maxMag') strcat(currentCh,'_avgMag') strcat(currentCh,'_minPSD') strcat(currentCh,'_maxPSD') strcat(currentCh,'_avgPSD')]
        
        % Get the electrode pairs
        if strcmp(ch,'AF3') == 1
            AF3 = magnitude;
        elseif strcmp(ch,'AF4') == 1
            AF4 = magnitude;
        elseif strcmp(ch,'T7') == 1
            T7 = magnitude;
        elseif strcmp(ch,'T8') == 1
            T8 = magnitude;
        end
    end
        
    disp('   Extracting AF-pair features...');
    AF_DASM = DifferentialAsymmetry(AF3, AF4);
    M = [M min(AF_DASM) max(AF_DASM) mean(AF_DASM)];
    colHeader = [colHeader strcat(freqBandName,'_AF_minDASM') strcat(freqBandName,'_AF_maxDASM') strcat(freqBandName,'_AF_avgDASM')];
    
    AF_RASM = RationalAsymmetry(AF3, AF4);
    M = [M min(AF_RASM) max(AF_RASM) mean(AF_RASM)];
    colHeader = [colHeader strcat(freqBandName,'_AF_minRASM') strcat(freqBandName,'_AF_maxRASM') strcat(freqBandName,'_AF_avgRASM')];
    
    disp('   Extracting T-pair features...');
    T_DASM = DifferentialAsymmetry(T7, T8);
    M = [M min(T_DASM) max(T_DASM) mean(T_DASM)];
    colHeader = [colHeader strcat(freqBandName,'_T_minDASM') strcat(freqBandName,'_T_maxDASM') strcat(freqBandName,'_T_avgDASM')];

    T_RASM = RationalAsymmetry(T7, T8);
    M = [M min(T_RASM) max(T_RASM) mean(T_RASM)];
    colHeader = [colHeader strcat(freqBandName,'_T_minRASM') strcat(freqBandName,'_T_maxRASM') strcat(freqBandName,'_T_avgRASM')];
        
    retHeader = colHeader;
    retM = M;
end