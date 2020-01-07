-- run it as DILIB_ADMIN user

SELECT r('------------------------------');
SELECT r('---- Control Panel Schema ----');
SELECT r('------------------------------');

--schema
\i ../Schemas/ControlPanel/Schema/control_panel.schema.sql

-- tables without foreign keys
\i ../Schemas/ControlPanel/Tables/module.table.sql

-- tables with foreign keys
\i ../Schemas/ControlPanel/Tables/menu.table.sql

-- foreign keys
\i ../Schemas/ControlPanel/ForeignKeys/menu.fk.sql

-- granting
\i ../Roles/dilib_webapi/grant/grant.sql