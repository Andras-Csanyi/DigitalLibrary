Feature: DimensionStructure Rest Endpoint - Listing all active DimensionStructures

  As a Data Owner and Data Curator
  I need to be able to list all available DimensionStructures
  So that, I need a functionality providing it.

  Scenario Outline: All active DimensionStructure is listed

    Given there are <ActiveAmount> active saved DimensionStructures
    And there are <InactiveAmount> inactive saved DimensionStructures
    When DimensionStructure GetActives endpoint is called
      | Field     | Value        |
      | ResultKey | get-all-list |
    Then the length of the DimensionStructure list is
      | Field          | Value            |
      | Key            | get-all-list     |
      | ExpectedLength | <ExpectedAmount> |

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedAmount |
      | 1            | 0              | 1              |
      | 0            | 1              | 0              |
      | 1            | 1              | 1              |