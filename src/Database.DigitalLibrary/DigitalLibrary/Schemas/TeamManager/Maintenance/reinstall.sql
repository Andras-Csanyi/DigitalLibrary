-- run it with DILIB admin user
DROP TABLE DIMENSION_DIMENSION_PROPERTY
;

-- tables without foreign keys
\i ../MasterData/Tables/dimension.table.sql
\i ../MasterData/Tables/dimension_property.table.sql
\i ../MasterData/Tables/sort_order.table.sql

-- tables with foreign keys
\i ../MasterData/Tables/dimension_dimension_property.table.sql
\i ../MasterData/ForeignKeys/dimension_dimension_property.fk.sql