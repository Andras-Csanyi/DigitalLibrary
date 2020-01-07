-- run it with DILIB admin user

SELECT r('----------------------------');
SELECT r('---- Master Data Schema ----');
SELECT r('----------------------------');

-- schemas
\i ../Schemas/MasterData/Schema/master_data.schema.sql

-- tables without foreign keys
\i ../Schemas/MasterData/Tables/dimension.table.sql
\i ../Schemas/MasterData/Tables/dimension_property.table.sql
\i ../Schemas/MasterData/Tables/sort_order.table.sql

-- tables with foreign keys
\i ../Schemas/MasterData/Tables/dimension_dimension_property.table.sql

-- foreign keys
\i ../Schemas/MasterData/ForeignKeys/dimension_dimension_property.fk.sql
