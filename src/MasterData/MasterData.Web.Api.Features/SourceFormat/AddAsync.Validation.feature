Feature: SourceFormat REST Api - Adding SourceFormat To The System Input Validation

  As a Data Owner and Data Curator
  I need to be able to manage SourceFormat related data in the system
  While working with these data I want to be sure the data I record is valid
  So that, I need functionality covering this.

  Scenario Outline: Adding SourceFormat Input Validation

    Given there is a SourceFormat domain object
      | Field    | Value         |
      | Key      | sf-validation |
      | Name     | <Name>        |
      | Desc     | <Description> |
      | IsActive | <IsActive>    |
    When SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value         |
      | Key       | sf-validation |
      | ResultKey | sf-result     |
    Then SourceFormat domain object related 'sf-result' save operation returns with bad request

    Examples:
      | Name    | Description | IsActive |
      | null    | asd         | 1        |
      | empty   | asd         | 1        |
      | as      | asd         | 1        |
      | 3spaces | asd         | 1        |
      | asd     | null        | 1        |
      | asd     | empty       | 1        |
      | asd     | as          | 1        |
      | asd     | 3spaces     | 1        |
      | asd     | asd         | 2        |