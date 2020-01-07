-- run it as DILIB_ADMIN user

-- navigate to the database_path/Maintenance directory
-- log in to DIGITAL_LIBRARY database as DILIB_AMDIN user
-- execute the \i install.sql

\i ../Tools/Maintenance/install.sql

\i ../Schemas/MasterData/Maintenance/install.sql
\i ../Schemas/ControlPanel/Maintenance/install.sql
\i ../Schemas/TeamManager/Maintenance/install.sql