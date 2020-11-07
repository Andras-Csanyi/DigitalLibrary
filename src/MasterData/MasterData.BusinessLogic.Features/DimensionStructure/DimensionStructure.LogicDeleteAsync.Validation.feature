Feature: Logically Delete DimensionStructureAsync method input validation

  As a Data Owner and Data Curator
  In order to keep the data and structures in check
  I need a functionality makes possible to delete those I don't need
  These functionalities needed to be validated.

  Scenario: Exception is thrown when invalid data is provided for DimensionStructure delete

    And there is a DimensionStructure domain object
      | Field | Value         |
      | Key   | no-connection |

    When DimensionStructure is logically deleted
      | Field     | Value                |
      | Key       | no-connection        |
      | ResultKey | no-connection-result |

    Then DimensionStructure related operation throws exception
      | Field     | Value                |
      | ResultKey | no-connection-result |
