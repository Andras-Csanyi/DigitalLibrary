Feature: DimensionStructure Business Logic - Listing Active DimensionStructures

  As a Data Owner and Data Curator
  I have to know what DimensionStructures are available in the system
  I also have to know which one is active and disabled
  So that, I need a functionality listing DimensionStructures

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