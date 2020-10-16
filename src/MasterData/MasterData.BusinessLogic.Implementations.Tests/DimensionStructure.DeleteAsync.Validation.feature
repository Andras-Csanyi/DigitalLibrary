Feature: Delete DimensionStructureAsync method input validation

  As a Data Owner and Data Curator
  In order to keep the data and structures in check
  I need a functionality makes possible to delete those I don't need
  These functionalities needed to be validated.

  Scenario: Exception is thrown when invalid data is provided for DimensionStructure delete

    When deleting DimensionStructure
      | Field     | Value                      |
      | Id        | 0                          |
      | ResultKey | dimension-structure-delete |

    Then DimensionStructure related operation throws exception
      | Field     | Value                      |
      | ResultKey | dimension-structure-delete |
