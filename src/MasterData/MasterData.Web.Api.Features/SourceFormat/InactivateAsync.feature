Feature: SourceFormat endpoint - Inactivate method

  As a Data Owner and Data Curator
  I need to be able to invalidate data and data structure in the system
  Meaning it is not deleted and neither takes its part of the processes
  So that, I need inactivate functionality

  Scenario: Inactivate SourceFormat

    Given there is a SourceFormat domain object
      | Field    | Value            |
      | Key      | orig             |
      | Name     | name-orig        |
      | Desc     | description-orig |
      | IsActive | 1                |
    And SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value       |
      | Key       | orig        |
      | ResultKey | orig-result |
    When to be inactivated SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value                            |
      | Key       | orig-result                      |
      | ResultKey | orig-inactivate-operation-result |
    And SourceFormat with given Id is requested
      | Field         | Value               |
      | IdValueSource | orig-result         |
      | ResultKey     | inactivation-result |

    Then 'inactivation-result' SourceFormat IsActive property is '0'
