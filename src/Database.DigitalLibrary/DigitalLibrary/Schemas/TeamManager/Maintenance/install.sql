-- run it with DILIB admin user

SELECT r('-----------------------------');
SELECT r('---- Team Manager Schema ----');
SELECT r('-----------------------------');

-- schemas
\i ../Schemas/TeamManager/Schema/team_manager.schema.sql

-- tables without foreign keys
\i ../Schemas/TeamManager/Tables/company.table.sql
\i ../Schemas/TeamManager/Tables/event.table.sql
\i ../Schemas/TeamManager/Tables/position.table.sql
\i ../Schemas/TeamManager/Tables/title.table.sql

-- tables with foreign keys
\i ../Schemas/TeamManager/Tables/people.table.sql
\i ../Schemas/TeamManager/Tables/people_event_log.table.sql

-- foreign keys
\i ../Schemas/TeamManager/ForeignKeys/people.fk.sql
\i ../Schemas/TeamManager/ForeignKeys/people_event_log.fk.sql
