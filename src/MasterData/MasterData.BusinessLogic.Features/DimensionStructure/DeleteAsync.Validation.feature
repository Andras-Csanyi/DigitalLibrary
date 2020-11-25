Feature: DimensionStructure Business Logic - Delete input validation

  As a Data Owner and Data Curator
  I need to be able to maintain the system which includes being able to delete DimensionStructures
  So that, I need a functionality providing it.

  Scenario: Delete DimensionStructure

    Given there is a DimensionStructure domain object
      | Field | Value |
      | Key   | first |

    When DimensionStructure is deleted
      | Field     | Value                       |
      | Key       | first                       |
      | ResultKey | second-result-delete-result |

    Then DimensionStructure related operation throws exception
      | Field | Value                       |
      | Key   | second-result-delete-result |
    
    