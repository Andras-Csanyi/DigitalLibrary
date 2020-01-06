-- run it by your superuser
DROP ROLE IF EXISTS DILIB_WEBAPI
;

CREATE ROLE DILIB_WEBAPI WITH
    PASSWORD 'dilib_webapi'
    LOGIN
;