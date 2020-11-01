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
    Then The result SourceFormat has the following properties
      | Field    | Value     |
      | Key      | sf-result |
      | Name     | asd       |
      | Desc     | asd       |
      | IsActive | 0         |

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
    Then The result SourceFormat has the following properties
      | Field    | Value     |
      | Key      | sf-result |
      | Name     | asd       |
      | Desc     | asd       |
      | IsActive | 1         |