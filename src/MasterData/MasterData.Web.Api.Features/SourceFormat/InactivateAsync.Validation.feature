Feature: SourceFormat REST Api - Inactivate a SourceFormat input validation

  As a Data Owner and Data Curator
  I need to be able to invalidate data and data structure in the system
  Meaning it is not deleted and neither takes its part of the processes
  I need to be able to do it the data or data structure doesn't get corrupted
  So that, I need inactivate functionality input validated

  Scenario: Inactivate returns bad request when input is invalid

    Given there is a SourceFormat domain object
      | Field    | Value            |
      | Key      | orig             |
      | Name     | name-orig        |
      | Desc     | description-orig |
      | IsActive | 1                |
    When to be inactivated SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value                            |
      | Key       | orig                             |
      | ResultKey | orig-inactivate-operation-result |

    Then SourceFormat domain object related 'orig-inactivate-operation-result' save operation returns with bad request
