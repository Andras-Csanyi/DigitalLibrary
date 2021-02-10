Feature: DimensionStructure Business Logic - Listing Inactive DimensionStructures

  As a Data Owner and Data Curator
  I have to know what DimensionStructures are available in the system
  I also have to know which one is active and disabled
  So that, I need a functionality listing DimensionStructures

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
      