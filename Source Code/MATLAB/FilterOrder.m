function filterorder = FilterOrder(Fs, locutoff)
%FilterOrder Returns the length of the filter in points based on the default formula:
%   3*fix(srate/locutoff)
%
filterorder = 3*fix(Fs/locutoff);