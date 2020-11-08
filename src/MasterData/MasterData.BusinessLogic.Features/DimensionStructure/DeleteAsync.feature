Feature: DimensionStructure Business Logic - Delete

  As a Data Owner and Data Curator
  I need to be able to maintain the system which includes being able to delete DimensionStructures
  So that, I need a functionality providing it.

  Scenario: Delete DimensionStructure

    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | first |
      | IsActive | 1     |
    And DimensionStructure is saved
      | Field     | Value        |
      | Key       | first        |
      | ResultKey | first-result |
    And there is a DimensionStructure domain object
      | Field    | Value  |
      | Key      | second |
      | IsActive | 1      |
    And DimensionStructure is saved
      | Field     | Value         |
      | Key       | second        |
      | ResultKey | second-result |

    When I query all DimensionStructures
      | Field     | Value            |
      | ResultKey | before-delete-ds |
    And DimensionStructure is deleted
      | Field     | Value                       |
      | Key       | second-result               |
      | ResultKey | second-result-delete-result |
    And I query all DimensionStructures
      | Field     | Value           |
      | ResultKey | after-delete-ds |

    Then difference between two DimensionLists
      | Field     | Value            |
      | BeforeKey | before-delete-ds |
      | AfterKey  | after-delete-ds  |
    And DimensionStructure is requested
      | Field     | Value                          |
      | Key       | second-result                  |
      | ResultKey | second-result-requested-result |
    And DimensionStructure is requested result is null
      | Field | Value                          |
      | Key   | second-result-requested-result |
    
    