Feature: SourceFormat Api - Adding SourceFormat Entity

  As a Data Owner and Data Curator
  I need to be able to manage SourceFormat related data in the system
  So that, I need functionality covering this on Api level.

  Scenario: Adds New SourceFormat - IsActive is zero

    Given there is a SourceFormat domain object
      | Field    | Value |
      | Name     | asd   |
      | Desc     | asd   |
      | IsActive | 0     |
      | Key      | sf    |
    When SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |
    Then 'sf-result' SourceFormat Name property is 'asd'
    And 'sf-result' SourceFormat Desc property is 'asd'
    And 'sf-result' SourceFormat IsActive property is '0'

  Scenario: Adds New SourceFormat - IsActive is 1

    Given there is a SourceFormat domain object
      | Field    | Value |
      | Name     | asd   |
      | Desc     | asd   |
      | IsActive | 1     |
      | Key      | sf    |
    When SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |
    Then 'sf-result' SourceFormat Name property is 'asd'
    And 'sf-result' SourceFormat Desc property is 'asd'
    And 'sf-result' SourceFormat IsActive property is '1'