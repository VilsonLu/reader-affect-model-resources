function result = RationalAsymmetry(ch1, ch2);
%RationalAsymmetry computes the rational asymmetry of the electrode
%pair by power division
    result = (ch1.^2) ./ (ch2.^2);
end