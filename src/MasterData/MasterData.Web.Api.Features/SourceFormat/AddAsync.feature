Feature: Adding SourceFormat Entity To The System

  As a Data Owner and Data Curator
  I need to be able to manage SourceFormat related data in the system
  So that, I need functionality covering this.

  Scenario: Adds New SourceFormat - IsActive is zero

    Given there is a SourceFormat domain object
      | Field    | Value |
      | Name     | asd   |
      | Desc     | asd   |
      | IsActive | 0     |
      | Key      | sf    |
    When SourceFormat domain object is saved
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |
    Then SourceFormat has the following properties
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
    When SourceFormat domain object is saved
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |
    Then SourceFormat has the following properties
      | Field    | Value     |
      | Key      | sf-result |
      | Name     | asd       |
      | Desc     | asd       |
      | IsActive | 1         |