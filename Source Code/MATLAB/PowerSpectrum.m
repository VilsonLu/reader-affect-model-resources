function result = PowerSpectrum(magnitude)
%PowerSpectrum Computes the Power Spectrum of Signal
%Squaring the Magnitude yields Power Spectrum
    pSpectrum = [];
    for i = 1:length(magnitude),
        pSpectrum(i,1) = magnitude(i)*magnitude(i);
    end
    result = pSpectrum;
end