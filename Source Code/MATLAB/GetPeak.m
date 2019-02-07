function peak = GetPeak(magnitude)
%GetPeak Gets the highest point of a signal.
    sorted = sort(magnitude);
    peak = sorted(end);
end