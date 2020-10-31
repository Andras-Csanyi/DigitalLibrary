Feature: Delete SourceFormat

  As a Data Owner and Data Curator
  I need to be able to manage SourceFormats in the system
  Which includes being able to delete them
  So that, I need a functionality providing this.

  Scenario: Delete SourceFormat
    Given there is a SourceFormat domain object
      | Field | Value     |
      | Key   | sf-delete |
    And SourceFormat is saved
      | Field     | Value            |
      | Key       | sf-delete        |
      | ResultKey | sf-delete-result |
    When SourceFormat is deleted
      | Field     | Value                    |
      | Key       | sf-delete-result         |
      | ResultKey | sf-delete-result-deleted |
    Then SourceFormat delete operation doesn't show error
      | Field | Value                    |
      | Key   | sf-delete-result-deleted |