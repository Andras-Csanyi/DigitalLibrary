Feature: SourceFormat REST Api - Requesting all SourceFormats

  As a Data Owner and Data Curator
  I need to be able to list all available SourceFormat entities in the system
  So that, I need a functionality providing this.

  Scenario Outline: Lists all SourceFormats in the system

    Given I have saved SourceFormats in the system
      | Field    | Value          |
      | Amount   | <ActiveAmount> |
      | IsActive | 1              |
    And I have saved SourceFormats in the system
      | Field    | Value            |
      | Amount   | <InactiveAmount> |
      | IsActive | 0                |
    When I request list of SourceFormats
      | Field     | Value   |
      | ResultKey | sf-list |
    Then the length of the list is
      | Field          | Value            |
      | Key            | sf-list          |
      | ExpectedAmount | <ExpectedAmount> |

    Examples:
      | ActiveAmount | InactiveAmount | ExpectedAmount |
      | 1            | 0              | 1              |
      | 0            | 1              | 1              |
      | 1            | 1              | 2              |