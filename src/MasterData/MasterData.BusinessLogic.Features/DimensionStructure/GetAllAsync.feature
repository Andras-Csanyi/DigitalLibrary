Feature: DimensionStructure Business Logic - Listing DimensionStructures

  As a Data Owner and Data Curator
  I have to know what DimensionStructures are available in the system
  I also have to know which one is active and disabled
  So that, I need a functionality listing DimensionStructures

  Scenario Outline: Get list of DimensionStructures
    Given I have <ActiveAmount> active saved DimensionStructures
    And I have <InactiveAmount> inactive saved DimensionStructures
    When I query all DimensionStructures
      | Field     | Value  |
      | ResultKey | all-ds |
    Then the available DimensionStructures list with 'all-ds' result key is <ExpectedResult>

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedResult |
      | 0            | 1              | 1              |
      | 1            | 1              | 2              |
      | 1            | 0              | 1              |
      | 10           | 10             | 20             |

  Scenario Outline: Get list of active DimensionStructures
    Given I have <ActiveAmount> active saved DimensionStructures
    And I have <InactiveAmount> inactive saved DimensionStructures
    When I query active DimensionStructures
      | Field     | Value         |
      | ResultKey | all-active-ds |
    Then the available DimensionStructures list with 'all-active-ds' result key is <ExpectedResult>

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedResult |
      | 0            | 1              | 0              |
      | 1            | 1              | 1              |
      | 1            | 0              | 1              |
      | 10           | 10             | 10             |

  Scenario Outline: Get list of inactive DimensionStructures
    Given I have <ActiveAmount> active saved DimensionStructures
    And I have <InactiveAmount> inactive saved DimensionStructures
    When I query inactive DimensionStructures
      | Field     | Value           |
      | ResultKey | all-inactive-ds |
    Then the available DimensionStructures list with 'all-inactive-ds' result key is <ExpectedResult>

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedResult |
      | 0            | 1              | 1              |
      | 1            | 1              | 1              |
      | 1            | 0              | 0              |
      | 10           | 10             | 10             |
      