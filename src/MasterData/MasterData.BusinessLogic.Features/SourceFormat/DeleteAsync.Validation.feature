Feature: SourceFormat Business Logic - Delete a SourceFormat input validation

  As a Data Owner and Data Curator
  I need to be able to manage SourceFormats in the system
  Which includes being able to delete them and a validation of delete operation
  So that, I need a functionality providing this.

  Scenario: When input data for delete is invalid exception is thrown
    Given there is a SourceFormat domain object
      | Field | Value     |
      | Key   | sf-delete |
    When SourceFormat is deleted
      | Field     | Value            |
      | Key       | sf-delete        |
      | ResultKey | sf-delete-result |
    Then SourceFormat delete operation shows an error
      | Field | Value            |
      | Key   | sf-delete-result |