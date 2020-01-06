DROP TABLE IF EXISTS TEAM_MANAGER.PEOPLE;
CREATE TABLE TEAM_MANAGER.PEOPLE
(
    ID          BIGINT GENERATED ALWAYS AS IDENTITY UNIQUE,
    FIRST_NAME  VARCHAR NOT NULL,
    MIDDLE_NAME VARCHAR NOT NULL,
    LAST_NAME   VARCHAR NOT NULL,
    IS_ACTIVE   INT     NOT NULL DEFAULT 0,
    COMPANY_ID  BIGINT  NOT NULL,
    POSITION_ID BIGINT  NOT NULL,
    TITLE_ID    BIGINT  NOT NULL
);