Feature: SourceFormat Business Logic - Listing all active SourceFormats

  As a Data Owner and Data Curator
  I need to be able to see which SourceFormat is active and inactive and listing them accordingly
  So I need a functionality listing them.

  Scenario Outline: SourceFormat GetAllAsync method
    Given there are <ActiveAmount> active SourceFormats in the system
    And there are <InactiveAmount> inactive SourceFormats in the system
    When I query active SourceFormats
      | Field     | Value         |
      | ResultKey | sf-all-active |
    Then the length of the SourceFormats list in 'sf-all-active' is <ExpectedAmount>

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedAmount |
      | 1            | 1              | 1              |
      | 0            | 1              | 0              |
      | 1            | 0              | 1              |
      | 0            | 0              | 0              |