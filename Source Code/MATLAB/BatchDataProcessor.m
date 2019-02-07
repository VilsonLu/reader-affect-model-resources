function BatchDataProcessor()
%BatchDataProcessor
%

    %% Some variables.  
    users = {'ANDREA_TV', 'BEA_TV', 'DAIAN_TV', 'ELDES_TV', 'ERIKA_TV', 'FAITH_TV', 'JAN_TV', 'JAYMEE_TV', 'JED_TV', 'JOSEPH_TV', 'JOSHUA_TV', 'KERTY_TV', 'KIM_TV', 'LAURENCE_TV', 'LIZALE_TV', 'LYANN_TV', 'LYNETTE_TV', 'MARK_TV', 'MAUREEN_TV', 'NAOMI_TV', 'PHOEBE_TV', 'RALPH_TV', 'RHEI_TV', 'RHEYGINE_TV', 'ROSCOE_TV', 'SAIRA_TV', 'SAM_TV', 'SETH_TV', 'SHARMAINE_TV', 'STEPHANIE_TV', 'THERESA_TV', 'VINA_TV'};
    %users = {'DAIAN_TV', 'JAYMEE_TV', 'JOSHUA_TV', 'LYANN_TV', 'RHEYGINE_TV', 'ROSCOE_TV'};
    
    %% Start timer. Disregard. For performance measurement only.
    tic;
    
    %% Process data for each user.
    for i = 1 : length(users)
        DataProcessor(users(i),i);
    end
    
    %% End timer. Disregard. For performance measurement only.
    toc;
end