function CopyDataPoints(input)
%CopyDataPoints This function copies the contents of 'user/05 DataPoints'
%folder to the main '_DataPoints' folder for the BuildDataset() function
    %users = {'ANDREA_TV', 'BEA_TV', 'DAIAN_TV', 'ELDES_TV', 'ERIKA_TV', 'FAITH_TV', 'JAN_TV', 'JAYMEE_TV', 'JED_TV', 'JOSEPH_TV', 'JOSHUA_TV', 'KERTY_TV', 'KIM_TV', 'LAURENCE_TV', 'LIZALE_TV', 'LYANN_TV', 'LYNETTE_TV', 'MARK_TV', 'MAUREEN_TV', 'NAOMI_TV', 'PHOEBE_TV', 'RALPH_TV', 'RHEI_TV', 'RHEYGINE_TV', 'ROSCOE_TV', 'SAIRA_TV', 'SAM_TV', 'SETH_TV', 'SHARMAINE_TV', 'STEPHANIE_TV', 'THERESA_TV', 'VINA_TV'};
    users = input;
    
    %%
    basepath = pwd;
    cd('_DataPoints');
    savePath = pwd;
    cd ..;
    
    %%
    tic;
    
    %%
    disp('Deleting contents of _DataPoints...');
    delete([savePath '/*.csv']);
    
    %%
    for i = 1:length(users)
        user = cell2mat(users(i));
        disp(['Now at ' user '...']);
        % Go to directory of current user
        cd(user);
        cd('05 DataPoints');
        path = pwd;
        
        % Get all files
        filePattern = fullfile(path, '*.csv');
        filelist = dir(filePattern);

        disp('     Copying files...');
        % Copy all files
        for k = 1 : length(filelist)
            filename = filelist(k).name;
            fullFilename = fullfile(path, filename);
            copyfile(fullFilename, savePath);
        end
        
        % Return to base directory
        cd(basepath);
    end
    
    %%
    toc;
end