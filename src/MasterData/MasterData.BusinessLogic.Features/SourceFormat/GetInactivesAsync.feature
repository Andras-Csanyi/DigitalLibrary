Feature: Listing all inactive SourceFormats in the system

  As a Data Owner and Data Curator
  I need to be able to see which SourceFormat is active and inactive and listing them accordingly
  So I need a functionality listing them.

  Scenario Outline: SourceFormat GetAllAsync method
    Given there are <ActiveAmount> active SourceFormats in the system
    And there are <InactiveAmount> inactive SourceFormats in the system
    When I query inactive SourceFormats
      | Field     | Value           |
      | ResultKey | sf-all-inactive |
    Then the length of the SourceFormats list in 'sf-all-inactive' is <ExpectedAmount>

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedAmount |
      | 1            | 1              | 1              |
      | 0            | 1              | 1              |
      | 1            | 0              | 0              |
      | 0            | 0              | 0              |