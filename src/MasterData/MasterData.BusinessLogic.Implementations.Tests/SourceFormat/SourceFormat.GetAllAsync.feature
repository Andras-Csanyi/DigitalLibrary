Feature: Listing all SourceFormats in the system

  As a Data Owner and Data Curator
  I need to be able to see all the SourceFormats in the system
  So I need a functionality listing them.

  Scenario Outline: SourceFormat GetAllAsync method
    Given there are <ActiveAmount> active SourceFormats in the system
    And there are <InactiveAmount> inactive SourceFormats in the system
    When I query list of SourceFormats
      | Field     | Value  |
      | ResultKey | sf-all |
    Then the length of the SourceFormats list in 'sf-all' is <ExpectedAmount>

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedAmount |
      | 1            | 1              | 2              |
      | 0            | 1              | 1              |
      | 1            | 0              | 1              |
      | 0            | 0              | 0              |