#-- This script is to modify the tables 'tblcontestperformance', 'contestperformance' 
#-- & 'awardperformance', so that there should be a primary key associated to each ---#

#--- Created By Abdul Haseeb (DPS) ---#
#--- Created At 11/15/2014 -----#

ALTER TABLE tblcontestperformance
ADD CP_ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY;

ALTER TABLE contestperformance
ADD CP_ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY;

ALTER TABLE awardperformance
ADD AP_ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY;


#-------------------------------------------------------------------------------#