Feature: Logical Delete of DimensionStructure

  As a Data Owner and Data Curator
  In order to keep the data and structures in check
  I need a functionality makes possible to logically delete those I don't need anymore.

  Background:
    Given there is a saved DimensionStructure domain object
      | Field     | Value         |
      | ResultKey | no-connection |

  Scenario: DimensionStructure doesn't have any connection

    When amount of active DimensionStructure is requested
      | Field     | Value                |
      | ResultKey | amount-before-delete |
    And DimensionStructure is logically deleted
      | Field     | Value                |
      | Key       | no-connection        |
      | ResultKey | no-connection-result |
    And amount of active DimensionStructure is requested
      | Field     | Value               |
      | ResultKey | amount-after-delete |
    And list of active DimensionStructures is requested
      | Field     | Value             |
      | ResultKey | list-after-delete |

    Then difference between list is
      | Field           | Value                |
      | ExpectedDiff    | 1                    |
      | FirstResultKey  | amount-before-delete |
      | SecondResultKey | amount-after-delete  |
    And list of DimensionStructure doesn't contain the deleted one
      | Field                 | Value             |
      | ResultKey             | list-after-delete |
      | DimensionStructureKey | no-connection     |